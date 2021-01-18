using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Blog.UI.Controllers
{
    [AllowAnonymous]
    public class SecurityController : Controller
    {
        // GET: Security
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Index(string email, string password, bool rememberme)
        {
            if (email != "ylmazsaid@gmail.com" || password != "Saidylmz1937")
                return RedirectToAction("Index");
            
            if (rememberme)
            {
                FormsAuthentication.SetAuthCookie(email, true);
                CreateCookie("Email", email);
                CreateCookie("Password", password);

            }
            else
            {
                FormsAuthentication.SetAuthCookie(email, false);
                DeleteCookie("Email");
                DeleteCookie("Password");
            }
            return RedirectToAction("Index", "Admin");

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        private void CreateCookie(string name, string value)
        {
            HttpCookie cookieVisitor = new HttpCookie(name, value);
            Response.Cookies.Add(cookieVisitor);
            Response.Cookies[name].Expires = DateTime.Now.AddMonths(1);
        }

        private string GetCookie(string name)
        {
            if (Request.Cookies.AllKeys.Contains(name))
            {
                return Request.Cookies[name].Value;
            }
            return null;
        }
        private void DeleteCookie(string name)
        {
            if (GetCookie(name) != null)
            {
                Response.Cookies.Remove(name);
                Response.Cookies[name].Expires = DateTime.Now.AddDays(-1);
            }
        }
    }
}