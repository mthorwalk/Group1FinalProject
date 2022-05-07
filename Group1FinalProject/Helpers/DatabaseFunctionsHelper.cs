using System;
using System.Data;
using Group1FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Net.Mail;
using MySql.Data.MySqlClient;

namespace Group1FinalProject.Helpers
{

    public class DatabaseFunctionsHelper
    {
        private readonly IConfiguration Configuration;

        public DatabaseFunctionsHelper(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        MySql.Data.MySqlClient.MySqlConnection conn;

        public SignUpViewModel AddCustomer(SignUpViewModel signUpViewModel)
        {
            try
            {
                string conString = this.Configuration.GetConnectionString("Group1FinalProject");
                MySqlConnection conn = new MySqlConnection(conString);
                conn.Open();
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "INSERT INTO user(password,FirstName,LastName,email,phone,address,address_2,city,state,zip,country) VALUES (@password,@first,@last,@email,@phone,@address,@address2,@city,@state,@zip,@country)";
                command.Parameters.AddWithValue("@password", signUpViewModel.Password);
                command.Parameters.AddWithValue("@first", signUpViewModel.FirstName);
                command.Parameters.AddWithValue("@last", signUpViewModel.LastName);
                command.Parameters.AddWithValue("@email", signUpViewModel.Email);
                command.Parameters.AddWithValue("@phone", signUpViewModel.PhoneNumber);
                command.Parameters.AddWithValue("@address", signUpViewModel.Address);
                command.Parameters.AddWithValue("@address2", signUpViewModel.Address2);
                command.Parameters.AddWithValue("@city", signUpViewModel.City);
                command.Parameters.AddWithValue("@state", signUpViewModel.State);
                command.Parameters.AddWithValue("@zip", signUpViewModel.Zip);
                command.Parameters.AddWithValue("@country", signUpViewModel.Country);
                command.ExecuteNonQuery();
                signUpViewModel.Id = (int)command.LastInsertedId;       // Get the ID of the inserted item
                AddCart(signUpViewModel.Id);
                conn.Close();
                signUpViewModel.Success = true;
                return signUpViewModel; 
            } catch (MySqlException e)
            {
                signUpViewModel.Success = false;
                Console.WriteLine(e);
                throw;
            }

            return signUpViewModel;
        }

        public void AddCart(int? userID)
        {
            try
            {
                string conString = this.Configuration.GetConnectionString("Group1FinalProject");
                MySqlConnection conn = new MySqlConnection(conString);
                conn.Open();
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "INSERT INTO cart(cart_id,totalPrice) VALUES(@userID,0.0)";
                command.Parameters.AddWithValue("@userID", userID);
                command.ExecuteNonQuery();
                conn.Close();
            } catch (MySqlException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public SignUpViewModel GetCustomerByID(int userID)
        {
            SignUpViewModel signUpViewModel = new SignUpViewModel();
            try
            {
                string conString = this.Configuration.GetConnectionString("Group1FinalProject");
                MySqlConnection conn = new MySqlConnection(conString);
                conn.Open();
                string query = "SELECT * FROM user WHERE id = '" + userID + "';";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                DataRow row = dt.Rows[0];

                signUpViewModel = new SignUpViewModel()
                {

                    Id = (int)row["id"],
                    Password = row["password"].ToString(),
                    FirstName = row["FirstName"].ToString(),
                    LastName = row["LastName"].ToString(),
                    Email = row["email"].ToString(),
                    PhoneNumber = row["phone"].ToString(),
                    Address = row["address"].ToString(),
                    Address2 = row["address_2"].ToString(),
                    City = row["city"].ToString(),
                    State = row["state"].ToString(),
                    Zip = row["zip"].ToString(),
                    Country = row["country"].ToString()

                };
                signUpViewModel.Success = true;
                return signUpViewModel;
            }
            catch (MySqlException e)
            {
                signUpViewModel.ErrorMessage = e.Message;
                signUpViewModel.Success = false;
                Console.WriteLine(e);
                throw;
            }
            return signUpViewModel;
        }

    
    public SignUpViewModel GetCustomer(SignInViewModel signInViewModel)
    {
        SignUpViewModel signUpViewModel = new SignUpViewModel();
        try
        {
            string conString = this.Configuration.GetConnectionString("Group1FinalProject");
            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();
            string query = "SELECT * FROM user WHERE email = '" + signInViewModel.Email + "' AND password= '" + signInViewModel.Password + "';";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            DataRow row = dt.Rows[0];

            signUpViewModel = new SignUpViewModel()
            {

                Id = (int)row["id"],
                Password = row["password"].ToString(),
                FirstName = row["FirstName"].ToString(),
                LastName = row["LastName"].ToString(),
                Email = row["email"].ToString(),
                PhoneNumber = row["phone"].ToString(),
                Address = row["address"].ToString(),
                Address2 = row["address_2"].ToString(),
                City = row["city"].ToString(),
                State = row["state"].ToString(),
                Zip = row["zip"].ToString(),
                Country = row["country"].ToString()

            };
            signUpViewModel.Success = true;
            return signUpViewModel;
        } catch (MySqlException e)
        {
            signUpViewModel.ErrorMessage = e.Message;
            signUpViewModel.Success = false;
            Console.WriteLine(e);
            throw;
        }
        return signUpViewModel;
    }

    public void AddCartItem(CartItemModel cartItem)         
    {
            List<CartItemModel> List = new List<CartItemModel>();
            List = GetCartItemsById(cartItem.ProductId, cartItem.cart_id);
            if (List.Count == 1)
            {
                cartItem.id = List[0].id;
                ChangeQuantity(cartItem.id, "+");
            } else if (List.Count == 0)
            {
                try
                {
                    string conString = this.Configuration.GetConnectionString("Group1FinalProject");
                    MySqlConnection conn = new MySqlConnection(conString);
                    conn.Open();
                    MySqlCommand command = conn.CreateCommand();
                    command.CommandText = "INSERT INTO cartItem(cart_id,product_id,quantity,price) VALUES (@cartId,@productId,@quantity,@price)";
                    command.Parameters.AddWithValue("@cartId", cartItem.cart_id);
                    command.Parameters.AddWithValue("@productId", cartItem.ProductId);
                    command.Parameters.AddWithValue("@quantity", cartItem.quantity);
                    command.Parameters.AddWithValue("@price", cartItem.Price);


                    command.ExecuteNonQuery();
                    conn.Close();
                }
                catch (MySqlException e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }


        }

    public List<CartItemModel> GetCartItemsById(int productId,int? CartId)
        {
            List<CartItemModel> List = new List<CartItemModel>();
            try
            {
                string conString = this.Configuration.GetConnectionString("Group1FinalProject");
                MySqlConnection conn = new MySqlConnection(conString);
                conn.Open();
                string query = "SELECT * FROM cartItem WHERE cart_id = " +  CartId + " AND product_id = " + productId + ";";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                foreach (DataRow row in dt.Rows)
                {
                    List.Add(new CartItemModel()
                    {
                        id = row.Field<int>(0),  
                        cart_id = row.Field<int>(1),
                        ProductId = row.Field<int>(2),
                        quantity = row.Field<int>(3),
                        productsPrice = row.Field<double>(4)

                    });
                }
                conn.Close();
                return List;

            }
            catch (MySqlException e)
            {

                Console.WriteLine(e);
                throw;
            }
        }

        public List<CartItemModel> GetCustomerCartItems(SignUpViewModel signUpViewModel)
    {
        List<CartItemModel> List = new List<CartItemModel>();
        try
        {
            string conString = this.Configuration.GetConnectionString("Group1FinalProject");
            MySqlConnection conn = new MySqlConnection(conString);
            conn.Open();
            string query = "SELECT * "
                + "FROM cartItem c "
                + "LEFT JOIN product p on c.product_id = p.id "
                + "WHERE c.cart_id =" + signUpViewModel.Id + ";";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());

            foreach (DataRow row in dt.Rows)
            {
                List.Add(new CartItemModel()
                {
                    id = row.Field<int>(0),
                    cart_id = row.Field<int>(1),
                    ProductId = row.Field<int>(2),
                    quantity = row.Field<int>(3),
                    productsPrice = row.Field<double>(4),
                    CategoryId = row.Field<int>(6),
                    ProductName = row.Field<string>(7),
                    Manufacturer = row.Field<string>(8),
                    Description = row.Field<string>(9),
                    Dimensions = row.Field<string>(10),
                    Weight = row.Field<double>(11),
                    Rating = row.Field<double>(12),
                    SKU = row.Field<string>(13),
                    Price = row.Field<double>(14),
                    Image = row.Field<string>(15)
                });
            }

            conn.Close();
            return List;

        } catch (MySqlException e)
        {

            Console.WriteLine(e);
            throw;
        }

        return List;

    }

     public void ChangeQuantity(int? cartItemId, string plusOrMinus)
        {
            try
            {
                string conString = this.Configuration.GetConnectionString("Group1FinalProject");
                MySqlConnection conn = new MySqlConnection(conString);
                conn.Open();
                MySqlCommand command = conn.CreateCommand();
                if (plusOrMinus.Equals("+"))
                {
                    command.CommandText = "UPDATE cartItem SET quantity = quantity + 1 WHERE cartItem_id = @id";

                } else if (plusOrMinus.Equals("-"))
                {
                    command.CommandText = "UPDATE cartItem SET quantity = quantity - 1 WHERE cartItem_id = @id";
                }

                command.Parameters.AddWithValue("@id", cartItemId);
                command.ExecuteNonQuery();
                conn.Close();

            } catch (MySqlException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


     public void DeleteCartItem(int? cartItemId) 
        {
            try
            {
                string conString = this.Configuration.GetConnectionString("Group1FinalProject");
                MySqlConnection conn = new MySqlConnection(conString);
                conn.Open();
                MySqlCommand command = conn.CreateCommand();
                command.CommandText = "DELETE FROM cartItem WHERE cartItem_id = @id;";
                command.Parameters.AddWithValue("@id", cartItemId);
                command.ExecuteNonQuery();
                conn.Close();

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

     public void emailConfirmation(SignUpViewModel user, CheckoutModel checkout)
     {
         DatabaseFunctionsHelper databaseFunctions = new DatabaseFunctionsHelper(Configuration);
         MailMessage mail = new MailMessage();
         SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
         mail.From = new MailAddress("toyszoidtoys@gmail.com");
         mail.To.Add(user.Email);
         mail.Subject = "Test";
         string text = "<html><h2>Thank you for your purchase!</h2><p>Dear " + user.FirstName + ", below you can find your purchase and shipping details.</p>";
         text += "<h4>Shipping Address</h4>";
         text += "<p>" + user.Address.ToString() + "</p>" + "<p>" + user.City.ToString() + ", " + user.State.ToString() + " " + user.Zip.ToString() + "</p>";
         text += "<table><tr><th>Quantity</th><th>Product Name</th><th>Price</th></tr>";
         foreach (CartItemModel item in checkout.CartItems)
         {
             text += "<tr><td>" + item.Quantity.ToString() + "</td><td>" + item.ProductName.ToString() + "</td><td>$" + String.Format("{0:0.00}", item.ProductsPrice) + "</td></tr>";
             databaseFunctions.DeleteCartItem(item.id);
         }
         text += "</table><break>";
         text += "<table><tr><td>Subtotal:</td><td>$" + String.Format("{0:0.00}", checkout.Subtotal) + "</td></tr>";
         text += "<tr><td>Taxes:</td><td>$" + String.Format("{0:0.00}", checkout.Taxes) + "</td></tr>";
         text += "<tr><td>Shipping:</td><td>$" + String.Format("{0:0.00}", checkout.shipping) + "</td></tr>";
         text += "<tr><td>Total:</td><td>$" + String.Format("{0:0.00}", checkout.Total) + "</td></tr></table>";
         mail.Body = text;
         smtpServer.Port = 25;
         smtpServer.Credentials = new System.Net.NetworkCredential("toyszoidtoys", "ToysZoid123!");
         smtpServer.EnableSsl = true;
         mail.IsBodyHtml = true;
         smtpServer.Send(mail);
        }
}

}



        


        

