using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspCuisineN1.Models.Poko
{
    public class CCommande
    {
        public int Id { get; set; }
        public virtual CPlat Plat { get; set; } // virtual pour lazy loading
        public int Quantite { get; set; }
        public float Prix { get; set; }

        public CCuisinier RefClient { get; set; }
        public CVoising RefVoising { get; set; }

        //public DateTime DateCom { get; set; }

        //public bool Status { get; set; }


        //Constructeur
        public CCommande() { }

        public CCommande(CPlat plat, int quantite, float prix, CCuisinier refcli, CVoising refvoi)
        {
            this.Plat = plat;
            this.Quantite = quantite;
            this.Prix = prix;
            this.RefClient = refcli;
            this.RefVoising = refvoi;
        }


        //Genere
        public void Generer()
        {
            CDal dal = new CDal();
            dal.AjouterCommande(this);
        }
    }
}