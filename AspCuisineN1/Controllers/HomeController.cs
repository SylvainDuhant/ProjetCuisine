﻿using AspCuisineN1.Models.Poko;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspCuisineN1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConsulterTheme()
        {
            ViewBag.list_theme = CTheme.ObtenirListThemes();
            return View();
        }

        public ActionResult APropos()
        {
            return View();
        }
    }
}