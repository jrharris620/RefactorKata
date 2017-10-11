using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace RefactorKata
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var products = GetProducts();

            foreach (var product in products)
            {
                Console.WriteLine(product.Name);
            }

        }

        /// <summary>
        /// The purpose of this new Method is so that we can reference GetProducts in the future.
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<Product> GetProducts()
        {
            using (var conn = new SqlConnection("Server=.;Database=myDataBase;User Id=myUsername;Password = myPassword;"))
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select * from Products";
                
                var reader = cmd.ExecuteReader();
                var products = new List<Product>();

                //Have not yet learned about Dapper @jrharris620
                //TODO: Replace with Dapper
                while (reader.Read())
                {
                    var prod = new Product { Name = reader["Name"].ToString() };
                    products.Add(prod);
                }

                Console.WriteLine("Products Loaded!");
                return products;

            }
        }
    }
}
