namespace AspCuisineN1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Utilisateur",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        MotDePass = c.String(),
                        Role = c.String(),
                        NumTel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CThemes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        CAdministrateur_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Administrateur", t => t.CAdministrateur_Id)
                .Index(t => t.CAdministrateur_Id);
            
            CreateTable(
                "dbo.CCommandes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantite = c.Int(nullable: false),
                        Prix = c.Single(nullable: false),
                        Plat_Id = c.Int(),
                        RefClient_Id = c.Int(),
                        RefVoising_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CPlats", t => t.Plat_Id)
                .ForeignKey("dbo.Cuisinier", t => t.RefClient_Id)
                .ForeignKey("dbo.Voisin", t => t.RefVoising_Id)
                .Index(t => t.Plat_Id)
                .Index(t => t.RefClient_Id)
                .Index(t => t.RefVoising_Id);
            
            CreateTable(
                "dbo.CPlats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Description = c.String(),
                        CCuisinier_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cuisinier", t => t.CCuisinier_Id)
                .Index(t => t.CCuisinier_Id);
            
            CreateTable(
                "dbo.CProduits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prix = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CTestPokoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Blabl = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Administrateur",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilisateur", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Cuisinier",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilisateur", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Voisin",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Utilisateur", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Voisin", "Id", "dbo.Utilisateur");
            DropForeignKey("dbo.Cuisinier", "Id", "dbo.Utilisateur");
            DropForeignKey("dbo.Administrateur", "Id", "dbo.Utilisateur");
            DropForeignKey("dbo.CCommandes", "RefVoising_Id", "dbo.Voisin");
            DropForeignKey("dbo.CPlats", "CCuisinier_Id", "dbo.Cuisinier");
            DropForeignKey("dbo.CCommandes", "RefClient_Id", "dbo.Cuisinier");
            DropForeignKey("dbo.CCommandes", "Plat_Id", "dbo.CPlats");
            DropForeignKey("dbo.CThemes", "CAdministrateur_Id", "dbo.Administrateur");
            DropIndex("dbo.Voisin", new[] { "Id" });
            DropIndex("dbo.Cuisinier", new[] { "Id" });
            DropIndex("dbo.Administrateur", new[] { "Id" });
            DropIndex("dbo.CPlats", new[] { "CCuisinier_Id" });
            DropIndex("dbo.CCommandes", new[] { "RefVoising_Id" });
            DropIndex("dbo.CCommandes", new[] { "RefClient_Id" });
            DropIndex("dbo.CCommandes", new[] { "Plat_Id" });
            DropIndex("dbo.CThemes", new[] { "CAdministrateur_Id" });
            DropTable("dbo.Voisin");
            DropTable("dbo.Cuisinier");
            DropTable("dbo.Administrateur");
            DropTable("dbo.CTestPokoes");
            DropTable("dbo.CProduits");
            DropTable("dbo.CPlats");
            DropTable("dbo.CCommandes");
            DropTable("dbo.CThemes");
            DropTable("dbo.Utilisateur");
        }
    }
}
