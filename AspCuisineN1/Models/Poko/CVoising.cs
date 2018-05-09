using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspCuisineN1.Models.Poko
{
    [Table("Voisin")]
    public class CVoising : CUtilisateur
    {
        public virtual List<CCommande> ListCommande { get; set; }

        //Constructeur
        public CVoising() { }

        public CVoising(CUtilisateur user) : base(user.Nom, user.Prenom, user.MotDePass,user.Role, user.NumTel)
        {
            ListCommande = new List<CCommande>();
        }

        public CVoising(string nom, string prenom, string motDepass, string role, int numtel) : base(nom, prenom, motDepass, role, numtel)
        {
            ListCommande = new List<CCommande>();
        }


        //Genere
        public void Generer()
        {
            CDal dal = new CDal();
            dal.AjouterVoising(this);
        }

        //GererCommande
        public void AjouterCommande(CCommande com)
        {
            ListCommande.Add(com);
        }

        public List<CCommande> ListeCommandeVoising()
        {
            return ListCommande;
        }

        //Chercher
        public CVoising ChercherVoisin(int id)
        {
            CDal dal = new CDal();
            return dal.ObtenirVoisin(id);
        }
    }
}