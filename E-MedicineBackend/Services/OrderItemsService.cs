using E_MedicineBackend.EntityFrameWork;
using E_MedicineBackend.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace E_MedicineBackend.Services
{
    public class OrderItemsService : IOrderItemsService
    {
        private ApplicationDbContext _applicationDbContext;

        public OrderItemsService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public OrderItems Create(OrderItems orderItems)
        {
            _applicationDbContext.OrderItems.Add(orderItems);
            _applicationDbContext.SaveChanges();
            return orderItems;
        }

        public OrderItems Delete(int id)
        {
            OrderItems orderItems = _applicationDbContext.OrderItems.Find(id);
            if (orderItems != null)
            {
                _applicationDbContext.OrderItems.Remove(orderItems);
                _applicationDbContext.SaveChanges();
            }
            return orderItems;
        }

        public IEnumerable<OrderItems> GetAll()
        {
            return _applicationDbContext.OrderItems;
        }

        public OrderItems GetById(int id)
        {
            OrderItems orderItems = _applicationDbContext.OrderItems.Find(id);
            return orderItems;
        }
        public IQueryable<OrderItems> GetByOrderId(Expression<Func<OrderItems, bool>> predicate)
        {
            IQueryable<OrderItems> orderItems = _applicationDbContext.OrderItems.Where(predicate);
            
            return orderItems;
        }
        public OrderItems Update(int id, OrderItems orderItemsChanges)
        {
            var orderItems = _applicationDbContext.OrderItems.Attach(orderItemsChanges);
            orderItems.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _applicationDbContext.SaveChanges();
            return orderItemsChanges;
        }
    }
}
