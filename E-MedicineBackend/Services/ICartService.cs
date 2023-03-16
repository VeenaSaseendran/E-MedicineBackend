using E_MedicineBackend.Models;
using System.Linq.Expressions;

namespace E_MedicineBackend.Services
{
    public interface ICartService
    {
        IEnumerable<Cart> GetAll();
        Cart GetById(int id);
        IQueryable<Cart> GetByUserId(Expression<Func<Cart, bool>> predicate);
        Cart Create(Cart cart);
        Cart Update(int id, Cart cart);
        Cart Delete(int id);
    }
}
