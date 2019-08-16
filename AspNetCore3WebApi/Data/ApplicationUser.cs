using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore3WebApi.Data
{
  public class ApplicationUser : IdentityUser
  {
    public string FirstName { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsConfirmed { get; set; }
    public string LastName { get; set; }
  }
}
