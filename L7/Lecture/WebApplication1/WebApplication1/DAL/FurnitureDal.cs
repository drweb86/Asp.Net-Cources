using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class FurnitureDal
    {
        public string ConnectionString => ConfigurationManager.ConnectionStrings["FurnitureDb"].ConnectionString;
        //iisreset or 

        public void Delete(int bed_uid)
        {
            string query = "delete from bed where Id = @Id"; //1 variant, 2nd - stored procedure
            
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@Id", bed_uid);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }

        public List<BedViewModel> GetBeds()
        {
            var beds = new List<BedViewModel>();

            //string query = "select * from Bed"; //1 variant, 2nd - stored procedure
            string query = "GetBeds";
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                //command.CommandType = CommandType.Text;
                command.CommandType = CommandType.StoredProcedure;

                connection.Open();

                using (var reader = command.ExecuteReader()) // 3 ways or returning result.
                {
                    int bedUid = reader.GetOrdinal("Bed_UID");
                    int model = reader.GetOrdinal("Model");
                    int image = reader.GetOrdinal("Image");

                    while (reader.Read())
                    {
                        //reader.FieldCount
                        
                        beds.Add(new BedViewModel()
                        {
                            Bed_UID = reader.GetInt32(bedUid),
                            Model = reader.GetString(model),
                            Image = reader.GetString(image)
                        });
                    }
                }
            }

            return beds;
        }
    }
}