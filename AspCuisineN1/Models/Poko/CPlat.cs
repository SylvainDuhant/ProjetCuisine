using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspCuisineN1.Models.Poko
{
    public class CPlat
    {
        //Propriete
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }

        //public List<CProduit> ListProduit { get; set; }

        //Ajouter
        public void AjouterPlat()
        {
            CDal dal = new CDal();
            dal.AjouterPlat(this);
        }

        //Supprimer
        public static void SupprimerPlat(int id)
        {
            CDal dal = new CDal();
            dal.SupprimerPlat(id);
        }

        //Consulter
        public static List<CPlat> ObtenirListPlat()
        {
            CDal dal = new CDal();
            return dal.ObtenirListPlat();
        }

        public override string ToString()
        {
            return Nom;
        }
    }
}