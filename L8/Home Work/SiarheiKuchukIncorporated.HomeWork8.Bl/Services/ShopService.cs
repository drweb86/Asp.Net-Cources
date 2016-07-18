using System.Collections.Generic;
using System.Linq;
using SiarheiKuchukIncorporated.HomeWork8.Bl.ViewModels;
using SiarheiKuchukIncorporated.HomeWork8.Dal_CodeFirst;

namespace SiarheiKuchukIncorporated.HomeWork8.Bl.Services
{
    public class ShopService
    {
        public IEnumerable<CategoryViewModel> SelectCategories()
        {
            using (var dbContext = new ShopDb())
                return dbContext.Category
                    .ToArray() // to finalize db query
                    .Select(item => new CategoryViewModel(item.Category_UID, item.Name))
                    .ToArray();
        }

        public CategoryViewModel SelectFirstCategory()
        {
            using (var dbContext = new ShopDb())
            {
                var categoryDal = dbContext.Category
                    .FirstOrDefault();

                if (categoryDal == null)
                    return null;

                return new CategoryViewModel(categoryDal.Category_UID, categoryDal.Name);
            }
        }

        public CategoryViewModel SelectCategory(int category_uid)
        {
            using (var dbContext = new ShopDb())
            {
                var categoryDal = dbContext.Category
                    .FirstOrDefault(item => item.Category_UID == category_uid);

                if (categoryDal == null)
                    return null;

                return new CategoryViewModel(categoryDal.Category_UID, categoryDal.Name);
            }
        }

        public IEnumerable<ProductViewModel> SelectProducts(CategoryViewModel category)
        {
            using (var dbContext = new ShopDb())
                return dbContext.Product
                    .Where(product=>product.Category.Any(productCategory=> productCategory.Category_UID == category.Category_UID))
                    .ToArray() // to finalize db query
                    .Select(item => new ProductViewModel(item.Product_UID, item.Name, item.Price))
                    .ToArray();
        }
    }
}