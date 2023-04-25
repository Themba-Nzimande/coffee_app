using System.ComponentModel.DataAnnotations;

namespace CoffeeAppAPI.Models.LoyaltyPoint
{
    public class LoyaltyPoint
    {
        [Key]
        public Guid id { get; set; }

        public double cashValue { get; set; }

        public int pointValue { get; set; }

        public bool redeemed { get; set; }

        public Guid userId { get; set; }


    }
}
