using System.ComponentModel.DataAnnotations;

namespace CoffeeAppAPI.Models.Coffee
{
    public class Coffee
    {
        [Key]
        public Guid id { get; set; }

        public string coffeeName { get; set; }

        public double price { get; set; }
    }
}
