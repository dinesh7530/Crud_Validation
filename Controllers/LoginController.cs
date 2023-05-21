using Crud_Validation.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Crud_Validation.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationContext context;
        public LoginController(ApplicationContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User model)
        {
            if (ModelState.IsValid == true)
            {   
                context.tbl_User.Add(model);
                context.SaveChanges();

                if(model.UserName !=null && model.Password !=null)
                {
                    ViewBag.InsertMessage= "<script>alert('Registered Successfully !')</script>";
                    ModelState.Clear();
                }

                return View();
            }
            else
            {  
                ViewBag.InsertMessage = "<script>alert('Registration Failed !')</script>";
                return View();
            }
        }

        [HttpGet]
        public IActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult UserLogin(User Data)
        { 
            var data = context.tbl_User.Where(x => x.UserName == Data.UserName).FirstOrDefault();

            if (data.UserName == Data.UserName && data.Password == Data.Password)
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim (ClaimTypes.Name, data.UserName),

                }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                HttpContext.Session.SetString("UserName",data.Name);
                ViewBag.LoginSuccess = "<script>alert('Username or Password is incorrect !')</script>";
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.LoginFailed = "<script>alert('Username or Password is incorrect !')</script>";
                return View();  
            }
           
        }
    }
}
