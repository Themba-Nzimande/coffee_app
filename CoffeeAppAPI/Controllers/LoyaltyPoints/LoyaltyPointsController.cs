using CoffeeAppAPI.Controllers.LoyaltyPoints.DTOs;
using CoffeeAppAPI.Data.Coffee;
using CoffeeAppAPI.Data.LoyaltyPoint;
using CoffeeAppAPI.Data.Purchase;
using CoffeeAppAPI.Data.User;
using CoffeeAppAPI.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeAppAPI.Controllers.LoyaltyPoints
{
    [ApiController]
    [AllowAnonymous]
    [Route("LoyaltyPoints")]
    public class LoyaltyPointsController : ControllerBase
    {

       private PurchaseRepo _purchaseRepo = new PurchaseRepo();
        private UserRepo _userRepo = new UserRepo();
        private LoyaltyPointRepo _loyaltyPointRepo = new LoyaltyPointRepo();
        private CoffeeRepo _coffeeRepo = new CoffeeRepo();
       private LoyaltyPointsMapper _LoyaltyPointMapper = new LoyaltyPointsMapper();
        private PurchaseMapper _purchaseMapper = new PurchaseMapper();

        private readonly ILogger<WeatherForecastController> _logger;

        public LoyaltyPointsController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("test")]
        public IActionResult Test()
        {
            try
            {
                return Ok("LP WORKS");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        [HttpGet]
        [Route("GetCustomerLoyaltyPoints")]
        public IActionResult GetCustomerLoyaltyPoints(string phoneNumber)
        {
            try
            {
                var result = new List<LoyaltyPointDTO>();

                result = this.CreateLoyaltyPointDTOs(phoneNumber);

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }


        [HttpGet]
        [Route("GetAllCustomerLoyaltyPoints")]
        public IActionResult GetAllCustomerLoyaltyPoints()
        {
            try
            {
                var result = new List<LoyaltyPointDTO>();

                var allCustomers = this._userRepo.GetCustomers();
                foreach (var customer in allCustomers)
                {
                    result.AddRange(this.CreateLoyaltyPointDTOs(customer.phoneNumber));
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public List<LoyaltyPointDTO> CreateLoyaltyPointDTOs(string phoneNumber)
        {
            try
            {
                var result = new List<LoyaltyPointDTO>();

                var user = this._userRepo.GetCustomers(phoneNumber);
                var allPurchases = this._purchaseRepo.GetPurchases(user.FirstOrDefault().id.ToString());
                var allLoyaltyPoints = this._loyaltyPointRepo.GetLoyaltyPoints(user.FirstOrDefault().id.ToString());
                var coffees = this._coffeeRepo.GetCoffee();

                foreach (var loyaltyPoint in allLoyaltyPoints)
                {
                    result.Add(this._LoyaltyPointMapper.ModelsToLoyaltyPointDTO(user.FirstOrDefault().phoneNumber,
                                                                                allPurchases, 
                                                                                coffees, 
                                                                                _purchaseMapper));
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
    }
}
