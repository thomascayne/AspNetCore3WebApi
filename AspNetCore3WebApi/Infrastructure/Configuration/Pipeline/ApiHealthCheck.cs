using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCore3WebApi.Infrastructure.Configuration.Pipeline
{
  public class ApiHealthCheckMiddleware
  {

    private string apiHealthCheckResponse = "";
    private readonly RequestDelegate next;
    private readonly string path;

    public ApiHealthCheckMiddleware(RequestDelegate _next, string _path)
    {
      next = _next;
      path = _path;
    }


    public async Task InvokeAsync(HttpContext httpContext)
    {
      /*
       * Check it thee requested path (endpoint) matches the configured endpoint (path)
       */

      if (httpContext.Request.Path.Value.ToLower() == path.ToLower())
      {

        if (IsApplicationHealthy())
        {

          httpContext.Response.StatusCode = 200;

          apiHealthCheckResponse = JsonSerializer.Serialize(new { alive = true, message = "Web api is running Ok!" });

          await httpContext.Response.WriteAsync(apiHealthCheckResponse);
        }
        else
        {
          httpContext.Response.StatusCode = 503;
          apiHealthCheckResponse = JsonSerializer.Serialize(new { alive = false, message = "Web api is NOT running Ok!" });
          await httpContext.Response.WriteAsync(apiHealthCheckResponse);
        }
      }
      else
      {
        await next(httpContext);
      }
    }

    private bool IsApplicationHealthy()
    {
      return true;
    }
  }

  public static class ApiHealthCheckServiceExtension
  {
    public static IApplicationBuilder UseApiHealthCheck(this IApplicationBuilder builder, string _path)
    {
      return builder.UseMiddleware<ApiHealthCheckMiddleware>(_path);

    }
  }
}
