using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using L4HomeWork.DAL;

namespace L4HomeWork.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int? id)
        {
            //using (var dbContext = new ShopDalDataContext())
            //{
            //    //dbContext.Categories.InsertOnSubmit(new Category() {Name="Mobile Phone"});
            //    //dbContext.Categories.InsertOnSubmit(new Category() { Name = "Notebook" });
            //    //dbContext.Categories.InsertOnSubmit(new Category() { Name = "Camera" });
            //    //dbContext.Categories.InsertOnSubmit(new Category() { Name = "Head Phones" });

            //    //dbContext.Products.InsertOnSubmit(new Product() { Name = "Lumia", Price = 10});
            //    //dbContext.Products.InsertOnSubmit(new Product() { Name = "Acer", Price = 100 });
            //    //dbContext.Products.InsertOnSubmit(new Product() { Name = "Asus", Price = 200 });

                

            //   dbContext.ProductCategories.InsertOnSubmit(new ProductCategory() {Category_UID = 1, Product_UID = 1});
            //    dbContext.ProductCategories.InsertOnSubmit(new ProductCategory() { Category_UID = 1, Product_UID = 2 });

            //    dbContext.ProductCategories.InsertOnSubmit(new ProductCategory() { Category_UID = 2, Product_UID = 2 });
            //    dbContext.ProductCategories.InsertOnSubmit(new ProductCategory() { Category_UID = 2, Product_UID = 3 });

            //    dbContext.SubmitChanges();
            //}



            return View(id);
        }

        public ActionResult Home()
        {
            return View("Index");
        }

        public ActionResult Contacts()
        {
            return View("Index");
        }

        public ActionResult About()
        {
            return View();
        }
    }
}