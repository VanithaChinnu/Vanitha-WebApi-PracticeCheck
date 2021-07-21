using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruYumRepository;

namespace TruYumWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepository userRep;
        public UserController(IUserRepository iur)
        {
            userRep = iur;
        }
        [HttpGet]
        public async Task<ActionResult<bool>> ValidateUser(string userId, [FromBody] string pwd)
        {
            return Ok(await userRep.ValidateUser(userId, pwd));
        }
        [HttpPost]
        public async Task<ActionResult> InsertUser(User user)
        {
            await userRep.InsertUser(user);
            return Created($"api/User/{user.UserId}", user);
        }
    }
}
