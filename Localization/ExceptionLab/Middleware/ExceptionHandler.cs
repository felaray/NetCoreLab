using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExceptionLab.Middleware
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;

        private ILogger<ExceptionHandler> _logger;
        public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex) when (ex.InnerException is SqlException)
            {
                var info = ex.InnerException as SqlException;
                _logger.LogError($"{info.Number},{info.Message}");

                throw ex;
            }
        }
    }
}
