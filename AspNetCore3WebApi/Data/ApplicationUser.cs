using Microsoft.AspNetCore.Identity;

namespace AspNetCore3WebApi.Data
{
  public class ApplicationUser : IdentityUser
  {
    public string FirstName { get; set; }
    public bool IsAdmin { get; set; }
    public string LastName { get; set; }

    public static implicit operator ApplicationUser(ApplicationUser v)
    {
      throw new NotImplementedException();
    }
  }
}
