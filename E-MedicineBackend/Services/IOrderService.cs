using E_MedicineBackend.Models;
using System.Linq.Expressions;

namespace E_MedicineBackend.Services
{
    public interface IOrderService
    {
        IEnumerable<Orders> GetAll();
        Orders GetById(int id);
        IQueryable<Orders> GetByUserId(Expression<Func<Orders, bool>> predicate);
        Orders Create(Orders orders);
        Orders Update(int id, Orders orders);
        Orders Delete(int id);
    }
}
