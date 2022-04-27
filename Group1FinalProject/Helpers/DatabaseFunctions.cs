using System;
using System.Data;
using Group1FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Group1FinalProject.Helpers
{
    
    public class DatabaseFunctions
    {
        private readonly IConfiguration Configuration;

        public DatabaseFunctions(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        MySql.Data.MySqlClient.MySqlConnection conn;

        public void AddCustomer(SignUpViewModel signUpViewModel)
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
                conn.Close();
            } catch (MySqlException e)
            {
                Console.WriteLine(e);
                throw;
            }
          

        }
        
    }
}
