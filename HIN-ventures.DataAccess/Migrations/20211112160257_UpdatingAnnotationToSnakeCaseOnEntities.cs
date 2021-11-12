using Microsoft.EntityFrameworkCore.Migrations;

namespace HIN_ventures.DataAccess.Migrations
{
    public partial class UpdatingAnnotationToSnakeCaseOnEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Speciality",
                table: "freelancer",
                newName: "speciality");

            migrationBuilder.RenameColumn(
                name: "totallinesofcode",
                table: "freelancer",
                newName: "total_lines_of_code");

            migrationBuilder.RenameColumn(
                name: "linesofcodemonth",
                table: "freelancer",
                newName: "lines_of_code_month");

            migrationBuilder.RenameColumn(
                name: "averagerating",
                table: "freelancer",
                newName: "average_rating");

            migrationBuilder.RenameColumn(
                name: "freelancerid",
                table: "freelancer",
                newName: "freelancer_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "speciality",
                table: "freelancer",
                newName: "Speciality");

            migrationBuilder.RenameColumn(
                name: "total_lines_of_code",
                table: "freelancer",
                newName: "totallinesofcode");

            migrationBuilder.RenameColumn(
                name: "lines_of_code_month",
                table: "freelancer",
                newName: "linesofcodemonth");

            migrationBuilder.RenameColumn(
                name: "average_rating",
                table: "freelancer",
                newName: "averagerating");

            migrationBuilder.RenameColumn(
                name: "freelancer_id",
                table: "freelancer",
                newName: "freelancerid");
        }
    }
}
