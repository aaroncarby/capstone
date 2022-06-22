﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapstoneTest.Models;

namespace CapstoneTest.Controllers
{
    public class UserController : Controller
    {
        // GET: User/Random
        public ActionResult Random()
        {
            var user = new User() { username = "joshcarby" };
            return View(user);
            //return Content("hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "home", new { page = 1, sortBy = "name"});
        }
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
    }
}