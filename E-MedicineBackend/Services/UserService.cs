using E_MedicineBackend.EntityFrameWork;
using E_MedicineBackend.Models;
using E_MedicineBackend.ViewModels;
using System.Linq.Expressions;

namespace E_MedicineBackend.Services
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _applicationDbContext;

        public UserService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public User Delete(int id)
        {
            User user = _applicationDbContext.Users.Find(id);
            if (user != null)
            {
                _applicationDbContext.Users.Remove(user);
                _applicationDbContext.SaveChanges();
            }
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return _applicationDbContext.Users;
        }

        public User GetById(int id)
        {
            User user = _applicationDbContext.Users.Find(id);
            return user;
        }

        public User Register(User user)
        {
            _applicationDbContext.Users.Add(user);
            _applicationDbContext.SaveChanges();
            return user;
        }
        public IQueryable<User> Login(Expression<Func<User, bool>> predicate)
        {
            IQueryable<User> user = _applicationDbContext.Users.Where(predicate);

            return user;
        }
        public User Update(int id, User userChanges)
        {
            var user = _applicationDbContext.Users.Attach(userChanges);
            user.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _applicationDbContext.SaveChanges();
            return userChanges;
        }
    }
}
