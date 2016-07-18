namespace SiarheiKuchukIncorporated.HomeWork8.Dal_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProductDescriptionrequiredcolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Description", c => c.String(nullable: false, defaultValue: "Unknown"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Description");
        }
    }
}
