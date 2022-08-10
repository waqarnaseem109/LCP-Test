using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientId", "Address", "DateOfBirth", "FirstName", "LastName" },
                values: new object[] { new Guid("21752480-73eb-4418-809c-d500d847427c"), "TW3 5RS", new DateTime(2022, 8, 10, 10, 13, 5, 61, DateTimeKind.Local).AddTicks(8210), "John", "Tim" });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientId", "Address", "DateOfBirth", "FirstName", "LastName" },
                values: new object[] { new Guid("694d7d35-7ddd-4eaf-930b-4db0e8191457"), "RE3 8UY", new DateTime(2022, 8, 10, 10, 13, 5, 61, DateTimeKind.Local).AddTicks(8280), "Peter", "Pin" });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientId", "Address", "DateOfBirth", "FirstName", "LastName" },
                values: new object[] { new Guid("9f41ab02-6e52-4dda-8d44-738d70806114"), "SE2 2TR", new DateTime(2022, 8, 10, 10, 13, 5, 61, DateTimeKind.Local).AddTicks(8280), "Sara", "Sara" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
