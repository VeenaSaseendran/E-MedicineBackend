using E_MedicineBackend.Models;
using E_MedicineBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_MedicineBackend.Controllers
{
    public class MedicinesController : Controller
    {
        private IMedicinesServices _medicineService;
        //private readonly SignInManager<IdentityUser> signInManager;
        public MedicinesController(IMedicinesServices medicineService)
        {
            _medicineService = medicineService;
            //this.signInManager = signInManager;
        }
        [HttpGet("GetById")]
        public IActionResult GetById(int Id)
        {
            Medicines medicine = _medicineService.GetById(Id);
            return Ok(medicine);
        }
        [HttpPost("AddMedicine")]
        public IActionResult AddMedicine([FromBody]  Medicines medicines)
        {
            Medicines newmedicine = new Medicines();
            if (ModelState.IsValid)
            {
                newmedicine = _medicineService.Create(medicines);
            }
            return Ok(newmedicine);
        }
        [HttpGet("GetAllMedicines")]
        public IActionResult GetAllMedicines()
        {
            var mediciens =_medicineService.GetAll();
            return Ok(mediciens); ;

        }
        [HttpDelete("Delete")]
        public IActionResult Delete( int Id)
        {
           _medicineService.Delete(Id);
            return Ok();
        }
    }
}
