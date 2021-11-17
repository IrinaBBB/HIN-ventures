using Microsoft.EntityFrameworkCore.Migrations;

namespace HIN_ventures.DataAccess.Migrations
{
    public partial class AddCodeFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_assignment",
                table: "assignment");

            migrationBuilder.RenameTable(
                name: "assignment",
                newName: "Assignments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignments",
                table: "Assignments",
                column: "id");

            migrationBuilder.CreateTable(
                name: "CodeFiles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    assignment_id = table.Column<int>(type: "int", nullable: false),
                    code_file_url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeFiles", x => x.id);
                    table.ForeignKey(
                        name: "FK_CodeFiles_Assignments_assignment_id",
                        column: x => x.assignment_id,
                        principalTable: "Assignments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CodeFiles_assignment_id",
                table: "CodeFiles",
                column: "assignment_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodeFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignments",
                table: "Assignments");

            migrationBuilder.RenameTable(
                name: "Assignments",
                newName: "assignment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_assignment",
                table: "assignment",
                column: "id");
        }
    }
}
