namespace CoffeeAppAPI.Controllers.Purchase.DTOs
{
    public class NewPurchaseDTO
    {
        public List<Guid> CoffeeIds { get; set; }

        public string UserPhoneNumber { get; set; }
    }
}
