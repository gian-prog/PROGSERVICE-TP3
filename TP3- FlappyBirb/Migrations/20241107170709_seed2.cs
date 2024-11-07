using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP3__FlappyBirb.Migrations
{
    /// <inheritdoc />
    public partial class seed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a21cb42-2fd1-4f38-9b09-48ea47723a51", "AQAAAAIAAYagAAAAEFRaQr2gWIjCN+ox0X6jupVwwTqbb5fiPhFiblOmrnVk+ja9cJBBJolPcwOX1hkQwQ==", "03ddeea8-3ba4-4f9e-b0c3-6e5c6ef98085" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7d3c88f-7d5d-4a6b-a353-1352bda3b1d4", "AQAAAAIAAYagAAAAEJbERgcLdAVPJ87Sbo1+NCJe52U7wvycEV5i8YlRRmH3P+Xg9D5tRZByBj9jrGjN7Q==", "0bc1d25d-15fb-4e1b-ad59-ed068236cf52" });

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2024, 11, 7, 12, 7, 8, 6, DateTimeKind.Local).AddTicks(496), "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2024, 11, 7, 12, 7, 8, 6, DateTimeKind.Local).AddTicks(610), "11111111-1111-1111-1111-111111111111" });

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2024, 11, 7, 12, 7, 8, 115, DateTimeKind.Local).AddTicks(5538), "11111111-1111-1111-1111-111111111112" });

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2024, 11, 7, 12, 7, 8, 115, DateTimeKind.Local).AddTicks(5754), "11111111-1111-1111-1111-111111111112" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "679e1be2-d83c-45ca-bb50-a750e215ea2b", "AQAAAAIAAYagAAAAEAtZxdlWnIpA8aFDcVgPKp0kGjSMz6IG+0hOtNoNJbaonc/OTx/BAJSOirsW8U+xjA==", "30766c6a-ea34-424d-a0b8-62e572fe77d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00012f44-c501-4481-99fa-d0750a4c10ad", "AQAAAAIAAYagAAAAEO0enjUXMj3ZWKx+9FUOtd0faeI1ZTJ85Xo5P88LT5lW9tEW1l8rJkwmL2klzYhpzg==", "803b1ecf-4756-41bf-be00-dbf7242236b2" });

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2024, 11, 7, 11, 49, 52, 971, DateTimeKind.Local).AddTicks(2144), null });

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2024, 11, 7, 11, 49, 52, 971, DateTimeKind.Local).AddTicks(2266), null });

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2024, 11, 7, 11, 49, 53, 62, DateTimeKind.Local).AddTicks(3120), null });

            migrationBuilder.UpdateData(
                table: "Scores",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "UserId" },
                values: new object[] { new DateTime(2024, 11, 7, 11, 49, 53, 62, DateTimeKind.Local).AddTicks(3251), null });
        }
    }
}
