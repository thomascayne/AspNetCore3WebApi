using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AspNetCoreWebApi
{
  public class Startup
  {
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    /// <summary>
    /// The ConfigureServices method gets called by the runtime.Use this method to add services to the container.
    /// </summary>
    /// <param name="services"></param>
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();

      services.AddSwaggerGen(config => config.SwaggerDoc("v1", new OpenApiInfo { Title = "Thomas Cayne Web Api v1.0.0", Version = "v1" }));

    }


    /// <summary>
    /// The Configure method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {

      //var dbName = Configuration.GetSection("SQLDATABASENAME");

      //Debug.WriteLine("\n\n\n\n--------->", dbName);

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseSwagger();

      app.UseSwaggerUI(config =>
      {
        config.SwaggerEndpoint("/swagger/v1/swagger.json", "Thomas Cayne Web Api v1.0.0");
      });

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
