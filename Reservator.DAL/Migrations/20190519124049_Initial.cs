using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Reservator.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Reservator");

            migrationBuilder.CreateTable(
                name: "ObjectOwners",
                schema: "Reservator",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: true, defaultValueSql: "1"),
                    DateCreated = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    DateModified = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectOwners", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Reservator",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: true, defaultValueSql: "1"),
                    DateCreated = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    DateModified = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Reservator",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: true, defaultValueSql: "1"),
                    DateCreated = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    DateModified = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    UserName = table.Column<string>(maxLength: 255, nullable: false),
                    FirstName = table.Column<string>(maxLength: 255, nullable: false),
                    LastName = table.Column<string>(maxLength: 255, nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ReservationObjects",
                schema: "Reservator",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: true, defaultValueSql: "1"),
                    DateCreated = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    DateModified = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    MaximumReservationTime = table.Column<long>(nullable: false),
                    ObjectOwnerID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationObjects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReservationObjects_ObjectOwners_ObjectOwnerID",
                        column: x => x.ObjectOwnerID,
                        principalSchema: "Reservator",
                        principalTable: "ObjectOwners",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                schema: "Reservator",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: true, defaultValueSql: "1"),
                    DateCreated = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    DateModified = table.Column<DateTime>(nullable: true, defaultValueSql: "GETDATE()"),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false),
                    ReservationObjectID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reservations_ReservationObjects_ReservationObjectID",
                        column: x => x.ReservationObjectID,
                        principalSchema: "Reservator",
                        principalTable: "ReservationObjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Users_UserID",
                        column: x => x.UserID,
                        principalSchema: "Reservator",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Reservator",
                table: "ObjectOwners",
                columns: new[] { "ID", "Active", "DateCreated", "DateModified", "Description", "Name" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2019, 5, 19, 14, 40, 48, 551, DateTimeKind.Local).AddTicks(8865), null, "Desc1", "Owner1" },
                    { 2, true, new DateTime(2019, 5, 19, 14, 40, 48, 560, DateTimeKind.Local).AddTicks(2598), null, "Desc2", "Owner2" }
                });

            migrationBuilder.InsertData(
                schema: "Reservator",
                table: "Roles",
                columns: new[] { "ID", "Active", "DateCreated", "DateModified", "Description", "Name" },
                values: new object[] { 1, true, new DateTime(2019, 5, 19, 14, 40, 48, 576, DateTimeKind.Local).AddTicks(7884), null, "User role", "User" });

            migrationBuilder.InsertData(
                schema: "Reservator",
                table: "Users",
                columns: new[] { "ID", "Active", "DateCreated", "DateModified", "Email", "FirstName", "LastName", "Password", "UserName" },
                values: new object[] { 1, true, new DateTime(2019, 5, 19, 14, 40, 48, 574, DateTimeKind.Local).AddTicks(9158), null, "test.test@test.test", "Test", "User", "testuser", "tUser" });

            migrationBuilder.InsertData(
                schema: "Reservator",
                table: "ReservationObjects",
                columns: new[] { "ID", "Active", "DateCreated", "DateModified", "Description", "MaximumReservationTime", "Name", "ObjectOwnerID" },
                values: new object[] { 1, true, new DateTime(2019, 5, 19, 14, 40, 48, 569, DateTimeKind.Local).AddTicks(1182), null, "Reservation object A", 864000000000L, "Reservation object A", 1 });

            migrationBuilder.InsertData(
                schema: "Reservator",
                table: "Reservations",
                columns: new[] { "ID", "Active", "DateCreated", "DateFrom", "DateModified", "DateTo", "ReservationObjectID", "UserID" },
                values: new object[] { 1, true, new DateTime(2019, 5, 19, 14, 40, 48, 572, DateTimeKind.Local).AddTicks(5580), new DateTime(2019, 5, 19, 14, 40, 48, 572, DateTimeKind.Local).AddTicks(5841), null, new DateTime(2019, 5, 19, 14, 40, 48, 572, DateTimeKind.Local).AddTicks(6829), 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ReservationObjects_ObjectOwnerID",
                schema: "Reservator",
                table: "ReservationObjects",
                column: "ObjectOwnerID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservationObjectID",
                schema: "Reservator",
                table: "Reservations",
                column: "ReservationObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserID",
                schema: "Reservator",
                table: "Reservations",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations",
                schema: "Reservator");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Reservator");

            migrationBuilder.DropTable(
                name: "ReservationObjects",
                schema: "Reservator");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Reservator");

            migrationBuilder.DropTable(
                name: "ObjectOwners",
                schema: "Reservator");
        }
    }
}
