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

    public async Task<QuizResponse> GetQuiz(string userName)
    {
        try
        {
            var user = await _context.Users
                .Include(i => i.Group)
                .FirstOrDefaultAsync(a => a.Name == userName);
            if (user == null)
                throw new Exception("User not found.");
            var questions = await GetQuestionAndChoice(user.GroupId);
            var quiz = await _context.Quizzes
                .Include(i => i.Answers)
                .FirstOrDefaultAsync(a => a.UserId == user.Id);
            if (quiz == null)
            {
                foreach (var question in questions)
                {
                }

                return new QuizResponse
                {
                    QuizId = 0,
                    Questions = questions
                };
            }

            foreach (var answer in quiz.Answers)
            {
                var question = questions.FirstOrDefault(a => a.QuestionId == answer.QuestionId);
                var choice = question?.Choices.FirstOrDefault(a => a.ChoiceId == answer.ChoiceId);
                if (choice != null)
                {
                    choice.IsSelected = true;
                }
            }

            return new QuizResponse
            {
                QuizId = quiz.Id,
                Questions = questions
            };
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<List<QuestionModel>> GetQuestionAndChoice(int groupId)
    {
        try
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
                        IsSelected = false,
                    }).ToList()
                }).ToListAsync();
            return questions;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<SaveQuizResponse> SaveQuiz(SaveQuizRequest request)
    {
        try
        {
            var answers = request.Questions
                .SelectMany(a => a.Choices.Where(b => b.IsSelected)
                    .Select(c =>
                        new Answer
                        {
                            ChoiceId = c.ChoiceId,
                            QuestionId = a.QuestionId,
                        })
                ).ToList();
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
                var quiz = _context.Quizzes.FirstOrDefault(a => a.Id == request.QuizId);
                if (quiz == null)
                    throw new Exception("Quiz not found.");
                quiz.IsCompleted = false;
                quiz.Answers = answers;
                quiz.TotalScore = answers.Sum(a => a.score);
                _context.Quizzes.Update(quiz);
                await _context.SaveChangesAsync();
                return new SaveQuizResponse()
                {
                    Message = "Success",
                    QuizId = quiz.Id
                };
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<SaveQuizResponse> SubmitQuiz(SaveQuizRequest request)
    {
        try
        {
            var choiceIds = request.Questions
                .SelectMany(a => a.Choices
                    .Select(c => c.ChoiceId)
                ).ToList();
            var choices = _context.Choices.Where(a => choiceIds.Contains(a.Id)).ToList();
            var answers = request.Questions
                .SelectMany(a => a.Choices.Where(b => b.IsSelected)
                    .Select(c =>
                        new Answer
                        {
                            ChoiceId = c.ChoiceId,
                            QuestionId = a.QuestionId,
                            score = choices.FirstOrDefault(f => f.Id == c.ChoiceId)?.point ?? 0,
                            MaxScore = choices.Where(w => w.QuestionId == a.QuestionId).Max(s => s.point)
                        })
                ).ToList();
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
                var quiz = _context.Quizzes.FirstOrDefault(a => a.Id == request.QuizId);
                if (quiz == null)
                    throw new Exception("Quiz not found.");
                quiz.IsCompleted = true;
                quiz.Answers = answers;
                quiz.TotalScore = answers.Sum(a => a.score);
                _context.Quizzes.Update(quiz);
                await _context.SaveChangesAsync();
                return new SaveQuizResponse()
                {
                    Message = "Success",
                    QuizId = quiz.Id
                };
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<QuizResultResponse> GetQuizResult(int quizId)
    {
        try
        {
            var quiz = await _context.Quizzes
                .Include(i => i.Answers)
                .FirstOrDefaultAsync(a => a.Id == quizId);
            var user = await _context.Users
                .Include(i => i.Group)
                .FirstOrDefaultAsync(a => a.Id == quiz!.UserId);
            // get rank of user in group
            var rankNo = _context.Quizzes
                .Where(a => a.GroupId == user!.GroupId)
                .OrderByDescending(o => o.TotalScore)
                .ToList()
                .FindIndex(a => a.Id == quizId) + 1;
            return new QuizResultResponse
            {
                UserName = user!.Name,
                GroupName = user.Group!.Name,
                Score = quiz.TotalScore,
                MaxScore = quiz.Answers.Sum(s => s.MaxScore),
                RankNo = rankNo
            };
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}