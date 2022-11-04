using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Code", "Email", "FirstName", "IsActive", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "919c99d1-fe3d-4a46-b54a-cf5f2b6cbdae", "Abdelrahman@yahoo.com", "Abdelrahman", true, "Ahmed", "01555447488" },
                    { 2, "ddfdac46-49c1-45da-8d73-6a659c75c508", "Mohammed@yahoo.com", "Mohammed", true, "Saeed", "01531157898" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Gaming Chair", "Chair", 5000m },
                    { 2, "Modern desk", "Desk", 7500m },
                    { 3, "Wooden Table", "Table", 6500m }
                });

            migrationBuilder.InsertData(
                table: "CustomerAddresses",
                columns: new[] { "CustomerAddressId", "AddressLine1", "AddressLine2", "City", "Country", "CustomerId", "IsBillingAddress", "IsShippingAddress", "PostalCode", "State" },
                values: new object[,]
                {
                    { 1, "45A Al Giza St", "Giza Square", "Giza", "Egypt", 1, true, false, "26566", "Giza" },
                    { 2, "35B mohammed ismail St", "Al Haram", "Giza", "Egypt", 1, false, true, "54223", "Giza" },
                    { 3, "5C mathaf al matrya", "Ain Shams", "Cairo", "Egypt", 2, true, true, "45722", "Cairo" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CustomerId", "Date", "Status", "Subtotal", "Tax", "Total" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 11, 4, 4, 37, 21, 469, DateTimeKind.Local).AddTicks(2955), "Deliverd", 0m, 0m, 0m },
                    { 2, 2, new DateTime(2022, 11, 4, 4, 37, 21, 469, DateTimeKind.Local).AddTicks(2965), "Waiting", 0m, 0m, 0m }
                });

            migrationBuilder.InsertData(
                table: "OrderBillingAddresses",
                columns: new[] { "OrderBillingAddressId", "AddressLine1", "AddressLine2", "City", "Country", "OrderId", "PostalCode", "State" },
                values: new object[,]
                {
                    { 1, "45A Al Giza St", "Giza Square", "Giza", "Egypt", 1, "26566", "Giza" },
                    { 2, "35B mohammed ismail St", "Al Haram", "Giza", "Egypt", 2, "54223", "Giza" }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderDetailId", "OrderId", "Price", "ProductId", "Quantity", "Tax", "Total" },
                values: new object[,]
                {
                    { 1, 1, 5000m, 1, 5, 3500m, 25000m },
                    { 2, 1, 7500m, 2, 2, 2100m, 15000m },
                    { 3, 2, 6500m, 3, 6, 5460m, 39000m }
                });

            migrationBuilder.InsertData(
                table: "OrderShippingAddresses",
                columns: new[] { "OrderShippingAddressId", "AddressLine1", "AddressLine2", "City", "Country", "OrderId", "PostalCode", "State" },
                values: new object[,]
                {
                    { 1, "5C mathaf al matrya", "Ain Shams", "Cairo", "Egypt", 1, "45722", "Cairo" },
                    { 2, "35B mohammed ismail St", "Al Haram", "Giza", "Egypt", 2, "54223", "Giza" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomerAddresses",
                keyColumn: "CustomerAddressId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CustomerAddresses",
                keyColumn: "CustomerAddressId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CustomerAddresses",
                keyColumn: "CustomerAddressId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderBillingAddresses",
                keyColumn: "OrderBillingAddressId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderBillingAddresses",
                keyColumn: "OrderBillingAddressId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderShippingAddresses",
                keyColumn: "OrderShippingAddressId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderShippingAddresses",
                keyColumn: "OrderShippingAddressId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);
        }
    }
}
