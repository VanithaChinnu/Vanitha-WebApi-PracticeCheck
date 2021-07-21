using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles="Customer")]
    public class CustomerController : ControllerBase {
        IMenuItemRepository menuItemRep;
        ICartRepository cartRep;
        public CustomerController(IMenuItemRepository imir, ICartRepository icr) {
            menuItemRep = imir;
            cartRep = icr;
        }
        [HttpGet]
        public async Task<ActionResult<List<MenuItem>>> GetAllMenuItems() {
            List<MenuItem> menuItems = await menuItemRep.GetAllMenuItems();
            var items = from mi in menuItems where mi.Active && mi.DateOfLaunch <= DateTime.Now select mi;
            return Ok(items);
        }
        [HttpGet("{userId}")]
        public async Task<ActionResult<List<MenuItem>>> Get(int userId) {
            try {
                return Ok(await cartRep.GetItemsByUserId(userId));
            }
            catch (TruYumException ex) {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Cart cart) {
            await cartRep.InsertCart(cart);
            return Created($"api/Customer/{cart.UserId}", cart);
        }
        [HttpDelete("{userId}/{miId}")]
        public async Task<ActionResult> Delete(int userId, int miId) {
            await cartRep.DeleteCart(userId, miId);
            return Ok();
        }
    }
}
