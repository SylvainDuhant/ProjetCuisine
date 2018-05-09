namespace AspCuisineN1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AspCuisineN1.Models.Poko;
    internal sealed class Configuration : DbMigrationsConfiguration<AspCuisineN1.Models.BddContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AspCuisineN1.Models.BddContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.T_Administrateur.RemoveRange(context.T_Administrateur);
            context.T_Cuisinier.RemoveRange(context.T_Cuisinier);
            context.T_Voising.RemoveRange(context.T_Voising);
            context.T_Plat.RemoveRange(context.T_Plat);
            context.T_Theme.RemoveRange(context.T_Theme);
            context.T_Produit.RemoveRange(context.T_Produit);
            context.T_Commande.RemoveRange(context.T_Commande);


            context.T_Administrateur.Add(new CAdministrateur("admin", "jean", "test", "Administrateur", 0123));
            context.T_Cuisinier.Add(new CCuisinier("cui", "luk", "test", "Cuisinier", 0123));
            context.T_Voising.Add(new CVoising("voi", "pierre", "test", "Client", 0123));

            //Add Plat
            context.T_Plat.Add(new CPlat { Nom = "Pate", Description = "Bolo" });
            context.T_Plat.Add(new CPlat { Nom = "Frite", Description = "Legere" });

            //Add  theme
            context.T_Theme.Add(new CTheme { Nom = "Italien", Description = "Mamamia" });
            context.T_Theme.Add(new CTheme { Nom = "Chinois", Description = "Asie" });

            //Add produit
            context.T_Produit.Add(new CProduit { Nom = "Boulette", Prix = 2 });
            context.T_Produit.Add(new CProduit { Nom = "Patate", Prix = 3 });

            context.SaveChanges();
        }
    }
}
