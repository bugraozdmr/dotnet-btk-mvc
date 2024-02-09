using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCWEB.Migrations
{
    public partial class identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6ea196fa-b707-485b-af5d-b642305d7753", "4d1fd397-47de-42cd-946d-c63841894aba", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "729b4282-9abf-4c66-9d00-aadf10df9492", "a136cba2-fcef-4474-b388-08644557c2c9", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f3b46c85-6cf6-4a47-bb49-b6cd1cb0a92c", "f3a9395b-6bc0-4c60-9e05-26985058c1fd", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ea196fa-b707-485b-af5d-b642305d7753");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "729b4282-9abf-4c66-9d00-aadf10df9492");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3b46c85-6cf6-4a47-bb49-b6cd1cb0a92c");
        }
    }
}
