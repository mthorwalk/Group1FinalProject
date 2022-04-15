using System.Data;
using Group1FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

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

        public void AddProducts()
        {
            try
            {
                string conString = this.Configuration.GetConnectionString("Group1FinalProject");
                using (SqlConnection connection = new SqlConnection(conString))
                {
                    connection.Open();
                    SqlDataAdapter da = new SqlDataAdapter("Select * from product", connection);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        products.Add(new Product(){ProductId = row.Field<int>(0), CategoryId = row.Field<int>(1), ProductName = row.Field<string>(2), Manufacturer = row.Field<string>(3), Description = row.Field<string>(4), Dimensions = row.Field<string>(5), Weight = row.Field<double>(6), Rating = row.Field<double>(7), SKU = row.Field<string>(8), Price = row.Field<double>(9)});
                    }
                    connection.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public IActionResult Index()
        { 
                AddProducts();
                return View(products);
        }
    }
}
