namespace SiarheiKuchukIncorporated.HomeWork8.Dal_CodeFirst
{
    // 1. Enable-Migrations -ProjectName SiarheiKuchukIncorporated.HomeWork8.Dal-CodeFirst -StartUpProjectName SiarheiKuchukIncorporated.HomeWork8.Web -Verbose
    // 2. Add-Migration -ProjectName SiarheiKuchukIncorporated.HomeWork8.Dal-CodeFirst -StartUpProjectName SiarheiKuchukIncorporated.HomeWork8.Web -Verbose // name: Initial
    // 3. Update-Database -ProjectName SiarheiKuchukIncorporated.HomeWork8.Dal-CodeFirst -StartUpProjectName SiarheiKuchukIncorporated.HomeWork8.Web -Verbose
    // 4. Product : Add Description, required field.
    // 5. Add-Migration ...
    // 6. *AddColumn("dbo.Product", "Description", c => c.String(nullable: false, defaultValue: "Unknown"));
    // 7. Update-Database...


    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShopDb : DbContext
    {
        public ShopDb()
            : base("name=ShopDb")
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Product)
                .WithMany(e => e.Category)
                .Map(m => m.ToTable("ProductCategory")
                    .MapLeftKey("Category_UID")
                    .MapRightKey("Product_UID"));
        }
    }
}
