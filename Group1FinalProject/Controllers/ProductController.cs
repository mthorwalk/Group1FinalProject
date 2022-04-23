using System.Data;
using Group1FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Group1FinalProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly IConfiguration Configuration;

        public ProductController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        private static IList<Product> products = new List<Product>();
        public int max = 1;
        MySql.Data.MySqlClient.MySqlConnection conn;

        public void AddProducts()
        {
            if (products.Count < max)
            {
                try
                {
                    string conString = this.Configuration.GetConnectionString("Group1FinalProject");
                    conn = new MySqlConnection();
                    conn.ConnectionString = conString;
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("Select * from product", conn);
                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        foreach (DataRow row in dt.Rows)
                        {
                            products.Add(new Product()
                            {
                                ProductId = row.Field<int>(0), CategoryId = row.Field<int>(1),
                                ProductName = row.Field<string>(2), Manufacturer = row.Field<string>(3),
                                Description = row.Field<string>(4), Dimensions = row.Field<string>(5),
                                Weight = row.Field<double>(6), Rating = row.Field<double>(7),
                                SKU = row.Field<string>(8), Price = row.Field<double>(9), Image = row.Field<string>(10)
                            });
                        }

                        conn.Close();
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public IActionResult Index()
        { 
                AddProducts();
                return View(products);
        }
    }
}
