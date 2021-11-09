using Microsoft.EntityFrameworkCore.Migrations;

namespace HIN_ventures.DataAccess.Migrations
{
    public partial class FixNameOnIdColumnForFreelancer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "freelancer",
                newName: "freelancerid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "freelancerid",
                table: "freelancer",
                newName: "id");
        }
    }
}
