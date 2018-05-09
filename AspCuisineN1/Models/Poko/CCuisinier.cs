using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspCuisineN1.Models.Poko
{
    [Table("Cuisinier")]
    public class CCuisinier : CUtilisateur
    {
        public virtual List<CPlat> ListPlat { get; set; }
        public virtual List<CCommande> ListCommande { get; set;}

        //Constructeur
        public CCuisinier() { }

        public CCuisinier(CUtilisateur user) : base(user.Nom, user.Prenom, user.MotDePass,user.Role, user.NumTel)
        {
            ListPlat = new List<CPlat>();
            ListCommande = new List<CCommande>();
        }

        public CCuisinier(string nom, string prenom, string motDepass, string role, int numtel) : base(nom, prenom, motDepass, role, numtel)
        {
            ListPlat = new List<CPlat>();
            ListCommande = new List<CCommande>();
        }

        //Genere
        public void Generer()
        {
            CDal dal = new CDal();
            dal.AjouterCuisinier(this);
        }

        public CCuisinier ChercherCuisinier(int id)
        {
            CDal dal = new CDal();
            return dal.ObtenirCuisinier(id);
        }

        //GererPlat
        public void AjouterPlat(CPlat plat)
        {
            ListPlat.Add(plat);
        }

        public List<CPlat> ListePlatCuisinier()
        {
            return ListPlat;
        }

        //GererCommande
        public void AjouterCommande(CCommande com)
        {
            ListCommande.Add(com);
        }

        public List<CCommande> ListeCommandeCuisinier()
        {
            return ListCommande;
        }
    }
}