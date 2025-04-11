using Company.G04.DAl.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MVC._3.PL.Dtos;

namespace MVC._3.PL.Controllers
{
    public class AccountController : Controller

        

    {
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager)
        {
           _userManager = userManager;
        }

        #region SignUp

        [HttpGet]
        public IActionResult SignUp() 
        {
        
          return View();
        
        }


        // P@ssW0rd

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDto model)      
        {
            if (ModelState.IsValid)// server side validation 
            {

                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user is null) 
                {
                   user= await  _userManager.FindByEmailAsync(model.Email);


                    if (user is null) 
                    {
                        user = new AppUser()
                        {

                            UserName = model.UserName,
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            Email = model.Email,
                            IsAgree = model.IsAgree,


                        };

                        var result = await _userManager.CreateAsync(user, model.Password);
                        if (result.Succeeded)
                        {

                            return RedirectToAction("SignIn");
                        }
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);

                        }

                    }
                
                }
                ModelState.AddModelError("", "InValid SignUp !!");
         

            }

            return View();

        }



        #endregion

        #region SignIn



        #endregion


        #region SignOut




        #endregion

    }
}
