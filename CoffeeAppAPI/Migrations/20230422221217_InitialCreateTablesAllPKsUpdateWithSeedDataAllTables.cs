using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoffeeAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateTablesAllPKsUpdateWithSeedDataAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Coffees",
                columns: new[] { "id", "coffeeName", "price" },
                values: new object[,]
                {
                    { new Guid("6386fdf9-e734-4430-b53b-9260f2a7670a"), "Chai latte", 47.0 },
                    { new Guid("e0f68528-dfa6-4d83-9d52-cff38716b9ec"), "Cafe latte", 44.0 },
                    { new Guid("ebfe67bf-80b9-4b5c-82b9-a2851a4ab242"), "Cafe mocha", 52.0 }
                });

            migrationBuilder.InsertData(
                table: "LoyaltyPoints",
                columns: new[] { "id", "cashValue", "pointValue", "redeemed", "userId" },
                values: new object[] { new Guid("6d2dde63-94c7-4c22-8341-b05ccd7d8ef6"), 10.0, 1, false, new Guid("3b67ae4e-6729-4a34-94bb-0efdfcb2db56") });

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coffees",
                keyColumn: "id",
                keyValue: new Guid("6386fdf9-e734-4430-b53b-9260f2a7670a"));

            migrationBuilder.DeleteData(
                table: "Coffees",
                keyColumn: "id",
                keyValue: new Guid("e0f68528-dfa6-4d83-9d52-cff38716b9ec"));

            migrationBuilder.DeleteData(
                table: "Coffees",
                keyColumn: "id",
                keyValue: new Guid("ebfe67bf-80b9-4b5c-82b9-a2851a4ab242"));

            migrationBuilder.DeleteData(
                table: "LoyaltyPoints",
                keyColumn: "id",
                keyValue: new Guid("6d2dde63-94c7-4c22-8341-b05ccd7d8ef6"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("0951748c-770a-4bcc-831a-09df18d33ac2"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("19d94460-0bc1-4d73-9dfb-9aa88cae71ad"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("35d2e39e-1217-49de-b85f-9f39fa2a3948"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("58043290-7448-472a-88cf-e4094e3497e8"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("5aa6dcb8-0f6d-47d1-b507-3a694825c70e"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("75ddb6bd-962a-4df4-9f1e-2c24014dd2e7"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("a412e01e-1b18-4ec4-9e79-17f2a2c012c3"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("a8db2f20-b280-49dc-93a8-f21a43cb8ba9"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("ac01a251-1cbe-4474-86b5-29592ed1f972"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("be55517c-b858-437a-b85e-55efede53409"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("de62afa3-aeb1-4ad2-bf0a-60a1eb1120b0"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("e6989459-d332-492b-a163-3b7c7ef6d884"));

            migrationBuilder.DeleteData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("fe86a5bb-c91a-4868-adfe-55c643713f22"));
        }
    }
}
