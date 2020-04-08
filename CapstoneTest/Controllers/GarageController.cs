using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapstoneTest.Models;
namespace CapstoneTest.Controllers
{
    public class GarageController : Controller
    {
        // GET: Garage
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddGarage(Garage garageModel)
        {
            garageModel.GarageID = (int)Session["UserID"];
            if (garageModel.GarageID == 0)
            {
                ViewBag.ErrorMessage = "ID doesn't exist.";
                return View("AddGarage", garageModel);
            }
            using (Models.CapstoneEntities db = new Models.CapstoneEntities())
            {

                if (db.Accounts.Any(x => x.UserID != garageModel.GarageID))
                {
                    ViewBag.ErrorMessage = "Error in ID.";
                    return View("AddGarage");
                }
                db.Garages.Add(garageModel);
                db.SaveChanges();
                ViewBag.SuccessMessage = "Garage name has been added";
            }
            return View("AddGarage", garageModel); ;
        }
    }
}