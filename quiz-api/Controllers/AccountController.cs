using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using quiz_api.Services;
using quiz_api.Services.ActionFilters;
using quiz_api.Services.Models;
using quiz_api.Services.Models.Request;
using quiz_api.Services.Models.Response;

namespace quiz_api.Controllers;

public class AccountController : BaseController
{
    private AccountService _accountService;
    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger, AccountService accountService)
    {
        _logger = logger;
        _accountService = accountService;
    }

    [HttpGet("User")]
    public ActionResult<ApiResponse<UserResponse>> GetUser(string userName)
    {
        var response = new ApiResponse<UserResponse>();
        try
        {
            var user = _accountService.GetUser(userName);
            response.Data = user.Result;
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

    [HttpPost("User")]
    public async Task<ActionResult<ApiResponse<UserResponse>>> CreateUser(CreateUser createUser)
    {
        var response = new ApiResponse<UserResponse>();
        try
        {
            var user = await _accountService.CreateUser(createUser);
            response.Data = user;
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