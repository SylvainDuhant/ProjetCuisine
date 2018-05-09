using AspCuisineN1.Models;
using AspCuisineN1.Models.Poko;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspCuisineN1.Controllers
{
    public class CuisinierController : Controller
    {
        //Index
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        //Gestion Theme
        public ActionResult ListTheme()
        {
            ViewBag.list_theme = CTheme.ObtenirListThemes();
            return View();
        }

        //Gestion Plat
        public ActionResult ListPlat()
        {
            ViewBag.list_plat = CPlat.ObtenirListPlat();
            return View();
        }

        public ActionResult AjouterPlat()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AjouterPlatVerif(CPlat platinit)
        {
            if (ModelState.IsValid)
            {
                platinit.AjouterPlat();
            }
            return RedirectToAction("ListPlat");
        }

        public ActionResult SupprimerPlat(int platid)
        {
            CPlat.SupprimerPlat(platid);
            return RedirectToAction("ListPlat");
        }

        /*//Gestion Commande
        public ActionResult ListCommande()
        {
            //CCommande_Dal dal = new CCommande_Dal();
            //ViewBag.list_commande = dal.ObtenirListCommande();
            CCuisinier cuisto = new CCuisinier();
            cuisto.ChercherCuisinier((int)Session["Id"]);
            cuisto.ListeCommandeCuisinier;
            ViewBag.list_commande = user.ListCommande.ToList();
            return View();
        }*/
    }
}