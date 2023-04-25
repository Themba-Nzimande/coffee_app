using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateAndSeedDataAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("0951748c-770a-4bcc-831a-09df18d33ac2"),
                column: "purchaseDate",
                value: "2023/04/24 00:59:42");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("19d94460-0bc1-4d73-9dfb-9aa88cae71ad"),
                column: "purchaseDate",
                value: "2023/05/04 00:59:42");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("35d2e39e-1217-49de-b85f-9f39fa2a3948"),
                column: "purchaseDate",
                value: "2023/04/23 01:39:42");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("58043290-7448-472a-88cf-e4094e3497e8"),
                column: "purchaseDate",
                value: "2023/04/29 00:59:42");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("5aa6dcb8-0f6d-47d1-b507-3a694825c70e"),
                column: "purchaseDate",
                value: "2023/04/27 00:59:42");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("75ddb6bd-962a-4df4-9f1e-2c24014dd2e7"),
                column: "purchaseDate",
                value: "2023/04/25 00:59:42");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("a412e01e-1b18-4ec4-9e79-17f2a2c012c3"),
                column: "purchaseDate",
                value: "2023/04/23 00:59:42");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("a8db2f20-b280-49dc-93a8-f21a43cb8ba9"),
                column: "purchaseDate",
                value: "2023/05/03 00:59:42");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("ac01a251-1cbe-4474-86b5-29592ed1f972"),
                column: "purchaseDate",
                value: "2023/04/30 00:59:42");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("be55517c-b858-437a-b85e-55efede53409"),
                column: "purchaseDate",
                value: "2023/05/05 00:59:42");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("de62afa3-aeb1-4ad2-bf0a-60a1eb1120b0"),
                column: "purchaseDate",
                value: "2023/04/25 00:59:42");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("e6989459-d332-492b-a163-3b7c7ef6d884"),
                column: "purchaseDate",
                value: "2023/04/24 00:59:42");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("fe86a5bb-c91a-4868-adfe-55c643713f22"),
                column: "purchaseDate",
                value: "2023/04/23 05:59:42");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("0951748c-770a-4bcc-831a-09df18d33ac2"),
                column: "purchaseDate",
                value: "2023/04/24 00:57:15");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("19d94460-0bc1-4d73-9dfb-9aa88cae71ad"),
                column: "purchaseDate",
                value: "2023/05/04 00:57:15");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("35d2e39e-1217-49de-b85f-9f39fa2a3948"),
                column: "purchaseDate",
                value: "2023/04/23 01:37:15");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("58043290-7448-472a-88cf-e4094e3497e8"),
                column: "purchaseDate",
                value: "2023/04/29 00:57:15");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("5aa6dcb8-0f6d-47d1-b507-3a694825c70e"),
                column: "purchaseDate",
                value: "2023/04/27 00:57:15");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("75ddb6bd-962a-4df4-9f1e-2c24014dd2e7"),
                column: "purchaseDate",
                value: "2023/04/25 00:57:15");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("a412e01e-1b18-4ec4-9e79-17f2a2c012c3"),
                column: "purchaseDate",
                value: "2023/04/23 00:57:15");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("a8db2f20-b280-49dc-93a8-f21a43cb8ba9"),
                column: "purchaseDate",
                value: "2023/05/03 00:57:15");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("ac01a251-1cbe-4474-86b5-29592ed1f972"),
                column: "purchaseDate",
                value: "2023/04/30 00:57:15");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("be55517c-b858-437a-b85e-55efede53409"),
                column: "purchaseDate",
                value: "2023/05/05 00:57:15");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("de62afa3-aeb1-4ad2-bf0a-60a1eb1120b0"),
                column: "purchaseDate",
                value: "2023/04/25 00:57:15");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("e6989459-d332-492b-a163-3b7c7ef6d884"),
                column: "purchaseDate",
                value: "2023/04/24 00:57:15");

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "id",
                keyValue: new Guid("fe86a5bb-c91a-4868-adfe-55c643713f22"),
                column: "purchaseDate",
                value: "2023/04/23 05:57:15");
        }
    }
}
