using Microsoft.EntityFrameworkCore.Migrations;

namespace HIN_ventures.DataAccess.Migrations
{
    public partial class ConnectAssigmentsAndFreelancers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FreelancerId",
                table: "assignment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "freelancer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    averagerating = table.Column<int>(type: "int", nullable: false),
                    totallinesofcode = table.Column<int>(type: "int", nullable: false),
                    linesofcodemonth = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_freelancer", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_assignment_FreelancerId",
                table: "assignment",
                column: "FreelancerId");

            migrationBuilder.AddForeignKey(
                name: "FK_assignment_freelancer_FreelancerId",
                table: "Assignment",
                column: "FreelancerId",
                principalTable: "Freelancer",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assignment_freelancer_FreelancerId",
                table: "Assignment");

            migrationBuilder.DropTable(
                name: "Freelancer");

            migrationBuilder.DropIndex(
                name: "IX_assignment_FreelancerId",
                table: "Assignment");

            migrationBuilder.DropColumn(
                name: "FreelancerId",
                table: "Assignment");
        }
    }
}
