namespace CoffeeAppAPI.Controllers.LoyaltyPoints.DTOs
{
    public class LoyaltyPointDTO
    {
        public string CustomerPhoneNumber { get; set; }

        public float cashValue { get; set; }

        public int loyaltyPointValue { get; set; }

        public List<PurchaseDTO> PurchasesDTO { get; set; }

        public bool redeemed { get; set; }

        
    }
}
