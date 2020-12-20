using NotDefteri.Abstraction.IRepository;
using NotDefteri.Data.Context;
using NotDefteri.Data.Entities;
using NotDefteri.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace NotDefteri.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;

        }

        public ActionResult Login()
        {

            var user = _userService.GetAll().ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel credentials)
        {
            UserModel user = _userService.GetAll().FirstOrDefault(x => x.UserName == credentials.UserName && x.Password == credentials.Password);
            if (user != null)
            {
                string cookie = user.UserName;
                FormsAuthentication.SetAuthCookie(cookie, true);
                Session["FullName"] = user.UserName; 
                Session["ID"] = user.Id;
                return Redirect("//");
            }
            else
            {
                ViewBag.error = "Kullanıcı Adı Veya Şifre Hatalı!";
                return View(credentials);
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Abandon();
            FormsAuthentication.SignOut();
            Session["FullName"] = null;
            Session["Picture"] = null;
            Session["ID"] = null;
            return Redirect("/User/Login");
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserModel data)
        {


            UserModel user = _userService.GetAll().Where(x => x.UserName == data.UserName || x.Email == data.Email).FirstOrDefault();

            if (user == null)
            {
                _userService.Add(data);

                return Json("Kayıt Başarılı! Giriş Yapabilirsiniz!");
            }
            else
            {
                return Json("Bu Kullanıcı adı ya da Mail Sistemde Kayıtlı!");
            }
        }
    }
}