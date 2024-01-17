using Microsoft.AspNetCore.Mvc;
using quiz_api.Services;
using quiz_api.Services.Models;

namespace quiz_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupController : Controller
{
    private GroupService _groupService;
    private readonly ILogger<GroupController> _logger;

    public GroupController(ILogger<GroupController> logger, GroupService groupService)
    {
        _logger = logger;
        _groupService = groupService;
    }
    
    [HttpGet("")]
    public async Task<ActionResult<GroupModel>> GetUser(string userName)
    {
        var groups = await _groupService.GetGroups();
        return Ok(groups);
    }
}