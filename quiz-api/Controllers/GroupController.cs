using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using quiz_api.Services;
using quiz_api.Services.Models;

namespace quiz_api.Controllers;
public class GroupController : BaseController
{
    private GroupService _groupService;
    private readonly ILogger<GroupController> _logger;

    public GroupController(ILogger<GroupController> logger, GroupService groupService)
    {
        _logger = logger;
        _groupService = groupService;
    }
    
    [HttpGet("")]
    public ActionResult<ApiResponse<ICollection<GroupModel>>> GetGroup()
    {
        var response = new ApiResponse<ICollection<GroupModel>>();
        try
        {
            var data = _groupService.GetGroups();
            response.Data = data.Result;
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