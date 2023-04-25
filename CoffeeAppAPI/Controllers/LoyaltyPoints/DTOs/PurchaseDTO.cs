namespace CoffeeAppAPI.Controllers.LoyaltyPoints.DTOs
{
    public class PurchaseDTO
    {
        public DateTime PurchaseDate { get; set; }

        public string Coffee { get; set; }

        public float LoyaltyPointCashValue { get; set; }

        public double LoyaltyPointValue { get; set; }

    }
}
