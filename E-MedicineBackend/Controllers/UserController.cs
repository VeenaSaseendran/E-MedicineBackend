using E_MedicineBackend.Models;
using E_MedicineBackend.Services;
using E_MedicineBackend.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;

namespace E_MedicineBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        //private readonly SignInManager<IdentityUser> signInManager;
        public UserController(IUserService userService)
        {
            _userService = userService;
            //this.signInManager = signInManager;
        }
        
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var users =  _userService.GetAll();
            return Ok(users);

        }
        [HttpGet("GetByUserId")]
        public IActionResult GetByUserId(int Id)
        {
            User user = _userService.GetById(Id);
            return Ok(user);
        }
        [HttpPost("Register")]
        public IActionResult Register(User user)
        {
            User newuser = new User();
            if (ModelState.IsValid)
            {
                newuser = _userService.Register(user);
            }
            return Ok(newuser);
        }
        //[HttpPost]
        //public async Task<User> Authenticate(LoginViewModel model)
        //{
        //    //var user = await Task.Run(() => _users.SingleOrDefault(x => x.Username == username && x.Password == password));
        //    var result= await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
        //    if (result.Succeeded)
        //    {
        //        var user = await Task.Run(() => _userService.GetAll().SingleOrDefault(x => x.Email == model.Email && x.Password == model.Password));
        //        return user;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //    ;

        //}

    }
}
