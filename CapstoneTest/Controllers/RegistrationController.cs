using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapstoneTest.Models;

namespace CapstoneTest.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            Account accountModel = new Account();
            return View();
        }

        [HttpPost]
        public ActionResult AddOrEdit(Account accountModel)
        {
            using (Models.CapstoneEntities db = new Models.CapstoneEntities())
            {
                if (db.Accounts.Any(x => x.UserName == accountModel.UserName))
                {
                    ViewBag.ErrorMessage = "Username alread exist.";
                    return View("AddOrEdit", accountModel);
                }
                db.Accounts.Add(accountModel);
                db.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registration Succeful.";
            Garage garageModel = new Garage();
            
            return Redirect("~/Garage/AddGarage");
        }
       
    }
}