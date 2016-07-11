using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace L4HomeWork.DAL
{
    public class ShopDbService
    {
        public IEnumerable<Category> SelectCategories()
        {
            var result = new List<Category>();

            using (var dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ShopDbConnectionString"].ConnectionString))
            using (var dbCommand = new SqlCommand("Categories_SelectAll", dbConnection) {
                    CommandType = CommandType.StoredProcedure })
            {
                dbConnection.Open();
                using (var dbReader = dbCommand.ExecuteReader())
                {
                    var categoryUidColumnId = dbReader.GetOrdinal("Category_UID");
                    var nameColumnId = dbReader.GetOrdinal("Name");

                    while (dbReader.Read())
                    {
                        result.Add(new Category(dbReader.GetInt32(categoryUidColumnId), dbReader.GetString(nameColumnId)));
                    }
                }
            }

            return result;
        }

        public Category SelectCategory(int category_uid)
        {
            using (var dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ShopDbConnectionString"].ConnectionString))
            using (var dbCommand = new SqlCommand("Categories_Select", dbConnection)
                {
                    CommandType = CommandType.StoredProcedure,
                    Parameters = {{"@Category_UID", SqlDbType.Int}}
                })
            {
                dbCommand.Parameters["@Category_UID"].Value = category_uid;
                dbConnection.Open();

                using (var dbReader = dbCommand.ExecuteReader())
                {
                    var categoryUidColumnId = dbReader.GetOrdinal("Category_UID");
                    var nameColumnId = dbReader.GetOrdinal("Name");

                    if (dbReader.Read())
                        return new Category(
                            dbReader.GetInt32(categoryUidColumnId), 
                            dbReader.GetString(nameColumnId));
                    else
                        return null;
                }
            }
        }

        public IEnumerable<Product> SelectProducts(Category category)
        {
            var result = new List<Product>();

            using (var dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ShopDbConnectionString"].ConnectionString))
            using (var dbCommand = new SqlCommand("Products_Select", dbConnection)
                {
                    CommandType = CommandType.StoredProcedure,
                    Parameters = { { "@Category_UID", SqlDbType.Int } }
                })
            {
                dbCommand.Parameters["@Category_UID"].Value = category.Category_UID;
                dbConnection.Open();

                using (var dbReader = dbCommand.ExecuteReader())
                {
                    var productUidColumnId = dbReader.GetOrdinal("Product_UID");
                    var nameColumnId = dbReader.GetOrdinal("Name");
                    var priceColumnId = dbReader.GetOrdinal("Price");

                    while (dbReader.Read())
                        result.Add(new Product(
                            dbReader.GetInt32(productUidColumnId),
                            dbReader.GetString(nameColumnId),
                            dbReader.GetInt32(priceColumnId)));
                }
            }

            return result;
        }
    }
}