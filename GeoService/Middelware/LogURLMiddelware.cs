using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GeoService.Middelware
{
    public class LogURLMiddelware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public LogURLMiddelware(RequestDelegate next,  ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.AddFile("GeoSericeLogs.txt").CreateLogger("GeoService");//<LogURLMiddelware>
        }
        public async Task Invoke(HttpContext context) 
        {
            try
            {
                await _next(context);
            }
            finally 
            {
                _logger.LogInformation(
                    "Request {method} {url} at {time}=> {statusCode}",
                    context.Request?.Method,
                    context.Request?.Path.Value,
                    DateTime.Now,
                    context.Response?.StatusCode
                    );
            }
        }
    }
}
