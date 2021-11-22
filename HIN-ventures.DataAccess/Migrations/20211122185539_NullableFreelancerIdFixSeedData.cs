using Microsoft.EntityFrameworkCore.Migrations;

namespace HIN_ventures.DataAccess.Migrations
{
    public partial class NullableFreelancerIdFixSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Freelancers_FreelancerId",
                table: "Assignments");

            migrationBuilder.AlterColumn<int>(
                name: "FreelancerId",
                table: "Assignments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Freelancers_FreelancerId",
                table: "Assignments",
                column: "FreelancerId",
                principalTable: "Freelancers",
                principalColumn: "FreelancerId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Freelancers_FreelancerId",
                table: "Assignments");

            migrationBuilder.AlterColumn<int>(
                name: "FreelancerId",
                table: "Assignments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Freelancers_FreelancerId",
                table: "Assignments",
                column: "FreelancerId",
                principalTable: "Freelancers",
                principalColumn: "FreelancerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
