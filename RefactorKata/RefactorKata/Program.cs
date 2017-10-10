using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RefactorKata
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var conn = new SqlConnection("Server=.;Database=myDataBase;User Id=myUsername;Password = myPassword;"))
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select * from Products";
                /*
                 * cmd.CommandText = "Select * from Invoices";
                 */
                var reader = cmd.ExecuteReader();
                var products = new List<Product>();

                //Have not yet learned about Dapper @jrharris620
                //TODO: Replace with Dapper
                while (reader.Read())
                {
                    var prod = new Product { Name = reader["Name"].ToString() };
                    products.Add(prod);
                }

                foreach (var product in products)
                {
                    Console.WriteLine(product.Name);
                }

                Console.WriteLine("Products Loaded!");
                
            }
        }
            
            
    }
}
