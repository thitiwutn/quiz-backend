using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using quiz_api.Entities;
using quiz_api.Services;
using quiz_api.Services.Models;
using quiz_api.Services.Models.Request;

namespace TestAPI.Services;

[TestClass]
[TestSubject(typeof(QuizService))]
public class QuizServiceTest
{
    [TestMethod]
    public void GetQuiz()
    {
        // Arrange
        var userId = 3;

        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        // Act
        using var context = new DatabaseContext(configuration);
        var service = new QuizService(context);
        var result = service.GetQuiz(userId);

        // Assert
        Assert.IsNotNull(result.Result);
        Assert.AreNotEqual(0, result.Result.Questions.Count);
    }

    [TestMethod]
    public void GetQuizResult()
    {
        // Arrange
        var userId = 17;

        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        // Act
        using var context = new DatabaseContext(configuration);
        var service = new QuizService(context);
        var result = service.GetQuizResult(userId);

        // Assert
        Assert.IsNotNull(result.Result);
        Assert.AreNotEqual(0, result.Result.RankNo);
    }

    [TestMethod]
    public void SaveQuiz()
    {
        // Arrange
        var dataRequest = new SaveQuizRequest()
        {
            QuizId = 0,
            UserId = 24,
            GroupId = 2,
            Questions = new List<QuestionRequest>()
            {
                new()
                {
                    QuestionId = 6,
                    SelectedChoiceId = 24
                },
                new()
                {
                    QuestionId = 7,
                    SelectedChoiceId = 27
                },
                new()
                {
                    QuestionId = 8,
                    SelectedChoiceId = 31
                },
                new()
                {
                    QuestionId = 9,
                    SelectedChoiceId = 33
                },
                new()
                {
                    QuestionId = 10,
                    SelectedChoiceId = 39
                }
            }
        };

        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        // Act
        using var context = new DatabaseContext(configuration);
        var service = new QuizService(context);
        var result = service.SaveQuiz(dataRequest);

        // Assert
        Assert.IsNotNull(result.Result);
        Assert.AreNotEqual(0, result.Result.QuizId);
    }


    [TestMethod]
    public void SubmitQuiz()
    {
        // Arrange
        var dataRequest = new SaveQuizRequest()
        {
            QuizId = 0,
            UserId = 24,
            GroupId = 2,
            Questions = new List<QuestionRequest>()
            {
                new()
                {
                    QuestionId = 6,
                    SelectedChoiceId = 24
                },
                new()
                {
                    QuestionId = 7,
                    SelectedChoiceId = 27
                },
                new()
                {
                    QuestionId = 8,
                    SelectedChoiceId = 31
                },
                new()
                {
                    QuestionId = 9,
                    SelectedChoiceId = 33
                },
                new()
                {
                    QuestionId = 10,
                    SelectedChoiceId = 39
                }
            }
        };

        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        // Act
        using var context = new DatabaseContext(configuration);
        var service = new QuizService(context);
        var result = service.SubmitQuiz(dataRequest);

        // Assert
        Assert.IsNotNull(result.Result);
        Assert.AreNotEqual(0, result.Result.QuizId);
    }
}