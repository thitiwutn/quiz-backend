using Microsoft.AspNetCore.Mvc;
using quiz_api.Services;
using quiz_api.Services.Models.Request;
using quiz_api.Services.Models.Response;

namespace quiz_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuizController : Controller
{
    private QuizService _quizService;
    private readonly ILogger<QuizController> _logger;

    public QuizController(ILogger<QuizController> logger, QuizService quizService)
    {
        _logger = logger;
        _quizService = quizService;
    }

    // get quiz by username
    [HttpGet("")]
    public async Task<ActionResult<QuizResponse>> GetQuiz(string userName)
    {
        var quizResponse = await _quizService.GetQuiz(userName);
        return Ok(quizResponse);
    }

    // post for save draft
    [HttpPost("Save")]
    public async Task<ActionResult<QuizResultResponse>> SaveDraft(SaveQuizRequest model)
    {
        var data = await _quizService.SaveQuiz(model);
        return Ok(data);
    }

    // post for submit
    [HttpPost("Submit")]
    public async Task<ActionResult<QuizResultResponse>> Submit(SaveQuizRequest model)
    {
        var data = await _quizService.SubmitQuiz(model);
        return Ok(data);
    }

    // get for get result
    [HttpGet("Result")]
    public async Task<ActionResult<QuizResultResponse>> GetResult(int quizId)
    {
        var data = await _quizService.GetQuizResult(quizId);
        return Ok(data);
    }
}