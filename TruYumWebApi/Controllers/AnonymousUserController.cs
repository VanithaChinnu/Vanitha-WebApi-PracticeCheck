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
    public class AnonymousUserController : ControllerBase
    {
        IMenuItemRepository menuItemRep;
        public AnonymousUserController(IMenuItemRepository imir)
        {
            menuItemRep = imir;
        }
        [HttpGet]
        public async Task<ActionResult<List<MenuItem>>> GetAllMenuItems()
        {
            return Ok(await menuItemRep.GetAllMenuItems());
        }
    }
}
