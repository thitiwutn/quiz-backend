using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using quiz_api.Services;
using quiz_api.Services.Models;
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
    public async Task<ActionResult<ApiResponse<QuizResponse>>> GetQuiz(int userId)
    {
        var response = new ApiResponse<QuizResponse>();
        try
        {
            var data = await _quizService.GetQuiz(userId);
            response.Data = data;
        }
        catch (Exception ex) when (ex is ValidationException or AggregateException)
        {
            // Handle both ValidationException and AggregateException here
            response.Success = false;
            response.ErrorMessage = ex.InnerException!.Message;
        }
        catch (Exception ex)
        {
            // Log other unexpected exceptions
            _logger.LogError(ex.Message);
            response.Success = false;
            response.ErrorMessage = "An unexpected error occurred.";
        }

        return Ok(response);
    }

    // post for save draft
    [HttpPost("Save")]
    public async Task<ActionResult<ApiResponse<SaveQuizResponse>>> SaveDraft(SaveQuizRequest model)
    {
        var response = new ApiResponse<SaveQuizResponse>();
        try
        {
            var data = await _quizService.SaveQuiz(model);
            response.Data = data;
        }
        catch (Exception ex) when (ex is ValidationException or AggregateException)
        {
            // Handle both ValidationException and AggregateException here
            response.Success = false;
            response.ErrorMessage = ex.InnerException!.Message;
        }
        catch (Exception ex)
        {
            // Log other unexpected exceptions
            _logger.LogError(ex.Message);
            response.Success = false;
            response.ErrorMessage = "An unexpected error occurred.";
        }

        return Ok(response);
    }

    // post for submit
    [HttpPost("Submit")]
    public async Task<ActionResult<ApiResponse<SaveQuizResponse>>> Submit(SaveQuizRequest model)
    {
        var response = new ApiResponse<SaveQuizResponse>();
        try
        {
            var data = await _quizService.SubmitQuiz(model);
            response.Data = data;
        }
        catch (Exception ex) when (ex is ValidationException or AggregateException)
        {
            // Handle both ValidationException and AggregateException here
            response.Success = false;
            response.ErrorMessage = ex.InnerException!.Message;
        }
        catch (Exception ex)
        {
            // Log other unexpected exceptions
            _logger.LogError(ex.Message);
            response.Success = false;
            response.ErrorMessage = "An unexpected error occurred.";
        }

        return Ok(response);
    }

    // get for get result
    [HttpGet("Result")]
    public async Task<ActionResult<ApiResponse<QuizResultResponse>>> GetResult(int userId)
    {
        var response = new ApiResponse<QuizResultResponse>();
        try
        {
            var data = await _quizService.GetQuizResult(userId);
            response.Data = data;
        }
        catch (Exception ex) when (ex is ValidationException)
        {
            // Handle both ValidationException
            response.Success = false;
            response.ErrorMessage = ex.Message;
        }
        catch (Exception ex)
        {
            // Log other unexpected exceptions
            _logger.LogError(ex.Message);
            response.Success = false;
            response.ErrorMessage = "An unexpected error occurred.";
        }

        return Ok(response);
    }
}