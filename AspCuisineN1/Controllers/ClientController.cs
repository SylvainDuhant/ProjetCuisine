using AspCuisineN1.Models;
using AspCuisineN1.Models.Poko;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspCuisineN1.Controllers
{
    public class ClientController : Controller
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

        //Gerer Commande

        //Ajouter Commande
        public ActionResult AjouterCommande()
        {
            CDal dal = new CDal();
            ViewBag.ListePlats = new SelectList(dal.ObtenirListPlat(),"Id","Nom"); //afficher le nom et revoyer l'id
            return View();
        }

        //Verifier commande
        [HttpPost]
        public ActionResult AjouterCommandeVerif(CCommande com)
        {
            CDal dal = new CDal();            
            com.Plat = dal.GetPlatById(com.Plat.Id); //Seul l'id est set, ici on met le "reste" avec
            CVoising cli = dal.ObtenirVoisin((int)Session["Id"]);
            com.RefVoising = cli;
            cli.Commander(com);
            return RedirectToAction("ListCommande");
        }
        public ActionResult ListCommande()
        {
            CDal dal = new CDal();
            ViewBag.list_commande = dal.ObtenirListCommande();
            return View();
        }
    }
}