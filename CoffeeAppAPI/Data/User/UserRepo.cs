using Microsoft.EntityFrameworkCore;
using CoffeeAppAPI.Models.User;
using System;
using System.Data.SqlClient;
using Npgsql;

namespace CoffeeAppAPI.Data.User
{
    public class UserRepo
    {
        string connectionString = @"Server=localhost:5432;Database=postgres;User Id=postgres;Password=docker";



        public bool InsertCustomer(Customer newCustomer)
        {
			try
			{
				var result = false;

                using (var connection = new NpgsqlConnection(connectionString))
                {
                    using (var command = new NpgsqlCommand("INSERT INTO public.\"Customers\" (id, phoneNumber, name, surname) VALUES (@@id, @phoneNumber, @name, @surname)", connection))
                    {
                        command.Parameters.AddWithValue("@id", newCustomer.id);
                        command.Parameters.AddWithValue("@phoneNumber", newCustomer.phoneNumber);
                        command.Parameters.AddWithValue("@name", newCustomer.name);
                        command.Parameters.AddWithValue("@surname", newCustomer.surname);

                        // Open the database connection and execute the SQL command
                        connection.Open();
                        command.ExecuteNonQuery();
                        result = true;
                    }
                }


                return result;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				throw;
			}
        }


        public List<Customer> GetCustomers(string? phoneNumber = null)
        {
            try
            {
                var result = new List<Customer>();

                using (var connection = new NpgsqlConnection(connectionString))
                {
                    string slqSelectStatement = phoneNumber != null ? "SELECT * FROM public.\"Customers\" WHERE phoneNumber = @phoneNumber" : "SELECT * FROM public.\"Customers\"";
                    using (var command = new NpgsqlCommand(slqSelectStatement, connection))
                    {
                        if (phoneNumber != null)
                        {
                            command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                        }

                        // Open the database connection and execute the SQL command
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            // Read data from the data reader
                            while (reader.Read())
                            {
                                result.Add(new Customer
                                {
                                    id = reader.GetGuid(0),
                                    phoneNumber = reader.GetString(1),
                                    name = reader.GetString(2),
                                    surname = reader.GetString(3)
                                });
                            }
                        }

                        
                    }
                }


                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }



    }
}
