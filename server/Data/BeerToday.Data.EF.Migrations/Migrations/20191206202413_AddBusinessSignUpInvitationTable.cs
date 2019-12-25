using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerToday.Data.EF.Migrations.Migrations
{
    public partial class AddBusinessSignUpInvitationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessSignUpInvitation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessSignUpInvitation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessSignUpInvitation_BusinessSignUpApplications_Id",
                        column: x => x.Id,
                        principalTable: "BusinessSignUpApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "af5e5f3f-efd1-4fe4-bd45-0349160829a9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2L,
                column: "ConcurrencyStamp",
                value: "502c2a05-2560-4aec-9ea9-af0bfa70fe0a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3L,
                column: "ConcurrencyStamp",
                value: "11b3179f-0d35-43aa-9e29-ac86cbf14397");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessSignUpInvitation");

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
        }
    }
}
