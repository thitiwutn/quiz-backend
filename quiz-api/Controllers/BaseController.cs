using Microsoft.AspNetCore.Mvc;
using quiz_api.Services.ActionFilters;

namespace quiz_api.Controllers;

[ApiController]
[ServiceFilter(typeof(LogTransactionAttribute))]
[Route("api/[controller]")]
public class BaseController : Controller
{
    public BaseController()
    {
    }
}