using Microsoft.EntityFrameworkCore.Migrations;

namespace HIN_ventures.DataAccess.Migrations
{
    public partial class AddAssignmentToBookingDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssignmentId",
                table: "AssignmentOrderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_AssignmentId",
                table: "AssignmentOrderDetails",
                column: "AssignmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingDetails_Assignments_AssignmentId",
                table: "AssignmentOrderDetails",
                column: "AssignmentId",
                principalTable: "Assignments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingDetails_Assignments_AssignmentId",
                table: "AssignmentOrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_BookingDetails_AssignmentId",
                table: "AssignmentOrderDetails");

            migrationBuilder.DropColumn(
                name: "AssignmentId",
                table: "AssignmentOrderDetails");
        }
    }
}
