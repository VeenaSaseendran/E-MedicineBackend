using E_MedicineBackend.Models;
using E_MedicineBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_MedicineBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private ICartService _cartService;
        //private readonly SignInManager<IdentityUser> signInManager;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
            //this.signInManager = signInManager;
        }
        [HttpPost("AddtoCart")]
        public IActionResult AddtoCart(Cart cart)
        {
            Cart newcart = new Cart();
            if (ModelState.IsValid)
            {
                newcart = _cartService.Create(cart);
            }
            return Ok(newcart);
        }
        [HttpGet("GetAllByUserId")]
        public IActionResult GetAllByUserId(int UserId)
        {
            var order = _cartService.GetByUserId(x => x.UserId == UserId);
            return Ok(order);

        }
        [HttpDelete("DeleteCart")]
        public IActionResult Delete(int Id)
        {
            _cartService.Delete(Id);
            return Ok();
        }

    }
}
