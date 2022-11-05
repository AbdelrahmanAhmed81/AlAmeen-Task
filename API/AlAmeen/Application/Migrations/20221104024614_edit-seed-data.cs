using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    public partial class editseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "Code",
                value: "87fde15e-5f94-40be-bda9-2deb223631e1");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "Code",
                value: "3e86dd78-5793-4af1-858c-dc73c0008020");

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderDetailId", "OrderId", "Price", "ProductId", "Quantity", "Tax", "Total" },
                values: new object[] { 4, 2, 7500m, 2, 3, 3150m, 22500m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                columns: new[] { "Date", "Subtotal", "Tax", "Total" },
                values: new object[] { new DateTime(2022, 11, 4, 4, 46, 13, 800, DateTimeKind.Local).AddTicks(3611), 40000m, 5600m, 34400m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                columns: new[] { "Date", "Subtotal", "Tax", "Total" },
                values: new object[] { new DateTime(2022, 11, 4, 4, 46, 13, 800, DateTimeKind.Local).AddTicks(3622), 61500m, 8610m, 52890m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailId",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "Code",
                value: "919c99d1-fe3d-4a46-b54a-cf5f2b6cbdae");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "Code",
                value: "ddfdac46-49c1-45da-8d73-6a659c75c508");

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                columns: new[] { "Date", "Subtotal", "Tax", "Total" },
                values: new object[] { new DateTime(2022, 11, 4, 4, 37, 21, 469, DateTimeKind.Local).AddTicks(2955), 0m, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                columns: new[] { "Date", "Subtotal", "Tax", "Total" },
                values: new object[] { new DateTime(2022, 11, 4, 4, 37, 21, 469, DateTimeKind.Local).AddTicks(2965), 0m, 0m, 0m });
        }
    }
}
