using AspNetCore3WebApi.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore3WebApi.Data.Seed
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
          Id = Guid.NewGuid().ToString(),
          Email = "tcayne@hotmail.com",
          EmailConfirmed = true,
          FirstName = "Thomas",
          IsAdmin = true,
          LastName = "Cayne",
          SecurityStamp = Guid.NewGuid().ToString(),
          UserName = "vanchisel"
        };

        userManager.CreateAsync(user, "Password@@Th0717#$@");
      }
    }
  }
}
