using CoffeeAppAPI.Models.User;
using System.Data.SqlClient;
using CoffeeAppAPI.Models.Purchase;
using Npgsql;

namespace CoffeeAppAPI.Data.Purchase
{
    public class PurchaseRepo
    {

        string connectionString = @"Server=localhost:5432;Database=postgres;User Id=postgres;Password=docker";


        public bool InsertPurchase(Models.Purchase.Purchase newPurchase)
        {
            try
            {
                var result = false;

                using (var connection = new NpgsqlConnection(connectionString))
                {
                    using (var command = new NpgsqlCommand("INSERT INTO public.\"Purchase\" (id, purchaseDate, userId, coffeId) VALUES (@id, @purchaseDate, @userId, @coffeId)", connection))
                    {
                        command.Parameters.AddWithValue("@id", newPurchase.id);
                        command.Parameters.AddWithValue("@purchaseDate", newPurchase.purchaseDate);
                        command.Parameters.AddWithValue("@userId", newPurchase.userId);
                        command.Parameters.AddWithValue("@coffeId", newPurchase.coffeeId);

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


        public bool UpdatePurchase(Models.Purchase.Purchase existingPurchase)
        {
            try
            {
                var result = false;

                using (var connection = new NpgsqlConnection(connectionString))
                {
                    
                    using (var command = new NpgsqlCommand("UPDATE public.\"Purchase\" SET LoyaltyPointId = @LoyaltyPointId, Allocated = @Allocated WHERE Id = @id", connection))
                    {
                        command.Parameters.AddWithValue("@id", existingPurchase.id);
                        command.Parameters.AddWithValue("@LoyaltyPointId", existingPurchase.LoyaltyPointId);
                        command.Parameters.AddWithValue("@Allocated", existingPurchase.Allocated);

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


        public List<Models.Purchase.Purchase> GetPurchases(string? userId = null)
        {
            try
            {
                var result = new List<Models.Purchase.Purchase>();

                using (var connection = new NpgsqlConnection(connectionString))
                {
                    string slqSelectStatement = userId != null ? "SELECT * FROM public.\"Purchases\" WHERE userid = @userid" : "SELECT * FROM public.\"Purchases\"";
                    using (var command = new NpgsqlCommand(slqSelectStatement, connection))
                    {
                        if (userId != null)
                        {
                            command.Parameters.AddWithValue("@userid", Guid.Parse(userId));
                        }

                        // Open the database connection and execute the SQL command
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            // Read data from the data reader
                            while (reader.Read())
                            {
                                result.Add(new Models.Purchase.Purchase
                                {
                                    id = reader.GetGuid(0),
                                    purchaseDate = reader.GetString(1),
                                    userId = reader.GetGuid(2),
                                    coffeeId = reader.GetGuid(3)
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
