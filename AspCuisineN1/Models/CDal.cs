using AspCuisineN1.Models.Poko;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspCuisineN1.Models
{
    public class CDal : IDisposable
    {
        private BddContext bdd;

        public CDal()
        {
            bdd = new BddContext();
        }

        public void Dispose()
        {
            bdd.Dispose();
        }

        //---------------Utilisateur------------------
        
        public List<CUtilisateur> ObtenirListUtilisateur()
        {
            List<CUtilisateur> list = new List<CUtilisateur>();
            list.AddRange(bdd.T_Cuisinier.ToList());
            list.AddRange(bdd.T_Administrateur.ToList());
            list.AddRange(bdd.T_Voising.ToList());
            return list;
        }

        public CUtilisateur ChercherUtilisateur(CUtilisateur user)
        {
            List<CUtilisateur> list = CUtilisateur.ObtenirListUtilisateur(); //
            return list.Single(u => u.Nom == user.Nom && u.MotDePass == user.MotDePass);
        }

        public CUtilisateur ChercherUtilisateurid(int iduser)
        {
            List<CUtilisateur> list = CUtilisateur.ObtenirListUtilisateur(); //
            return list.Single(u => u.Id == iduser);
        }

        //Supp
        public void SupprimerUtilisateur(int id)
        {
            var user = bdd.T_Voising.Single(x => x.Id == id);
            bdd.T_Voising.Remove(user);
            bdd.SaveChanges();
        }

        //Modifier Utilisateur
        public void ModifierUtilisateur(CUtilisateur user)
        {
            CUtilisateur utilisateur = bdd.T_Utilisteur.Single(u => u.Id == user.Id);
            utilisateur.Nom = user.Nom;
            utilisateur.Prenom = user.Prenom;
            utilisateur.NumTel = user.NumTel;

            bdd.SaveChanges();
        }

        /*
        public void AjouterUtilisateur(string nom, string prenom, string MotDePass)
        {
            bdd.T_Utilisteur.Add(new CUtilisateur { Nom = nom, Prenom = prenom, MotDePass = MotDePass });

            bdd.SaveChanges();
        }
        */

        //-------------------Admin-------------------------
        public List<CAdministrateur> ObtenirListAdministrateur()
        {
            return bdd.T_Administrateur.ToList();
        }

        public void AjouterAdministrateur(CAdministrateur admin)
        {
            bdd.T_Administrateur.Add(admin);
            bdd.SaveChanges();
        }

        //-------------------Voisin-------------------------
        public List<CVoising> ObtenirListVoising()
        {
            return bdd.T_Voising.ToList();
        }

        public void AjouterVoising(CVoising voising)
        {
            bdd.T_Voising.Add(voising);
            bdd.SaveChanges();
        }

        public CVoising ObtenirVoisin(int id)
        {
            List<CVoising> list = ObtenirListVoising();
            return list.Single(u => u.Id == id);
        }

        //-----------------------Cuisinier-----------------------------
        public List<CCuisinier> ObtenirListCuisinier()
        {
            return bdd.T_Cuisinier.ToList();
        }

        public void AjouterCuisinier(CCuisinier cuisinier)
        {
            bdd.T_Cuisinier.Add(cuisinier);
            bdd.SaveChanges();
        }

        public CCuisinier ObtenirCuisinier(int id)
        {
            List<CCuisinier> list = ObtenirListCuisinier();
            return list.Single(u => u.Id == id);
        }

        //------------------Theme---------------
        public List<CTheme> ObtenirListTheme()
        {
            return bdd.T_Theme.ToList();
        }

        //Ajouter
        public void AjouterTheme(CTheme theme)
        {
            bdd.T_Theme.Add(theme);
            bdd.SaveChanges();
        }

        //Supp
        public void SupprimerTheme(int id)
        {
            var theme = bdd.T_Theme.Single(x => x.Id == id);
            bdd.T_Theme.Remove(theme);
            bdd.SaveChanges();
        }

        //Update
        public void UpdateTheme(int id, string nom, string description)
        {
            var theme = bdd.T_Theme.Single(x => x.Id == id);
            theme.Nom = nom;
            theme.Description = description;
            bdd.SaveChanges();
        }

        //-------------------Plat-------------------
        public List<CPlat> ObtenirListPlat()
        {
            return bdd.T_Plat.ToList();
        }

        public void AjouterPlat(CPlat plat)
        {
            bdd.T_Plat.Add(plat);
            bdd.SaveChanges();
        }

        public CPlat GetPlatById(int id)
        {
            return bdd.T_Plat.FirstOrDefault(m => m.Id == id);
        }
        //Supp
        public void SupprimerPlat(int id)
        {
            var plat = bdd.T_Plat.Single(x => x.Id == id);
            bdd.T_Plat.Remove(plat);
            bdd.SaveChanges();
        }

        //Update
        public void UpdatePlat(int id, string nom, string description)
        {
            var theme = bdd.T_Plat.Single(x => x.Id == id);
            theme.Nom = nom;
            theme.Description = description;
            bdd.SaveChanges();
        }

        //-------------------Commandes-----------------------------

        public List<CCommande> ObtenirListCommande()
        {
            return bdd.T_Commande.ToList();
        }

        public void AjouterCommande(CCommande com)
        {
            bdd.T_Commande.Add(com);
            bdd.SaveChanges();
        }

        //OO
        public CCommande ChercherCommandePrix(float prix)
        {
            return bdd.T_Commande.FirstOrDefault(u => u.Prix == prix);
        }
        
        //------------------------Produit------------------------
        public List<CProduit> ObtenirListProduit()
        {
            return bdd.T_Produit.ToList();
        }

        public void AjouterProduit(CProduit produit)
        {
            bdd.T_Produit.Add(produit);
            bdd.SaveChanges();
        }
    }
}