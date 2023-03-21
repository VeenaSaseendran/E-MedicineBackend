using E_MedicineBackend.Models;
using E_MedicineBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_MedicineBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        //private readonly SignInManager<IdentityUser> signInManager;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
            //this.signInManager = signInManager;
        }
        [HttpPost("BookOrder")]
        public IActionResult BookOrder(Orders order)
        {
            Orders neworder = new Orders();
            if (ModelState.IsValid)
            {
                neworder = _orderService.Create(order);
            }
            return Ok(neworder);
        }
        [HttpGet("GetAllOrders")]
        public IActionResult GetAll()
        {
            var orders = _orderService.GetAll();
            return Ok(orders);

        }
        [HttpGet("GetAllByUserId")]
        public IActionResult GetAllByUserId(int UserId)
        {
            var order = _orderService.GetByUserId(x => x.UserId == UserId);
            return Ok(order);

        }
        [HttpDelete("CancelOrder")]
        public IActionResult CancelOrder([FromQuery] int Id)
        {
            _orderService.Delete(Id);
            return Ok();
        }
    }
}
