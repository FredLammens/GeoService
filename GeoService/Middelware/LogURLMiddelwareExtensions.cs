using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoService.Middelware
{
    public static class LogURLMiddelwareExtensions
    {
        /// <summary>
        /// Extension method to simplify use of middelware
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseLogMiddelware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogURLMiddelware>();
        }
    }
}
