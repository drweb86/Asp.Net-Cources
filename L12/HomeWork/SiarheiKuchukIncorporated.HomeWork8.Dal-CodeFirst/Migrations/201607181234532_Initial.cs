namespace SiarheiKuchukIncorporated.HomeWork8.Dal_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Category_UID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Category_UID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Product_UID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Product_UID);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        Category_UID = c.Int(nullable: false),
                        Product_UID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Category_UID, t.Product_UID })
                .ForeignKey("dbo.Category", t => t.Category_UID, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.Product_UID, cascadeDelete: true)
                .Index(t => t.Category_UID)
                .Index(t => t.Product_UID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductCategory", "Product_UID", "dbo.Product");
            DropForeignKey("dbo.ProductCategory", "Category_UID", "dbo.Category");
            DropIndex("dbo.ProductCategory", new[] { "Product_UID" });
            DropIndex("dbo.ProductCategory", new[] { "Category_UID" });
            DropTable("dbo.ProductCategory");
            DropTable("dbo.Product");
            DropTable("dbo.Category");
        }
    }
}
