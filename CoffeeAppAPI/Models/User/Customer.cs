using System.ComponentModel.DataAnnotations;

namespace CoffeeAppAPI.Models.User
{
    public class Customer
    {
        [Key]
        public Guid id { get; set; }

        public string phoneNumber { get; set; }

        public string name { get; set; }

        public string surname { get; set; }
    }
}
