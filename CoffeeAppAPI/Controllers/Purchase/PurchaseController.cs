using CoffeeAppAPI.Controllers.Purchase.DTOs;
using CoffeeAppAPI.Data.LoyaltyPoint;
using CoffeeAppAPI.Data.Purchase;
using CoffeeAppAPI.Data.User;
using CoffeeAppAPI.Mappers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoffeeAppAPI.Controllers.Purchase
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private UserRepo _userRepo = new UserRepo();
        private PurchaseRepo _purchaseRepo = new PurchaseRepo();
        private LoyaltyPointRepo _loyaltyPointsRepo = new LoyaltyPointRepo();
        private PurchaseMapper _purchaseMapper = new PurchaseMapper();

        
        // POST api/<PurchaseController>
        [HttpPost]
        [Route("NewPurchase")]
        public IActionResult NewPurchase([FromBody] NewPurchaseDTO newPurchaseDTO)
        {
            try
            {
                //Check if phone numebr exists if not just create a new user
                var allUsers = this._userRepo.GetCustomers();
                var customerID = !allUsers.Any(a => a.phoneNumber == newPurchaseDTO.UserPhoneNumber) ?
                                 new Guid() :
                                 allUsers.FirstOrDefault(a => a.phoneNumber == newPurchaseDTO.UserPhoneNumber).id;
                if (!allUsers.Any(a => a.phoneNumber == newPurchaseDTO.UserPhoneNumber))
                {
                    var createNewUserResult = this._userRepo.InsertCustomer(new Models.User.Customer()
                    {
                        id = customerID,
                        phoneNumber = newPurchaseDTO.UserPhoneNumber
                    });
                }

                //Add the new purchase item to the DB
                foreach (var newCoffeePurchase in newPurchaseDTO.CoffeeIds)
                {
                    var newPurchaseModel = this._purchaseMapper.NewPurchaseDTOToModel(newCoffeePurchase, customerID);
                    var createNewPurchase = this._purchaseRepo.InsertPurchase(newPurchaseModel);
                }


                //Check if the phone number has enough purchases to earn a loyalty point
                this.CheckIfPhoneNumberQualifiesForNewLoyaltyPoint(customerID.ToString());

                return Ok(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }



        private void CheckIfPhoneNumberQualifiesForNewLoyaltyPoint(string customerID)
        {
            try
            {
                var allPurchases = this._purchaseRepo.GetPurchases(customerID.ToString()).Where(a => !a.Allocated);
                if (allPurchases.Count() >= 10)
                {
                    var newLoyaltyPointID = new Guid();
                    var newLoyaltyPointsEntry = this._loyaltyPointsRepo.InsertLoyaltyPoint(new Models.LoyaltyPoint.LoyaltyPoint()
                    {
                        id = newLoyaltyPointID,
                        cashValue = 10,
                        redeemed = false,
                        userId = Guid.Parse(customerID)
                    });

                    //Update the purchases to mark them as linked to a loyalty point
                    foreach (var purchaseToBeUpdated in allPurchases.Take(10))
                    {
                        purchaseToBeUpdated.LoyaltyPointId = newLoyaltyPointID.ToString();
                        purchaseToBeUpdated.Allocated = true;
                        var updatePurchase = this._purchaseRepo.UpdatePurchase(purchaseToBeUpdated);
                    }

                    this.CheckIfPhoneNumberQualifiesForNewLoyaltyPoint(customerID);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        
    }
}
