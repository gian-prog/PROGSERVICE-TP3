using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TP3__FlappyBirb.Migrations
{
    /// <inheritdoc />
    public partial class seed1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "11111111-1111-1111-1111-111111111111", 0, "10083125-9aef-44f8-b21e-4df0540a12d4", "maxime@gmail.com", false, false, null, "MAXIME@GMAIL.COM", "MAXIME22", "AQAAAAIAAYagAAAAEFOW6EnJJp7jw6J1K5iDAe0Qq6guggvVUonwSDwzJyYiJOl3jnsx7ZRhpEeREv9lZA==", null, false, "6de70686-5978-48d8-b385-3b7a7674fbd7", false, "Maxime22" },
                    { "11111111-1111-1111-1111-111111111112", 0, "4fcad41e-51c1-4e19-aad8-49860095208f", "maximus@gmail.com", false, false, null, "MAXIMUS@GMAIL.COM", "MAXIMUS23", null, null, false, "b4909f81-8bbb-4adc-aba8-9bcff28831f9", false, "Maximus23" }
                });

            migrationBuilder.InsertData(
                table: "Scores",
                columns: new[] { "Id", "Date", "Score", "Temps", "UserId", "Visibilite" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 6, 17, 57, 50, 727, DateTimeKind.Local).AddTicks(2837), 1000, 120.0, null, true },
                    { 2, new DateTime(2024, 11, 6, 17, 57, 50, 727, DateTimeKind.Local).AddTicks(2890), 800, 60.0, null, true },
                    { 3, new DateTime(2024, 11, 6, 17, 57, 50, 788, DateTimeKind.Local).AddTicks(7450), 400, 200.0, null, true },
                    { 4, new DateTime(2024, 11, 6, 17, 57, 50, 788, DateTimeKind.Local).AddTicks(7524), 34, 5.0, null, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112");

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
