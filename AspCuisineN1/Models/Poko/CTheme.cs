using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspCuisineN1.Models.Poko
{
    public class CTheme
    {
        //Propriete
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Description { get; set; }


        //Ajouter
        public void AjouterTheme()
        {
            CDal dal = new CDal();
            dal.AjouterTheme(this);
        }

        //Supprimer
        public static void SupprimerTheme(int id)
        {
            CDal dal = new CDal();
            dal.SupprimerTheme(id);
        }

        //Consulter
        public static List<CTheme> ObtenirListThemes()
        {
            CDal dal = new CDal();
            return dal.ObtenirListTheme();
        }  
    }
}