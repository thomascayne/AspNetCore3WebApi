using System.ComponentModel.DataAnnotations;

namespace AspNetCore3WebApi.Data.Model
{
  public class LoginRequest
  {
    [Required(ErrorMessage = "Password is required")]
    [StringLength(30, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 30 characters.")]
    public string Password { get; set; }

    [Required(ErrorMessage = "Username is required")]
    [StringLength(30, MinimumLength = 8, ErrorMessage = "Username must be between 8 and 30 characters.")]
    public string Username { get; set; }
  }
}
