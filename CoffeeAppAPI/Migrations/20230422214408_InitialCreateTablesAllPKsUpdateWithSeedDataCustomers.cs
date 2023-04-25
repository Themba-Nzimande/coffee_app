using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoffeeAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateTablesAllPKsUpdateWithSeedDataCustomers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "id", "name", "phoneNumber", "surname" },
                values: new object[,]
                {
                    { new Guid("05b74359-7a8b-4e53-8977-52e3afbb3e59"), "Test2 Name", "0813077747", "Test2 Surname" },
                    { new Guid("3b67ae4e-6729-4a34-94bb-0efdfcb2db56"), "Test1 Name", "0813066747", "Test1 Surname" },
                    { new Guid("c08a27eb-9818-4b43-b465-a09a11b40b2f"), "Test3 Name", "0813088747", "Test3 Surname" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "id",
                keyValue: new Guid("05b74359-7a8b-4e53-8977-52e3afbb3e59"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "id",
                keyValue: new Guid("3b67ae4e-6729-4a34-94bb-0efdfcb2db56"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "id",
                keyValue: new Guid("c08a27eb-9818-4b43-b465-a09a11b40b2f"));
        }
    }
}
