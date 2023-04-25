using CoffeeAppAPI.Controllers.LoyaltyPoints.DTOs;
using CoffeeAppAPI.Controllers.Purchase.DTOs;
using CoffeeAppAPI.Models.Purchase;

namespace CoffeeAppAPI.Mappers
{
    public class PurchaseMapper
    {
        public Purchase NewPurchaseDTOToModel(Guid coffeeId, Guid userId )
        {
			try
			{
				return new Purchase()
				{
					id = new Guid(),
					purchaseDate = DateTime.Now.ToString(),
					coffeeId = coffeeId,
					userId = userId,
					Allocated = false,
					LoyaltyPointId = string.Empty
                };
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				throw ex;
			}
        }


		public PurchaseDTO ModelToLoyaltyPurchaseDTO(Purchase purchase, string coffeeName)
		{
			try
			{
				return new PurchaseDTO()
				{
					Coffee = coffeeName,
					LoyaltyPointCashValue = 1,
					LoyaltyPointValue = 0.1,
					PurchaseDate =  DateTime.Parse(purchase.purchaseDate)
                };
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				throw;
			}
		}

    }
}
