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
                    { "11111111-1111-1111-1111-111111111111", 0, "ade44dc4-3323-419c-b738-49a1218fcafd", "maxime@gmail.com", false, false, null, "MAXIME@GMAIL.COM", "MAXIME22", "AQAAAAIAAYagAAAAEKB/qcdguStP/gXrZIUXS0jCyuwbyTClWzq6fI3cfVSBQn3SbPEpqYe/w/2SLD9QTg==", null, false, "a5b70afb-2ef1-4c29-b5ba-c69870bb266d", false, "Maxime22" },
                    { "11111111-1111-1111-1111-111111111112", 0, "3ffee646-62b6-49f9-8b62-a7cf3a615ef7", "maximus@gmail.com", false, false, null, "MAXIMUS@GMAIL.COM", "MAXIMUS23", "AQAAAAIAAYagAAAAEG9MwdXAnvMSCgdja3Zh4ez3nbhlLbts7YKd7zy7k31+TbJI8k2jvmMcHUDGozo4eg==", null, false, "c2c707db-4e32-451c-8f75-42889cc8e023", false, "Maximus23" }
                });

            migrationBuilder.InsertData(
                table: "Scores",
                columns: new[] { "Id", "Date", "Score", "Temps", "UserId", "Visibilite" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 7, 8, 21, 44, 58, DateTimeKind.Local).AddTicks(9672), 1000, 120.0, null, true },
                    { 2, new DateTime(2024, 11, 7, 8, 21, 44, 58, DateTimeKind.Local).AddTicks(9790), 800, 60.0, null, false },
                    { 3, new DateTime(2024, 11, 7, 8, 21, 44, 163, DateTimeKind.Local).AddTicks(5935), 400, 200.0, null, true },
                    { 4, new DateTime(2024, 11, 7, 8, 21, 44, 163, DateTimeKind.Local).AddTicks(6142), 34, 5.0, null, false }
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
