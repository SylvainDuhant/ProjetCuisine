using AspCuisineN1.Models;
using AspCuisineN1.Models.Poko;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspCuisineN1.Controllers
{
    [Table("Administrateur")]
    public class AdministrateurController : Controller
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

        public ActionResult AjouterTheme()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AjouterThemeVerif(CTheme theme)
        {
            if (ModelState.IsValid)
            {
                //CDal dal = new CDal();
                //dal.AjouterTheme(theme);

                theme.AjouterTheme();
            }
            return RedirectToAction("ListTheme");
        }

        public ActionResult SupprimerTheme(int themeid)
        {
            CTheme.SupprimerTheme(themeid);
            return RedirectToAction("ListTheme");
        }

        //Gerer Utilisateur
        public ActionResult ListUtilisateur()
        {
            ViewBag.list_utilisateur = CUtilisateur.ObtenirListUtilisateur();
            return View();
        }

        public ActionResult SupprimerUtilisateur(int userid)
        {
            CUtilisateur.SupprimerUtilisateur(userid);
            return RedirectToAction("ListUtilisateur");
        }

        
        public ActionResult ModifierUtilisateur(int userid)
        {
            CDal dal = new CDal();
            CUtilisateur user =  dal.ChercherUtilisateurid(userid);

            /*CUtilisateur user = new CUtilisateur();
            user.ChercherUtilisateurid(userid);*/
            return View(user);
        }

        [HttpPost]
        public ActionResult ModifierUtilisateurVerif(CUtilisateur user)
        {
            if (ModelState.IsValid)
            {
                CDal dal = new CDal();
                dal.ModifierUtilisateur(user);
            }
            return RedirectToAction("ListUtilisateur");
        }
    }
}
