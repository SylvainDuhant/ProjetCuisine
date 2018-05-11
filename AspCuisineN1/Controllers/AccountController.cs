using AspCuisineN1.Models;
using AspCuisineN1.Models.Poko;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AspCuisineN1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        //Inscription
        public ActionResult Inscription()
        {
            return View();
        }

        //Inscription Confirmation
        [HttpPost]
        public ActionResult InscriptionConf(CUtilisateur account)
        {
            CDal dal = new CDal();
            if (dal.ObtenirVoisin(account.Nom) != null || dal.ObtenirCuisinier(account.Nom) != null)
            {
                ViewBag.Message = "Nom d'utilisateur déjà existant.";
                return View("Inscription");
            }
            if (ModelState.IsValid)
            {
                if (account.Role == "Client")
                {
                    CVoising v = new CVoising(account);
                    v.Generer();
                }
                else if (account.Role == "Cuisinier")
                {
                    CCuisinier c = new CCuisinier(account);
                    c.Generer();
                }

                ModelState.Clear();
                ViewBag.Message = $"{account.Nom} {account.Prenom} successfully Registered.";
            }
            return View("Confirmation");
        }


        //Login
        public ActionResult Login()
        {
            return View();
        }

        //Login Confirmation
        [HttpPost]
        public ActionResult LoginConf(CUtilisateur userinit)
        {
            CUtilisateur user = null;
            try
            {
                user = CUtilisateur.ChercherUtilisateur(userinit);
            }
            catch
            {
                ViewBag.message = "Nom ou mot de passe incorrect.";
                ViewBag.nom = userinit.Nom;
                ViewBag.mdp = userinit.MotDePass;
                return View("Login");
            }
            
            if (user != null)
            {
                Session["Id"] = user.Id;
                Session["Role"] = user.Role;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(" ", "Username or Password is wrong");
            }
            return View();
        }

        //Déconnection
        public ActionResult Deconnecter()
        {
            FormsAuthentication.SignOut();
            Session["Id"] = null;
            Session["Role"] = null;
            return RedirectToAction("Index", "Home");
        }

        //Modifier Profil
        public ActionResult ModifierProfil()
        {
            CDal dal = new CDal();
            CUtilisateur user = dal.ChercherUtilisateurid((int)Session["Id"]);

            return View(user);
        }

        [HttpPost]
        public ActionResult ModifierProfilVerif(CUtilisateur user)
        {
            if (ModelState.IsValid)
            {
                CDal dal = new CDal();
                dal.ModifierUtilisateur(user);
            }
            return RedirectToAction("ModifierProfil");
        }
    }
}