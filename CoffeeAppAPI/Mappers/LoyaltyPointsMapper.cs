using CoffeeAppAPI.Controllers.LoyaltyPoints.DTOs;
using CoffeeAppAPI.Models.Coffee;
using CoffeeAppAPI.Models.LoyaltyPoint;
using CoffeeAppAPI.Models.Purchase;
using CoffeeAppAPI.Models.User;

namespace CoffeeAppAPI.Mappers
{
    public class LoyaltyPointsMapper
    {
        public LoyaltyPointDTO ModelsToLoyaltyPointDTO(string customerPhoneNumber,
													   List<Purchase> purchases, 
													   List<Coffee> coffees, 
													   PurchaseMapper _purchaseMapper)
        {
			try
			{
				var listOfPurchasesDTO = new List<PurchaseDTO>();
				foreach (var purchase in purchases)
				{
					listOfPurchasesDTO.Add(_purchaseMapper.ModelToLoyaltyPurchaseDTO(purchase, coffees.FirstOrDefault(a => a.id == purchase.coffeeId).coffeeName));
				}
				return new LoyaltyPointDTO()
				{
					CustomerPhoneNumber = customerPhoneNumber,
					cashValue = 10,
					loyaltyPointValue = 1,
					PurchasesDTO = listOfPurchasesDTO

                };
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				throw ex;
			}
        }



    }
}
