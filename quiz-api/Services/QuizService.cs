using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using quiz_api.Entities;
using quiz_api.Entities.Models;
using quiz_api.Services.Models;
using quiz_api.Services.Models.Request;
using quiz_api.Services.Models.Response;

namespace quiz_api.Services;

public class QuizService
{
    private readonly DatabaseContext _context;

    public QuizService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<QuizResponse> GetQuiz(int userId)
    {
        var user = await _context.Users
            .Include(i => i.Group)
            .FirstOrDefaultAsync(a => a.Id == userId);
        if (user == null)
            throw new ValidationException("User not found.");
        var questions = await GetQuestionAndChoice(user.GroupId);
        var quiz = await _context.Quizzes
            .Include(i => i.Answers)
            .FirstOrDefaultAsync(a => a.UserId == user.Id);
        if (quiz == null)
        {
            return new QuizResponse
            {
                QuizId = 0,
                Questions = questions
            };
        }

        foreach (var answer in quiz.Answers)
        {
            var question = questions.FirstOrDefault(a => a.QuestionId == answer.QuestionId);
            question!.SelectedChoiceId = answer.ChoiceId;
        }

        return new QuizResponse
        {
            QuizId = quiz.Id,
            IsComplete = quiz.IsCompleted,
            Questions = questions
        };
    }

    private async Task<List<QuestionModel>> GetQuestionAndChoice(int groupId)
    {
        var questions = await _context.Questions
            .Include(i => i.Choices)
            .Where(a => a.GroupId == groupId)
            .Select(s => new QuestionModel()
            {
                QuestionId = s.Id,
                QuestionText = s.QuestionText,
                Choices = s.Choices.Select(ss => new ChoiceModel()
                {
                    ChoiceId = ss.Id,
                    ChoiceText = ss.ChoiceText,
                }).ToList()
            }).ToListAsync();
        questions.ForEach(a =>
        {
            for (var i = a.Choices.Count - 1; i >= 0; i--)
            {
                var j = new Random().Next(i + 1);

                // shuffle choices
                (a.Choices[i], a.Choices[j]) = (a.Choices[j], a.Choices[i]);
            }
        });
        return questions;
    }

    public async Task<SaveQuizResponse> SaveQuiz(SaveQuizRequest request)
    {
        var answers = request.Questions
            .Where(w => w.SelectedChoiceId.HasValue)
            .Select(s => new Answer
            {
                ChoiceId = s.SelectedChoiceId!.Value,
                QuestionId = s.QuestionId,
            }).ToList();
        if (request.QuizId == 0)
        {
            var quiz = new Quiz
            {
                UserId = request.UserId,
                IsCompleted = false,
                Answers = answers,
                GroupId = request.GroupId,
            };
            _context.Quizzes.Add(quiz);
            await _context.SaveChangesAsync();
            return new SaveQuizResponse()
            {
                Message = "Success",
                QuizId = quiz.Id
            };
        }
        else
        {
            var quiz = _context.Quizzes
                .Include(i => i.Answers)
                .OrderByDescending(o => o.Id)
                .FirstOrDefault(a => a.Id == request.QuizId);
            if (quiz == null)
                throw new ValidationException("Quiz not found.");
            quiz.IsCompleted = false;
            _context.Answers.RemoveRange(quiz.Answers);
            quiz.Answers = answers;
            await _context.SaveChangesAsync();
            return new SaveQuizResponse()
            {
                Message = "Success",
                QuizId = quiz.Id
            };
        }
    }

    public async Task<SaveQuizResponse> SubmitQuiz(SaveQuizRequest request)
    {
        var questionIds = request.Questions.Select(s => s.QuestionId).ToList();
        var choices = _context.Questions
            .Include(i => i.Choices)
            .Where(w => questionIds.Contains(w.Id))
            .SelectMany(a => a.Choices).ToList();
        var answers = request.Questions
            .Select(s => new Answer
            {
                ChoiceId = s.SelectedChoiceId!.Value,
                QuestionId = s.QuestionId,
                score = choices.FirstOrDefault(f => f.Id == s.SelectedChoiceId.Value)?.point ?? 0,
                MaxScore = choices.Where(w => w.QuestionId == s.QuestionId).Max(ss => ss.point)
            }).ToList();
        if (request.QuizId == 0)
        {
            var quiz = new Quiz
            {
                UserId = request.UserId,
                IsCompleted = true,
                Answers = answers,
                GroupId = request.GroupId,
                TotalScore = answers.Sum(a => a.score)
            };
            _context.Quizzes.Add(quiz);
            await _context.SaveChangesAsync();
            return new SaveQuizResponse()
            {
                Message = "Success",
                QuizId = quiz.Id
            };
        }
        else
        {
            var quiz = _context.Quizzes
                .Include(i => i.Answers)
                .FirstOrDefault(a => a.Id == request.QuizId);
            if (quiz == null)
                throw new ValidationException("Quiz not found.");
            quiz.IsCompleted = true;
            _context.Answers.RemoveRange(quiz.Answers);
            quiz.Answers = answers;
            quiz.TotalScore = answers.Sum(a => a.score);
            await _context.SaveChangesAsync();
            return new SaveQuizResponse()
            {
                Message = "Success",
                QuizId = quiz.Id
            };
        }
    }

    public async Task<QuizResultResponse> GetQuizResult(int userId)
    {
        var quiz = await _context.Quizzes
            .Include(i => i.Answers)
            .FirstOrDefaultAsync(a => a.UserId == userId);
        var user = await _context.Users
            .Include(i => i.Group)
            .FirstOrDefaultAsync(a => a.Id == quiz!.UserId);
        // get rank of user in group
        var rankNo = _context.Quizzes
            .Where(a => a.GroupId == user!.GroupId)
            .OrderByDescending(o => o.TotalScore)
            .ToList()
            .FindIndex(a => a.Id == quiz!.Id) + 1;
        return new QuizResultResponse
        {
            UserName = user!.Name,
            GroupName = user.Group!.Name,
            Score = quiz!.TotalScore,
            MaxScore = quiz.Answers.Sum(s => s.MaxScore),
            RankNo = rankNo
        };
    }
}