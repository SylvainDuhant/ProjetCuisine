using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspCuisineN1.Models.Poko
{
    [Table("Utilisateur")]
    public class CUtilisateur
    {
        //Propriete
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        [Display(Name = "Mot de passe")]
        public string MotDePass { get; set; }
        public string Role { get; set; }
        [Required]
        [Display(Name = "Numero de telephone")]
        public int NumTel { get; set; }

        //Constructeur
        public CUtilisateur() { }

        public CUtilisateur(string nom, string prenom, string mp, string role, int numtel)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.MotDePass = mp;
            this.Role = role;
            this.NumTel = numtel;
        }

        //Supprimer
        public static void SupprimerUtilisateur(int id)
        {
            CDal dal = new CDal();
            dal.SupprimerUtilisateur(id);
        }

        //Consulter
        public static List<CUtilisateur> ObtenirListUtilisateur()
        {
            CDal dal = new CDal();
            return dal.ObtenirListUtilisateur();
        }

        //Chercher Utilisateur
        public static CUtilisateur ChercherUtilisateur(CUtilisateur user)
        {
            CDal dal = new CDal();
            return dal.ChercherUtilisateur(user);
        }

        public CUtilisateur ChercherUtilisateurid(int iduser)
        {
            CDal dal = new CDal();
            return dal.ChercherUtilisateurid(iduser);
        }


        //public virtual List<CCommande> ListCommande { get; set; }

        /*public CUtilisateur()
        {
            ListCommande = new List<CCommande>();
        }*/

        /*public CUtilisateur(string nom, string prenom, string mp, string role, int numtel)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.MotDePass = mp;
            this.Role = role;
            this.NumTel = numtel;
            //this.ListCommande = new List<CCommande>();
        }*/

        /*public List<CCommande> ListeCommandeUser()
        {
            return ListCommande;
        }*/

        //public DateTime DateNaiss { get; set; }
        //public int Num { get; set; }
        //public string Rue { get; set; }
        //public string Localite { get; set; }
    }
}