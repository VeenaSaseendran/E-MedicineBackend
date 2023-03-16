using E_MedicineBackend.Models;
using System.Linq.Expressions;

namespace E_MedicineBackend.Services
{
    public interface IOrderItemsService
    {
        IEnumerable<OrderItems> GetAll();
        OrderItems GetById(int id);
        IQueryable<OrderItems> GetByOrderId(Expression<Func<OrderItems, bool>> predicate);
        OrderItems Create(OrderItems orderItems);
        OrderItems Update(int id, OrderItems orderItems);
        OrderItems Delete(int id);
    }
}
