﻿using Company.G04.DAl.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using MVC._3.PL.Dtos;
using MVC._3.PL.Helpers;
using Email = MVC._3.PL.Helpers.Email;

namespace MVC._3.PL.Controllers
{
    public class AccountController : Controller

        

    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
           _userManager = userManager;
            _signInManager = signInManager;
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
        [HttpGet]
        public IActionResult SignIn() 
        
        {
            return View();
        
        }


        [HttpPost]
        public async Task<IActionResult> SignIn(SignInDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user is not null)
                {
                    var flag = await _userManager.CheckPasswordAsync(user, model.Password);
                    if (flag)
                    {

                       var result=await  _signInManager.PasswordSignInAsync(user,model.Password,model.RememberMe,false);
                        if (result.Succeeded) 
                        {
                            return RedirectToAction(nameof(HomeController.Index), "Home");

                        }
                        // You might also want to actually sign the user in with SignInManager here
                       
                    }
                }

                ModelState.AddModelError("", "Invalid Login !!");
            }

            return View(model);
        }






        #endregion


        #region SignOut

        [HttpGet]
        public new async  Task<IActionResult> SignOut()
        {

            await _signInManager.SignOutAsync();

           return RedirectToAction(nameof(SignIn));

        }




        #endregion

        #region ForgetPassword

        [HttpGet]
        public IActionResult ForgetPassword() 
        {

            return View();
        
        
        }


        [HttpPost]
        public async Task<IActionResult> SendResetPaassowrdUrl(ForgetPasswordDto model )
        {

            if (ModelState.IsValid) 
            {

               var user=await  _userManager.FindByEmailAsync(model.Email);

                if (user is not null) 
                {
                    // generate token 
                  var  token=await _userManager.GeneratePasswordResetTokenAsync(user);

                    // creat Url
                    //https://localhost:7091/Account/ResetPassword

                    var url= Url.Action("ResetPassword","Account",new {email=model.Email,token },Request.Scheme);

                    // create Eamil 
                    var email = new Email() 
                    {
                    To=model.Email,
                    Subject="Reset Password ",
                    Body= url

                    
                    
                    };


                    //send Email
                   var flag=  EmailSetting.SendEmail(email);
                    if (flag) 
                    {
                        // reset Password 

                        // Check ur Inbox 
                        return RedirectToAction("CheckYourInbox");
                    
                    }
                
                }
            
            
            }
            ModelState.AddModelError("","Invaild Reset Password URL !! ");

            return View("ForgetPassword",model);


        }
        [HttpGet]
        public IActionResult CheckYourInbox() 
        {

            return View();
        
        }


        #endregion


        #region RestPassword 
        [HttpGet]
        public IActionResult ResetPassword(string email,string token) 
        {

            TempData["email"]=email;
            TempData["token"]=token;

            return View();

        
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto model)
        {
            if (ModelState.IsValid) 
            {
            var email = TempData["email"]as string;
            var token = TempData["token"]as string;

                if (email is null || token is null) return BadRequest("Invalid Operations ");

              var user=await   _userManager.FindByEmailAsync(email);

                if (user is not null) 
                {

                    var result =await _userManager.ResetPasswordAsync(user, token, model.NewPassword);

                    if (result.Succeeded) 
                    {
                        return RedirectToAction("SignIn");
                    }
                
                }
                ModelState.AddModelError("", "Invalid reset Password  Operation ");


            }
        

            return View();


        }

        //rest pass 9:12


        #endregion

    }
}
