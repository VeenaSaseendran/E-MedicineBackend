using E_MedicineBackend.Models;

namespace E_MedicineBackend.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetById(int id);

        User Register(User user);

        User Update(int id, User user);
        User Delete(int id);
    }
}
