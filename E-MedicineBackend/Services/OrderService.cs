using E_MedicineBackend.EntityFrameWork;
using E_MedicineBackend.Models;
using System.Linq.Expressions;

namespace E_MedicineBackend.Services
{
    public class OrderService : IOrderService
    {
        private ApplicationDbContext _applicationDbContext;

        public OrderService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public Orders Create(Orders orders)
        {
            _applicationDbContext.Orders.Add(orders);
            _applicationDbContext.SaveChanges();
            return orders;
        }

        public Orders Delete(int id)
        {
            Orders order = _applicationDbContext.Orders.Find(id);
            if (order != null)
            {
                _applicationDbContext.Orders.Remove(order);
                _applicationDbContext.SaveChanges();
            }
            return order;
        }

        public IEnumerable<Orders> GetAll()
        {
            return _applicationDbContext.Orders;
        }

        public Orders GetById(int id)
        {
            Orders order = _applicationDbContext.Orders.Find(id);
            return order;
        }
        public IQueryable<Orders> GetByUserId(Expression<Func<Orders, bool>> predicate)
        {
            IQueryable<Orders> orders = _applicationDbContext.Orders.Where(predicate);

            return orders;
        }
        public Orders Update(int id, Orders orderschanges)
        {
            var order = _applicationDbContext.Orders.Attach(orderschanges);
            order.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _applicationDbContext.SaveChanges();
            return orderschanges;
        }
    }
}
