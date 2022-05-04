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
        private static IList<ProductModel> products = new List<ProductModel>();
        private static IList<ProductModel> fidgets = new List<ProductModel>();
        private static IList<ProductModel> funkos = new List<ProductModel>();
        private static IList<ProductModel> legos = new List<ProductModel>();
        private static IList<ProductModel> puzzles = new List<ProductModel>();
        private static IList<ProductModel> squishmallows = new List<ProductModel>();
        private static IList<ProductModel> searchResults = new List<ProductModel>();
        MySql.Data.MySqlClient.MySqlConnection conn;
        public void AddProducts(string query, IList<ProductModel> list)
        {
            if (list.Count < 1)
            {
                try
                {
                    string conString = this.Configuration.GetConnectionString("Group1FinalProject");
                    conn = new MySqlConnection();
                    conn.ConnectionString = conString;
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    foreach (DataRow row in dt.Rows)
                    {
                        list.Add(new ProductModel()
                        {
                            ProductId = row.Field<int>(0),
                            CategoryId = row.Field<int>(1),
                            ProductName = row.Field<string>(2),
                            Manufacturer = row.Field<string>(3),
                            Description = row.Field<string>(4),
                            Dimensions = row.Field<string>(5),
                            Weight = row.Field<double>(6),
                            Rating = row.Field<double>(7),
                            SKU = row.Field<string>(8),
                            Price = row.Field<double>(9),
                            Image = row.Field<string>(10)
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
            AddProducts("Select * from product",products);
            return View("Index", products);
        }

        public IActionResult Fidgets()
        {
            AddProducts("Select * from product", products);
            AddProducts("Select * FROM product WHERE category_id = 5",fidgets);
            return View(fidgets);
        }

        public IActionResult Funkos()
        {
            AddProducts("Select * from product", products);
            AddProducts("Select * FROM product WHERE category_id = 3",funkos);
            return View(funkos);
        }

        public IActionResult Legos()
        {
            AddProducts("Select * from product", products);
            AddProducts("Select * FROM product WHERE category_id = 1",legos);
            return View(legos);
        }

        public IActionResult Puzzles()
        {
            AddProducts("Select * from product", products);
            AddProducts("Select * FROM product WHERE category_id = 4",puzzles);
            return View(puzzles);
        }

        public IActionResult Squishmallows()
        {
            AddProducts("Select * from product", products);
            AddProducts("Select * FROM product WHERE category_id = 2",squishmallows);
            return View(squishmallows);
        }
        
         public ActionResult DetailedProduct(ProductModel product)
        {
            AddProducts("Select * from product", products);
            IEnumerable<ProductModel> result = from p in products where p.ProductName.Equals(product.ProductName) select p;
            return View(result.Cast<ProductModel>().ElementAt(0));
        }

        public IActionResult AddToCart(int ProductId)
        {
            AddProducts("Select * from product", products);
            IEnumerable<ProductModel> result = from p in products where p.ProductId.Equals(ProductId) select p;
            return RedirectToAction("AddToCart", "Cart", result.Cast<ProductModel>().ElementAt(0));
        }

        public IActionResult SearchResults(string searchString)
        {
            searchResults.Clear();
            TempData["SearchString"] = searchString;
            string searchQuery = "Select * FROM product WHERE name like \'%" + searchString + "%\'";
            AddProducts(searchQuery, searchResults);
            TempData["HasResults"] = searchResults.Count;

            return View(searchResults);
        }

        //[HttpPost]

        //public ActionResult DetailedProduct(Product product)
        //{
        //    return View(product);
        //}
        
    }
}
