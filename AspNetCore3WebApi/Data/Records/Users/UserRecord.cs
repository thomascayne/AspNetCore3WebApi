using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore3WebApi.Data.Records
{
  public abstract class UserRecord
  {
    public string Email { get; set; }
    public bool EmailConfirmed { get; set; }
    public string FirstName { get; set; }

    [Key]
    public string Id { get; set; }
    public bool IsAdmin { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public string Username { get; set; }

  }
}
