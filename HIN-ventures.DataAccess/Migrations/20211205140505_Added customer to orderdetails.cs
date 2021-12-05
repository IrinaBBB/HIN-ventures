using Microsoft.EntityFrameworkCore.Migrations;

namespace HIN_ventures.DataAccess.Migrations
{
    public partial class Addedcustomertoorderdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "BookingDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_CustomerId",
                table: "BookingDetails",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingDetails_Customers_CustomerId",
                table: "BookingDetails",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingDetails_Customers_CustomerId",
                table: "BookingDetails");

            migrationBuilder.DropIndex(
                name: "IX_BookingDetails_CustomerId",
                table: "BookingDetails");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "BookingDetails");
        }
    }
}
