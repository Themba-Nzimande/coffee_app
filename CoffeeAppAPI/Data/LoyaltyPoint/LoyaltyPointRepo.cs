using System.Data.SqlClient;
using CoffeeAppAPI.Models.LoyaltyPoint;
using Npgsql;

namespace CoffeeAppAPI.Data.LoyaltyPoint
{
    public class LoyaltyPointRepo
    {
        string connectionString = @"Server=localhost:5432;Database=postgres;User Id=postgres;Password=docker";


        public bool InsertLoyaltyPoint(Models.LoyaltyPoint.LoyaltyPoint newLoyaltyPoint)
        {
            try
            {
                var result = false;

                using (var connection = new NpgsqlConnection(connectionString))
                {
                    using (var command = new NpgsqlCommand("INSERT INTO public.\"LoyaltyPoints\" (id, pointValue, cashValue, redeemed, userId) VALUES (@id, @pointValue, @cashValue, @redeemed, @userId)", connection))
                    {
                        command.Parameters.AddWithValue("@id", newLoyaltyPoint.id);
                        command.Parameters.AddWithValue("@pointValue", newLoyaltyPoint.pointValue);
                        command.Parameters.AddWithValue("@cashValue", newLoyaltyPoint.cashValue);
                        command.Parameters.AddWithValue("@redeemed", newLoyaltyPoint.redeemed);
                        command.Parameters.AddWithValue("@userId", newLoyaltyPoint.userId);

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


        public List<Models.LoyaltyPoint.LoyaltyPoint> GetLoyaltyPoints(string? userId)
        {
            try
            {
                var result = new List<Models.LoyaltyPoint.LoyaltyPoint>();

                using (var connection = new NpgsqlConnection(connectionString))
                {
                    string slqSelectStatement = userId != null ? "SELECT * FROM public.\"LoyaltyPoints\" WHERE userid = @userId" : "SELECT * FROM public.\"LoyaltyPoints\"";
                    using (var command = new NpgsqlCommand(slqSelectStatement, connection))
                    {
                        if (userId != null)
                        {
                            command.Parameters.AddWithValue("@userId", Guid.Parse(userId));
                        }

                        // Open the database connection and execute the SQL command
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            // Read data from the data reader
                            while (reader.Read())
                            {
                                var tt = reader.GetValue(1).ToString();
                                result.Add(new Models.LoyaltyPoint.LoyaltyPoint
                                {
                                    id = reader.GetGuid(0),
                                    cashValue = Double.Parse(reader.GetValue(1).ToString()),
                                    pointValue = reader.GetInt32(2),
                                    redeemed = reader.GetBoolean(3),
                                    userId = reader.GetGuid(4)
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
