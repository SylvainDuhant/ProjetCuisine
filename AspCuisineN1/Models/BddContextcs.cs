using AspCuisineN1.Models.Poko;
using System.Data.Entity;
using System.Linq;

namespace AspCuisineN1.Models
{
    public class BddContext : DbContext
    {
        //Acteur
        public DbSet<CUtilisateur> T_Utilisteur { get; set; }
        public DbSet<CAdministrateur> T_Administrateur { get; set; }
        public DbSet<CVoising> T_Voising { get; set; }
        public DbSet<CCuisinier> T_Cuisinier { get; set; }

        //Utilise par tt les acteurs
        public DbSet<CTheme> T_Theme { get; set; }
        public DbSet<CPlat> T_Plat { get; set; }
        public DbSet<CProduit> T_Produit { get; set; }

        //Utilisé par certain acteurs
        public DbSet<CCommande> T_Commande { get; set; }

        //Test
        public DbSet<CTestPoko> T_TestPoko { get; set; }



        public BddContext()
        {
            Database.SetInitializer(new BddContextInitialisazer());
        }

        public class InheritanceMappingContext : DbContext
        {
            public DbSet<CUtilisateur> T_Utilisteur { get; set; }
        }

        public class BddContextInitialisazer : DropCreateDatabaseIfModelChanges<BddContext>
        {
            protected override void Seed(BddContext context)
            {
                //Add Utilisateur
                //context.T_Utilisteur.Add(new CUtilisateur { Nom = "Vroum", Prenom = "Vroum", MotDePass = "lol", Role = "Client" });
                //context.T_Utilisteur.Add(new CUtilisateur { Nom = "Wouf", Prenom = "Wouf", MotDePass = "test", Role = "Cuisinier" });
                //context.T_Utilisteur.Add(new CUtilisateur { Nom = "Waf", Prenom = "Waf", MotDePass = "test", Role = "Administrateur" });

                context.T_Administrateur.Add(new CAdministrateur("admin","jean", "test","Administrateur", 0123));
                context.T_Cuisinier.Add(new CCuisinier("cui", "luk", "test", "Cuisinier", 0123));
                context.T_Voising.Add(new CVoising ("voi", "pierre", "test", "Client", 0123));

                context.T_Administrateur.Add(new CAdministrateur("test", "jean", "test", "Administrateur", 0123));
                context.T_Cuisinier.Add(new CCuisinier("test", "luk", "test", "Cuisinier", 0123));
                context.T_Voising.Add(new CVoising("test", "pierre", "test", "Client", 0123));

                //Add Plat
                context.T_Plat.Add(new CPlat { Nom = "Pate", Description = "Bolo" });
                context.T_Plat.Add(new CPlat { Nom = "Frite", Description = "Legere" });

                //Add  theme
                context.T_Theme.Add(new CTheme { Nom = "Italien", Description = "Mamamia" });
                context.T_Theme.Add(new CTheme { Nom = "Chinois", Description = "Asie" });

                //Add produit
                context.T_Produit.Add(new CProduit { Nom = "Boulette", Prix = 2 });
                context.T_Produit.Add(new CProduit { Nom = "Patate", Prix = 3 });

                //Add Commande
                context.T_Commande.Add(new CCommande { Prix = 10 });
                context.T_Commande.Add(new CCommande { Prix = 15 });
                context.T_Commande.Add(new CCommande { Prix = 20 });
                context.T_Commande.Add(new CCommande { Prix = 25 });

                context.SaveChanges();
            }
        }
    }
}