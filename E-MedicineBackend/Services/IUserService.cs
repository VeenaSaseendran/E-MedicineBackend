using E_MedicineBackend.Models;
using E_MedicineBackend.ViewModels;
using System.Linq.Expressions;

namespace E_MedicineBackend.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        IQueryable<User> Login(Expression<Func<User, bool>> predicate);
        User Register(User user);

        User Update(int id, User user);
        User Delete(int id);
    }
}
