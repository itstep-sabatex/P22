using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cafe.Migrations.SQLite
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ClientTables",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Столик біля вікна" },
                    { 2, "Столик 1" },
                    { 3, "Столик 2" }
                });

            migrationBuilder.InsertData(
                table: "Nomenclatures",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Суп гороховий", 45.0 },
                    { 2, "Суп сирний", 75.0 },
                    { 3, "Суп харчо", 55.0 },
                    { 4, "Лоці", 105.0 },
                    { 5, "Картопля фрі", 60.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "Name", "Password" },
                values: new object[,]
                {
                    { 2, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Waiter", "12345" },
                    { 3, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manager", "12345" },
                    { 4, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Barmen", "12345" },
                    { 5, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cook", "12345" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Bill", "ClientTableId", "Date", "UserId" },
                values: new object[,]
                {
                    { 1, 0.0, 2, new DateTime(2024, 3, 2, 9, 30, 23, 0, DateTimeKind.Unspecified), 2 },
                    { 2, 0.0, 3, new DateTime(2024, 3, 2, 9, 50, 23, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 0.0, 1, new DateTime(2024, 3, 2, 9, 5, 23, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "Count", "NomenclatureId", "OrderId", "Price", "Sum" },
                values: new object[,]
                {
                    { 1, 2.0, 1, 1, 45.0, 90.0 },
                    { 2, 2.0, 4, 1, 105.0, 210.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Nomenclatures",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Nomenclatures",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Nomenclatures",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ClientTables",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClientTables",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Nomenclatures",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Nomenclatures",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClientTables",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
