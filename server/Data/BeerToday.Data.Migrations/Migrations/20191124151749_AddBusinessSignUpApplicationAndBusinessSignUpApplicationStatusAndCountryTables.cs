using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BeerToday.Data.Migrations.Migrations
{
    public partial class AddBusinessSignUpApplicationAndBusinessSignUpApplicationStatusAndCountryTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessSignUpApplicationStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessSignUpApplicationStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessSignUpApplications",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    OrganizationName = table.Column<string>(nullable: true),
                    OrganizationAddress = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessSignUpApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessSignUpApplications_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinessSignUpApplications_BusinessSignUpApplicationStatus_~",
                        column: x => x.StatusId,
                        principalTable: "BusinessSignUpApplicationStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "40895b53-9808-47f8-9b84-c3f67a033e1b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ConcurrencyStamp",
                value: "b246f742-346c-4327-80e7-b21099539cf0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "ConcurrencyStamp",
                value: "3c155e95-760d-4da7-a055-e9bb2454c70c");

            migrationBuilder.InsertData(
                table: "BusinessSignUpApplicationStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 0, "Undefined" },
                    { 1, "Active" },
                    { 2, "Withdrawn" },
                    { 3, "Approved" },
                    { 4, "Rejected" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Belarus" });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessSignUpApplications_CountryId",
                table: "BusinessSignUpApplications",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessSignUpApplications_StatusId",
                table: "BusinessSignUpApplications",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessSignUpApplications");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "BusinessSignUpApplicationStatus");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "73bd8bac-1aab-460b-9790-92e8659db5c9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ConcurrencyStamp",
                value: "c041a0ff-355b-48fa-b42d-075ce6ce7f86");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "ConcurrencyStamp",
                value: "33431bec-6dbe-49dd-bbb1-62cdf88df574");
        }
    }
}
