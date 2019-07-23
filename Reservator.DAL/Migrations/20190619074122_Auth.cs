using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservator.DAL.Migrations
{
    public partial class Auth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                schema: "Reservator",
                table: "Users",
                newName: "Username");

            migrationBuilder.AddColumn<string>(
                name: "EmailConfirmed",
                schema: "Reservator",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                schema: "Reservator",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "Reservator",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    RoleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserID, x.RoleID });
                    table.ForeignKey(
                        name: "FK_UserRole_Roles_RoleID",
                        column: x => x.RoleID,
                        principalSchema: "Reservator",
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserID",
                        column: x => x.UserID,
                        principalSchema: "Reservator",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                schema: "Reservator",
                table: "Roles",
                columns: new[] { "ID", "Active", "DateCreated", "DateModified", "Description", "Name" },
                values: new object[] { 2, true, new DateTime(2019, 6, 19, 9, 41, 20, 945, DateTimeKind.Local).AddTicks(5337), null, "Admin role", "Admin" });

            migrationBuilder.InsertData(
                schema: "Reservator",
                table: "UserRole",
                columns: new[] { "UserID", "RoleID" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                schema: "Reservator",
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2019, 6, 19, 9, 41, 20, 934, DateTimeKind.Local).AddTicks(4535));

            migrationBuilder.InsertData(
                schema: "Reservator",
                table: "Users",
                columns: new[] { "ID", "Active", "DateCreated", "DateModified", "Email", "EmailConfirmed", "FirstName", "LastName", "Password", "Token", "Username" },
                values: new object[] { 2, true, new DateTime(2019, 6, 19, 9, 41, 20, 942, DateTimeKind.Local).AddTicks(3235), null, "admin@admin.admin", null, "Admin", "User", "adminuser", null, "aUser" });

            migrationBuilder.InsertData(
                schema: "Reservator",
                table: "UserRole",
                columns: new[] { "UserID", "RoleID" },
                values: new object[] { 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleID",
                schema: "Reservator",
                table: "UserRole",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "Reservator");

            migrationBuilder.DeleteData(
                schema: "Reservator",
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Reservator",
                table: "Users",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                schema: "Reservator",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Token",
                schema: "Reservator",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Username",
                schema: "Reservator",
                table: "Users",
                newName: "UserName");

            migrationBuilder.UpdateData(
                schema: "Reservator",
                table: "ObjectOwners",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2019, 5, 19, 14, 40, 48, 551, DateTimeKind.Local).AddTicks(8865));

            migrationBuilder.UpdateData(
                schema: "Reservator",
                table: "ObjectOwners",
                keyColumn: "ID",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2019, 5, 19, 14, 40, 48, 560, DateTimeKind.Local).AddTicks(2598));

            migrationBuilder.UpdateData(
                schema: "Reservator",
                table: "ReservationObjects",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2019, 5, 19, 14, 40, 48, 569, DateTimeKind.Local).AddTicks(1182));

            migrationBuilder.UpdateData(
                schema: "Reservator",
                table: "Reservations",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2019, 5, 19, 14, 40, 48, 572, DateTimeKind.Local).AddTicks(5580), new DateTime(2019, 5, 19, 14, 40, 48, 572, DateTimeKind.Local).AddTicks(5841), new DateTime(2019, 5, 19, 14, 40, 48, 572, DateTimeKind.Local).AddTicks(6829) });

            migrationBuilder.UpdateData(
                schema: "Reservator",
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2019, 5, 19, 14, 40, 48, 576, DateTimeKind.Local).AddTicks(7884));

            migrationBuilder.UpdateData(
                schema: "Reservator",
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2019, 5, 19, 14, 40, 48, 574, DateTimeKind.Local).AddTicks(9158));
        }
    }
}
