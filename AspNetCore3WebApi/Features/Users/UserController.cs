using AspNetCore3WebApi.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCore3WebApi.Features.Users
{
  [ApiController]
  [Authorize]
  [Route("api")]
  public class UserController : ControllerBase
  {
    private readonly ApplicationDbContext dbContext;

    public UserController(ApplicationDbContext dbContext)
    {
      this.dbContext = dbContext;
    }

    [HttpGet()]
    [Route("users")]
    public IEnumerable<string> Get()
    {
      return dbContext.Users.Select(user => user.UserName).ToArray();
    }

  }
}
