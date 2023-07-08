using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class identity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fa1b5fc-0c9b-42e0-8360-d27d08730087");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bab0be22-58b3-4130-9da2-7f439b9bee7f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "03a21276-a221-441f-87d7-35c0988809c1", "a363cbca-b4f4-4ca8-b2db-6d5b2ce66923", "Admin", "ADMIN" },
                    { "2004a7ff-0b52-4090-a673-06adf6e6f92f", "67dd024d-1092-4b1e-a609-609cbc5113b8", "Member", "MEMBER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03a21276-a221-441f-87d7-35c0988809c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2004a7ff-0b52-4090-a673-06adf6e6f92f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9fa1b5fc-0c9b-42e0-8360-d27d08730087", "ea3bfbe3-931f-4e26-ba37-264583fe3638", "Admin", "ADMIN" },
                    { "bab0be22-58b3-4130-9da2-7f439b9bee7f", "6050acc6-d39a-44d4-b50c-617f52193a23", "Member", "MEMBER" }
                });
        }
    }
}
