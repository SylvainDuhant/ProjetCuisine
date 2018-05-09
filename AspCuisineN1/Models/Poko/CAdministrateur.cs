using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspCuisineN1.Models.Poko
{
    [Table("Administrateur")]
    public class CAdministrateur : CUtilisateur
    {
        public List<CTheme> ListTheme { get; set; }

        //Constructeur
        public CAdministrateur() { }

        public CAdministrateur(CUtilisateur user) : base(user.Nom, user.Prenom, user.MotDePass,user.Role, user.NumTel)
        {
            ListTheme = new List<CTheme>();
        }

        public CAdministrateur(string nom, string prenom, string motDepass, string role, int numtel) : base(nom, prenom, motDepass, role, numtel)
        {
            ListTheme = new List<CTheme>();
        }
    }
}