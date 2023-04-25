using System.ComponentModel.DataAnnotations;

namespace CoffeeAppAPI.Models.Purchase
{
    public class Purchase
    {
        [Key]
        public Guid id { get; set; }

        public string purchaseDate { get; set; }

        public Guid userId { get; set; }

        public Guid coffeeId { get; set; }

        public string LoyaltyPointId { get; set; }

        public bool Allocated { get; set; }
    }
}
