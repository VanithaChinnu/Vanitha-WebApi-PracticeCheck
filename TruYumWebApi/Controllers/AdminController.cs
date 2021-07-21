using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles="Admin")]
    public class AdminController : ControllerBase
    {
        IMenuItemRepository menuItemRep;
        public AdminController(IMenuItemRepository imir)
        {
            menuItemRep = imir;
        }
        [HttpGet]
        public async Task<ActionResult<List<MenuItem>>> GetAllMenuItems()
        {
            return Ok(await menuItemRep.GetAllMenuItems());
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMenuItem(int id, MenuItem menuItem)
        {
            await menuItemRep.UpdateMenuItem(id, menuItem);
            return Ok();
        }
    }
}
