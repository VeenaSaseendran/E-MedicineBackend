using E_MedicineBackend.EntityFrameWork;
using E_MedicineBackend.Models;

namespace E_MedicineBackend.Services
{
    public class MedicinesService : IMedicinesServices
    {
        private ApplicationDbContext _applicationDbContext;

        public MedicinesService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public Medicines Create(Medicines medicines)
        {
            _applicationDbContext.Medicines.Add(medicines);
            _applicationDbContext.SaveChanges();
            return medicines;
        }

        public Medicines Delete(int id)
        {
            Medicines medicines = _applicationDbContext.Medicines.Find(id);
            if (medicines != null)
            {
                _applicationDbContext.Medicines.Remove(medicines);
                _applicationDbContext.SaveChanges();
            }
            return medicines;
        }

        public IEnumerable<Medicines> GetAll()
        {
            return _applicationDbContext.Medicines;
        }

        public Medicines GetById(int id)
        {
            Medicines medicines = _applicationDbContext.Medicines.Find(id);
            return medicines;
        }

        public Medicines Update(int id, Medicines medicinesChanges)
        {
            var medicines = _applicationDbContext.Medicines.Attach(medicinesChanges);
            medicines.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _applicationDbContext.SaveChanges();
            return medicinesChanges;
        }
    }
}
