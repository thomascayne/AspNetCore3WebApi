using AspNetCore3WebApi.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCore3WebApi.Features.Users
{
  [ApiController]
  [Route("api")]
  public class UserController : ControllerBase
  {
    private ApplicationDbContext dbContext;

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
