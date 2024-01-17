using Microsoft.AspNetCore.Mvc;
using quiz_api.Services;
using quiz_api.Services.Models.Request;
using quiz_api.Services.Models.Response;

namespace quiz_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : Controller
{
    private AccountService _accountService;
    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger, AccountService accountService)
    {
        _logger = logger;
        _accountService = accountService;
    }

    [HttpGet("User")]
    public async Task<ActionResult<UserResponse>> GetUser(string userName)
    {
        var user = await _accountService.GetUser(userName);
        return Ok(user);
    }

    [HttpPost("User")]
    public async Task<ActionResult<UserResponse>> CreateUser(CreateUser createUser)
    {
        var user = await _accountService.CreateUser(createUser);
        return Ok(user);
    }

    // [HttpPost("User"), HttpGet("User")]
    // public async Task<ActionResult<UserResponse>> UserManage(CreateUser model)
    // {
    //     switch (HttpContext.Request.Method)
    //     {
    //         case "GET":
    //         {
    //             var user = await _accountService.GetUser(model.Name);
    //             return Ok(user);
    //         }
    //         case "POST":
    //         {
    //             var user = await _accountService.CreateUser(model);
    //             return Ok(user);
    //         }
    //         default:
    //             return BadRequest();
    //     }
    // }
}