using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Filters;

namespace quiz_api.Services.ActionFilters;

public class LogTransactionAttribute : ActionFilterAttribute
{
    IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());

    private readonly ILogger _logger;

    public LogTransactionAttribute(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger("LoggingRequest");
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var request = context.HttpContext.Request;
        var IPAddress =
            Convert.ToString(ipHostInfo.AddressList.FirstOrDefault(address =>
                address.AddressFamily == AddressFamily.InterNetwork));
        var requestLog =
            Environment.NewLine +
            "    Request: " + DateTime.Now.ToString("R") + Environment.NewLine +
            "    " + request.Method + ": " + request.Path + Environment.NewLine +
            "    Params: " + JsonSerializer.Serialize(context.ActionArguments?.Values.FirstOrDefault()) + Environment.NewLine +
            "    IP Address: " + IPAddress + Environment.NewLine +
            "    User Agent: " + context.HttpContext.Request.Headers.UserAgent + Environment.NewLine + "    ";
        _logger.LogInformation(requestLog);
    }
}