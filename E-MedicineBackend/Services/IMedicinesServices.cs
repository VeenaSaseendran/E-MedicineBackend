using E_MedicineBackend.Models;

namespace E_MedicineBackend.Services
{
    public interface IMedicinesServices
    {
        IEnumerable<Medicines> GetAll();
        Medicines GetById(int id);
        Medicines Create(Medicines medicines);
        Medicines Update(int id, Medicines medicines);
        Medicines Delete(int id);
    }
}
