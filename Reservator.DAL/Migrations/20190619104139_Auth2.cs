using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservator.DAL.Migrations
{
    public partial class Auth2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Salt",
                schema: "Reservator",
                table: "Users",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Reservator",
                table: "ObjectOwners",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2019, 6, 19, 12, 41, 38, 784, DateTimeKind.Local).AddTicks(5429));

            migrationBuilder.UpdateData(
                schema: "Reservator",
                table: "ObjectOwners",
                keyColumn: "ID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2019, 6, 19, 12, 41, 38, 784, DateTimeKind.Local).AddTicks(7278));

            migrationBuilder.UpdateData(
                schema: "Reservator",
                table: "ReservationObjects",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2019, 6, 19, 12, 41, 38, 790, DateTimeKind.Local).AddTicks(8635));

            migrationBuilder.UpdateData(
                schema: "Reservator",
                table: "Reservations",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2019, 6, 19, 12, 41, 38, 794, DateTimeKind.Local).AddTicks(3793), new DateTime(2019, 6, 19, 12, 41, 38, 794, DateTimeKind.Local).AddTicks(3879), new DateTime(2019, 6, 19, 12, 41, 38, 794, DateTimeKind.Local).AddTicks(7210) });

            migrationBuilder.UpdateData(
                schema: "Reservator",
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2019, 6, 19, 12, 41, 38, 781, DateTimeKind.Local).AddTicks(1660));

            migrationBuilder.UpdateData(
                schema: "Reservator",
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2019, 6, 19, 12, 41, 38, 781, DateTimeKind.Local).AddTicks(1968));

            migrationBuilder.UpdateData(
                schema: "Reservator",
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DateCreated", "Password", "Salt" },
                values: new object[] { new DateTime(2019, 6, 19, 12, 41, 38, 767, DateTimeKind.Local).AddTicks(3001), "hmA9I2JMwm16IdQQ3JhJTzsv8jwyX/JF5zgtsaJjtq8=", "TMhkVlX+WrYRHsnsQKn6ig==" });

            migrationBuilder.UpdateData(
                schema: "Reservator",
                table: "Users",
                keyColumn: "ID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2019, 6, 19, 12, 41, 38, 776, DateTimeKind.Local).AddTicks(1677));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                schema: "Reservator",
                table: "Users");

            migrationBuilder.UpdateData(
                schema: "Reservator",
                table: "ObjectOwners",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2019, 6, 19, 9, 41, 20, 947, DateTimeKind.Local).AddTicks(212));

            migrationBuilder.UpdateData(
                schema: "Reservator",
                table: "ObjectOwners",
                keyColumn: "ID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2019, 6, 19, 9, 41, 20, 947, DateTimeKind.Local).AddTicks(1405));

            migrationBuilder.UpdateData(
                schema: "Reservator",
                table: "ReservationObjects",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2019, 6, 19, 9, 41, 20, 952, DateTimeKind.Local).AddTicks(4054));

            migrationBuilder.UpdateData(
                schema: "Reservator",
                table: "Reservations",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2019, 6, 19, 9, 41, 20, 954, DateTimeKind.Local).AddTicks(7525), new DateTime(2019, 6, 19, 9, 41, 20, 954, DateTimeKind.Local).AddTicks(7568), new DateTime(2019, 6, 19, 9, 41, 20, 954, DateTimeKind.Local).AddTicks(8789) });

            migrationBuilder.UpdateData(
                schema: "Reservator",
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2019, 6, 19, 9, 41, 20, 945, DateTimeKind.Local).AddTicks(5262));

            migrationBuilder.UpdateData(
                schema: "Reservator",
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2019, 6, 19, 9, 41, 20, 945, DateTimeKind.Local).AddTicks(5337));

            migrationBuilder.UpdateData(
                schema: "Reservator",
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DateCreated", "Password" },
                values: new object[] { new DateTime(2019, 6, 19, 9, 41, 20, 934, DateTimeKind.Local).AddTicks(4535), "testuser" });

            migrationBuilder.UpdateData(
                schema: "Reservator",
                table: "Users",
                keyColumn: "ID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2019, 6, 19, 9, 41, 20, 942, DateTimeKind.Local).AddTicks(3235));
        }
    }
}
