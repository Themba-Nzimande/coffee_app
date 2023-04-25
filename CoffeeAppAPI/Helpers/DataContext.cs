using CoffeeAppAPI.Models.Coffee;
using CoffeeAppAPI.Models.LoyaltyPoint;
using CoffeeAppAPI.Models.Purchase;
using CoffeeAppAPI.Models.User;
using Microsoft.EntityFrameworkCore;

namespace CoffeeAppAPI.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Coffee> Coffees { get; set; }

        public DbSet<LoyaltyPoint> LoyaltyPoints { get; set; }

        public DbSet<Purchase> Purchases { get; set; }


        //seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Customers seed
            modelBuilder.Entity<Customer>()
                        .HasData(
                         new Customer { id = Guid.Parse("3b67ae4e-6729-4a34-94bb-0efdfcb2db56"), name = "Test1 Name", surname = "Test1 Surname", phoneNumber = "0813066747" },
                         new Customer { id = Guid.Parse("05b74359-7a8b-4e53-8977-52e3afbb3e59"), name = "Test2 Name", surname = "Test2 Surname", phoneNumber = "0813077747" },
                         new Customer { id = Guid.Parse("c08a27eb-9818-4b43-b465-a09a11b40b2f"), name = "Test3 Name", surname = "Test3 Surname", phoneNumber = "0813088747" });



            modelBuilder.Entity<Coffee>()
                        .HasData(
                         new Coffee { id = Guid.Parse("e0f68528-dfa6-4d83-9d52-cff38716b9ec"), coffeeName = "Cafe latte", price = 44 },
                         new Coffee { id = Guid.Parse("ebfe67bf-80b9-4b5c-82b9-a2851a4ab242"), coffeeName = "Cafe mocha", price = 52 },
                         new Coffee { id = Guid.Parse("6386fdf9-e734-4430-b53b-9260f2a7670a"), coffeeName = "Chai latte", price = 47 });


            modelBuilder.Entity<LoyaltyPoint>()
                        .HasData(
                         new LoyaltyPoint { id = Guid.Parse("6d2dde63-94c7-4c22-8341-b05ccd7d8ef6"), userId = Guid.Parse("3b67ae4e-6729-4a34-94bb-0efdfcb2db56"), pointValue = 1, cashValue = 10, redeemed = false });


            modelBuilder.Entity<Purchase>()
                        .HasData(
                         new Purchase { id = Guid.Parse("a412e01e-1b18-4ec4-9e79-17f2a2c012c3"), userId = Guid.Parse("3b67ae4e-6729-4a34-94bb-0efdfcb2db56"), Allocated = true, coffeeId = Guid.Parse("e0f68528-dfa6-4d83-9d52-cff38716b9ec"), LoyaltyPointId = "6d2dde63-94c7-4c22-8341-b05ccd7d8ef6", purchaseDate = DateTime.Now.ToString()},
                         new Purchase { id = Guid.Parse("35d2e39e-1217-49de-b85f-9f39fa2a3948"), userId = Guid.Parse("3b67ae4e-6729-4a34-94bb-0efdfcb2db56"), Allocated = true, coffeeId = Guid.Parse("ebfe67bf-80b9-4b5c-82b9-a2851a4ab242"), LoyaltyPointId = "6d2dde63-94c7-4c22-8341-b05ccd7d8ef6", purchaseDate = DateTime.Now.AddMinutes(40).ToString() },
                         new Purchase { id = Guid.Parse("be55517c-b858-437a-b85e-55efede53409"), userId = Guid.Parse("3b67ae4e-6729-4a34-94bb-0efdfcb2db56"), Allocated = true, coffeeId = Guid.Parse("e0f68528-dfa6-4d83-9d52-cff38716b9ec"), LoyaltyPointId = "6d2dde63-94c7-4c22-8341-b05ccd7d8ef6", purchaseDate = DateTime.Now.AddDays(12).ToString() },
                         new Purchase { id = Guid.Parse("19d94460-0bc1-4d73-9dfb-9aa88cae71ad"), userId = Guid.Parse("3b67ae4e-6729-4a34-94bb-0efdfcb2db56"), Allocated = true, coffeeId = Guid.Parse("ebfe67bf-80b9-4b5c-82b9-a2851a4ab242"), LoyaltyPointId = "6d2dde63-94c7-4c22-8341-b05ccd7d8ef6", purchaseDate = DateTime.Now.AddDays(11).ToString() },
                         new Purchase { id = Guid.Parse("0951748c-770a-4bcc-831a-09df18d33ac2"), userId = Guid.Parse("3b67ae4e-6729-4a34-94bb-0efdfcb2db56"), Allocated = true, coffeeId = Guid.Parse("ebfe67bf-80b9-4b5c-82b9-a2851a4ab242"), LoyaltyPointId = "6d2dde63-94c7-4c22-8341-b05ccd7d8ef6", purchaseDate = DateTime.Now.AddDays(1).ToString() },
                         new Purchase { id = Guid.Parse("a8db2f20-b280-49dc-93a8-f21a43cb8ba9"), userId = Guid.Parse("3b67ae4e-6729-4a34-94bb-0efdfcb2db56"), Allocated = true, coffeeId = Guid.Parse("e0f68528-dfa6-4d83-9d52-cff38716b9ec"), LoyaltyPointId = "6d2dde63-94c7-4c22-8341-b05ccd7d8ef6", purchaseDate = DateTime.Now.AddDays(10).ToString() },
                         new Purchase { id = Guid.Parse("ac01a251-1cbe-4474-86b5-29592ed1f972"), userId = Guid.Parse("3b67ae4e-6729-4a34-94bb-0efdfcb2db56"), Allocated = true, coffeeId = Guid.Parse("ebfe67bf-80b9-4b5c-82b9-a2851a4ab242"), LoyaltyPointId = "6d2dde63-94c7-4c22-8341-b05ccd7d8ef6", purchaseDate = DateTime.Now.AddDays(7).ToString() },
                         new Purchase { id = Guid.Parse("fe86a5bb-c91a-4868-adfe-55c643713f22"), userId = Guid.Parse("3b67ae4e-6729-4a34-94bb-0efdfcb2db56"), Allocated = true, coffeeId = Guid.Parse("ebfe67bf-80b9-4b5c-82b9-a2851a4ab242"), LoyaltyPointId = "6d2dde63-94c7-4c22-8341-b05ccd7d8ef6", purchaseDate = DateTime.Now.AddHours(5).ToString() },
                         new Purchase { id = Guid.Parse("75ddb6bd-962a-4df4-9f1e-2c24014dd2e7"), userId = Guid.Parse("3b67ae4e-6729-4a34-94bb-0efdfcb2db56"), Allocated = true, coffeeId = Guid.Parse("6386fdf9-e734-4430-b53b-9260f2a7670a"), LoyaltyPointId = "6d2dde63-94c7-4c22-8341-b05ccd7d8ef6", purchaseDate = DateTime.Now.AddDays(2).ToString() },
                         new Purchase { id = Guid.Parse("58043290-7448-472a-88cf-e4094e3497e8"), userId = Guid.Parse("3b67ae4e-6729-4a34-94bb-0efdfcb2db56"), Allocated = true, coffeeId = Guid.Parse("6386fdf9-e734-4430-b53b-9260f2a7670a"), LoyaltyPointId = "6d2dde63-94c7-4c22-8341-b05ccd7d8ef6", purchaseDate = DateTime.Now.AddDays(6).ToString() },
                         new Purchase { id = Guid.Parse("e6989459-d332-492b-a163-3b7c7ef6d884"), userId = Guid.Parse("3b67ae4e-6729-4a34-94bb-0efdfcb2db56"), Allocated = true, coffeeId = Guid.Parse("e0f68528-dfa6-4d83-9d52-cff38716b9ec"), LoyaltyPointId = "6d2dde63-94c7-4c22-8341-b05ccd7d8ef6", purchaseDate = DateTime.Now.AddDays(1).ToString() },
                         new Purchase { id = Guid.Parse("5aa6dcb8-0f6d-47d1-b507-3a694825c70e"), userId = Guid.Parse("3b67ae4e-6729-4a34-94bb-0efdfcb2db56"), Allocated = true, coffeeId = Guid.Parse("e0f68528-dfa6-4d83-9d52-cff38716b9ec"), LoyaltyPointId = "6d2dde63-94c7-4c22-8341-b05ccd7d8ef6", purchaseDate = DateTime.Now.AddDays(4).ToString() },
                         new Purchase { id = Guid.Parse("de62afa3-aeb1-4ad2-bf0a-60a1eb1120b0"), userId = Guid.Parse("3b67ae4e-6729-4a34-94bb-0efdfcb2db56"), Allocated = true, coffeeId = Guid.Parse("e0f68528-dfa6-4d83-9d52-cff38716b9ec"), LoyaltyPointId = "6d2dde63-94c7-4c22-8341-b05ccd7d8ef6", purchaseDate = DateTime.Now.AddDays(2).ToString() });

        }
    }
}
