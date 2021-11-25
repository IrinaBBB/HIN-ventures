using Microsoft.EntityFrameworkCore.Migrations;

namespace HIN_ventures.DataAccess.Migrations
{
    public partial class AddCryptoAddresses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CryptoAddress",
                table: "Freelancers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CryptoAddress",
                table: "Customers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CryptoAddress",
                table: "Freelancers");

            migrationBuilder.DropColumn(
                name: "CryptoAddress",
                table: "Customers");
        }
    }
}
