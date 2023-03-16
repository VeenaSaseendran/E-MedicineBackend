using E_MedicineBackend.Models;
using E_MedicineBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_MedicineBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderItemsController : Controller
    {
        private IOrderItemsService _orderItemsService;
        //private readonly SignInManager<IdentityUser> signInManager;
        public OrderItemsController(IOrderItemsService orderItemsService)
        {
            _orderItemsService = orderItemsService;
            //this.signInManager = signInManager;
        }
        [HttpPost("BookOrder")]
        public IActionResult BookOrder(OrderItems orderItems)
        {
            OrderItems neworderitems = new OrderItems();
            if (ModelState.IsValid)
            {
                neworderitems = _orderItemsService.Create(orderItems);
            }
            return Ok(neworderitems);
        }
        [HttpGet("GetAllByOrderId")]
        public IActionResult GetAllByOrderId(int OrderId)
        {
            var orderItems = _orderItemsService.GetByOrderId(x => x.OrderId == OrderId);
            return Ok(orderItems);

        }
        [HttpDelete("DeleteOrderItems")]
        public IActionResult DeleteOrderItems(int Id)
        {
            _orderItemsService.Delete(Id);
            return Ok();
        }
    }
}
