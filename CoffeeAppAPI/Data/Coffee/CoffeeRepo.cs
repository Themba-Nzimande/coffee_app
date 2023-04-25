using Npgsql;
using System.Data.SqlClient;

namespace CoffeeAppAPI.Data.Coffee
{
    public class CoffeeRepo
    {
        string connectionString = "Host=localhost:5432;Database=postgres;Username=postgres;Password=docker";


        public bool InsertLoyaltyPoint(Models.Coffee.Coffee newCoffee)
        {
            try
            {
                var result = false;

                using (var connection = new NpgsqlConnection(connectionString))
                {
                    using (var command = new NpgsqlCommand("INSERT INTO public.\"Coffees\" (id, coffeeName, price) VALUES (@id, @coffeeName, @price)", connection))
                    {
                        command.Parameters.AddWithValue("@id", newCoffee.id);
                        command.Parameters.AddWithValue("@coffeeName", newCoffee.coffeeName);
                        command.Parameters.AddWithValue("@price", newCoffee.price);

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


        public List<Models.Coffee.Coffee> GetCoffee(string? coffeName = null)
        {
            try
            {
                var result = new List<Models.Coffee.Coffee>();

                using (var connection = new NpgsqlConnection(connectionString))
                {
                    string slqSelectStatement = coffeName != null ? "SELECT * FROM public.\"Coffees\" WHERE coffeName = @coffeName" : "SELECT * FROM public.\"Coffees\"";
                    using (var command = new NpgsqlCommand(slqSelectStatement, connection))
                    {
                        if (coffeName != null)
                        {
                            command.Parameters.AddWithValue("@coffeName", coffeName);
                        }

                        // Open the database connection and execute the SQL command
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            // Read data from the data reader
                            while (reader.Read())
                            {
                                result.Add(new Models.Coffee.Coffee
                                {
                                    id = reader.GetGuid(0),
                                    coffeeName = reader.GetString(1),
                                    price = Double.Parse(reader.GetValue(2).ToString()),
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
