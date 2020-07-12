using System.Collections.Generic;
using System.Reflection.Emit;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using models;
using test.Models.Interface;
using test.ViewModels;
using Microsoft.AspNetCore.Http;

namespace test.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRegisterRepository context;

        public AccountController(IRegisterRepository context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult RegisterNewUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterNewUser(RegisterView model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var data = new Register{
                        UserName=model.UserName,
                        UserEmail=model.UserEmail,
                        Password=model.Password,
                        Status=model.Status,
                        Role=model.Role
                    };
                    var Result = await context.AddRegister(data);
                    return RedirectToAction("Index","Home");
                }
                return View(model);   
            }
            catch (Exception)
            {
                return Ok();
            }
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var data = new Register{
                        UserName = model.UserName,
                        Password = model.Password
                    };
                    if(await context.UserLogin(data) == true)
                    {
                        HttpContext.Session.SetString("Username", data.UserName);
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError(string.Empty, "Invalid Login");
                }
                return View(model);   
            }
            catch (System.Exception)
            {
                return Ok();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}