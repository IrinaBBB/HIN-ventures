using Microsoft.EntityFrameworkCore.Migrations;

namespace HIN_ventures.DataAccess.Migrations
{
    public partial class addednameinfreelancer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Speciality",
                table: "Freelancers",
                newName: "Specialty");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Freelancers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Freelancers");

            migrationBuilder.RenameColumn(
                name: "Specialty",
                table: "Freelancers",
                newName: "Speciality");
        }
    }
}
