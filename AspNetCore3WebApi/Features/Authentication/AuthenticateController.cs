using AspNetCore3WebApi.Data;
using AspNetCore3WebApi.Data.Entities;
using AspNetCore3WebApi.Service;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Threading;

namespace AspNetCore3WebApi.Features.Authentication
{
  [Route("api")]
  public class AuthenticateController : ControllerBase
  {
    private readonly UserManager<ApplicationUser> appUserManager;

    public AuthenticateController(UserManager<ApplicationUser> userManager)
    {
      appUserManager = userManager;
    }

    [HttpPost]
    [Route("authenticate/login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
      var user = await appUserManager.FindByNameAsync(request.Username);
      var pwd = await appUserManager.CheckPasswordAsync(user, request.Password);

      if (user != null && pwd)
      {
        Ulid ulid = Ulid.NewUlid();

        var authenticateClaims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, ulid.ToString())
        };

        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Make sure the secure key not short or it will throw a runtime exception of IDX10603 HS256 SecurityKey/KeySize"));

        var token = new JwtSecurityToken(
          issuer: "https://www.slashand.com",
          audience: "https://www.slashand.com",
          expires: DateTime.UtcNow.AddDays(367),
          claims: authenticateClaims,
          signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
          );

        return Ok(new
        {
          token = new JwtSecurityTokenHandler().WriteToken(token),
          expiration = token.ValidTo,
        });

      }

      return Unauthorized();
    }
  }
}