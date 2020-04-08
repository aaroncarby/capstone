using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapstoneTest.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(CapstoneTest.Models.Account accountModel)
        {
            
            using(Models.CapstoneEntities db = new Models.CapstoneEntities())
            {
                var accountDetails = db.Accounts.Where(x => x.UserName == accountModel.UserName && x.Password == accountModel.Password).FirstOrDefault();
                if(accountDetails == null)
                {
                    ViewBag.LoginErrorMessage = "Wrong Username or password";
                    return View("Index", accountModel);
                }
                else
                {
                    Session["userID"] = accountDetails.UserID;
                    Session["userName"] = accountDetails.UserName;

                    return RedirectToAction("Index", "Home");
                }
            }
            
        }

        public ActionResult LogOut()
        {
            int userId = (int)Session["userID"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}