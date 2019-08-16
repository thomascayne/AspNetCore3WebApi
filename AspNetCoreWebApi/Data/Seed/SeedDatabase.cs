using AspNetCoreWebApi.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApi.Data.Seed
{
  public class SeedDatabase
  {
    public static void Initialize(IServiceProvider serviceProvider)
    {
      var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
      var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

      context.Database.EnsureCreated();

      if (!context.Users.Any())
      {
        ApplicationUser user = new ApplicationUser()
        {
          Email = "tcayne@hotmail.com",
          Id = Guid.NewGuid().ToString(),
          SecurityStamp = Guid.NewGuid().ToString(),
          UserName = "vanchisel"
        };

        userManager.CreateAsync(user, "Password@@Th0717#$@");
      }
    }
  }
}
