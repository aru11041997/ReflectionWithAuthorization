using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Auth.Models;

namespace Auth.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            USER user = new USER();
            AuthorizeDemoEntities db = new AuthorizeDemoEntities();

            user = db.USERS.FirstOrDefault(us => us.UserName.Equals(loginModel.UserName) && us.Password.Equals(loginModel.Password));

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                Session["UserName"] = user.UserName;
                return RedirectToAction("List", "Product");
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["UserName"] = null;
            return RedirectToAction("Login");
        }


    }
}