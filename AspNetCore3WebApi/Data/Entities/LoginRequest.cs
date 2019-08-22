using System.ComponentModel.DataAnnotations;

namespace AspNetCore3WebApi.Data.Entities
{
  public class LoginRequest
  {
    [Required(ErrorMessage = "Username is required")]
    public string Password { get; set; }
    [Required(ErrorMessage = "Password is required")]
    public string Username { get; set; }
  }
}
