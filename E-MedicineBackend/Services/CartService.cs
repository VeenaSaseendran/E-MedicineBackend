using E_MedicineBackend.EntityFrameWork;
using E_MedicineBackend.Models;
using System.Linq.Expressions;

namespace E_MedicineBackend.Services
{
    public class CartService : ICartService
    {
        private ApplicationDbContext _applicationDbContext;

        public CartService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public Cart Create(Cart cart)
        {
            _applicationDbContext.Cart.Add(cart);
            _applicationDbContext.SaveChanges();
            return cart;
        }

        public Cart Delete(int id)
        {
            Cart cart = _applicationDbContext.Cart.Find(id);
            if (cart != null)
            {
                _applicationDbContext.Cart.Remove(cart);
                _applicationDbContext.SaveChanges();
            }
            return cart;
        }

        public IEnumerable<Cart> GetAll()
        {
            return _applicationDbContext.Cart;
        }

        public Cart GetById(int id)
        {
            Cart cart = _applicationDbContext.Cart.Find(id);
            return cart;
        }
        public IQueryable<Cart> GetByUserId(Expression<Func<Cart, bool>> predicate)
        {
            IQueryable<Cart> cart = _applicationDbContext.Cart.Where(predicate);

            return cart;
        }
        public Cart Update(int id, Cart cartChanges)
        {
            var cart = _applicationDbContext.Cart.Attach(cartChanges);
            cart.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _applicationDbContext.SaveChanges();
            return cartChanges;
        }
    }
}
