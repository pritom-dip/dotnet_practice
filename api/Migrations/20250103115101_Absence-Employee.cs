using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AbsenceEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f7c1b75-d287-4b69-b2d2-d823145912c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a87ba718-6ee0-4cdf-b585-3f5c2102e7ac");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e22e2758-af9f-4c5b-b6ae-63cd16ead8a5", null, "Admin", "ADMIN" },
                    { "e6fe57c4-b038-4b90-8bc1-7983173b6ff0", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e22e2758-af9f-4c5b-b6ae-63cd16ead8a5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6fe57c4-b038-4b90-8bc1-7983173b6ff0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f7c1b75-d287-4b69-b2d2-d823145912c0", null, "User", "USER" },
                    { "a87ba718-6ee0-4cdf-b585-3f5c2102e7ac", null, "Admin", "ADMIN" }
                });
        }
    }
}
