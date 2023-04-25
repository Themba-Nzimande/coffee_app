namespace CoffeeAppAPI.Controllers.LoyaltyPoints.DTOs
{
    public class CustomerLoyaltyPointsDTO
    {
        public string customerPhoneNumber { get; set; }

        public int TotalLoyaltyPoints { get; set; }

        public int RedeemedLoyaltyPoints { get; set; }

        public int RemainingLoyaltyPoints { get; set; }
    }
}
