using AspNetCoreWebApi.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWebApi.Controllers.Users
{
  [ApiController]
  [ApiVersion("1.0")]
  [Route("api/v{version:apiVersion}/[controller]")]
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
