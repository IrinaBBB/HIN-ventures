using Microsoft.EntityFrameworkCore.Migrations;

namespace HIN_ventures.DataAccess.Migrations
{
    public partial class AddCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_assignment_freelancer_FreelancerId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_CodeFiles_Assignments_assignment_id",
                table: "CodeFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_freelancer",
                table: "freelancer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignments",
                table: "Assignments");

            //migrationBuilder.RenameTable(
            //    name: "freelancer",
            //    newName: "Freelancer");

            migrationBuilder.RenameIndex(
                name: "IX_assignment_FreelancerId",
                table: "Assignments",
                newName: "IX_Assignments_FreelancerId");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Assignments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PortalId",
                table: "Assignments",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Freelancer",
                table: "Freelancer",
                column: "freelancer_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignments",
                table: "Assignments",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    customer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    total_lines_of_code = table.Column<int>(type: "int", nullable: false),
                    total_cost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "Portal",
                columns: table => new
                {
                    portal_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    portal_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portal", x => x.portal_id);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    freelancer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.freelancer_id);
                    table.ForeignKey(
                        name: "FK_Rating_Customer_customer_id",
                        column: x => x.customer_id,
                        principalTable: "Customer",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPortal",
                columns: table => new
                {
                    CustomersCustomerId = table.Column<int>(type: "int", nullable: false),
                    PortalsPortalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPortal", x => new { x.CustomersCustomerId, x.PortalsPortalId });
                    table.ForeignKey(
                        name: "FK_CustomerPortal_Customer_CustomersCustomerId",
                        column: x => x.CustomersCustomerId,
                        principalTable: "Customer",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerPortal_Portal_PortalsPortalId",
                        column: x => x.PortalsPortalId,
                        principalTable: "Portal",
                        principalColumn: "portal_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CustomerId",
                table: "Assignments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_PortalId",
                table: "Assignments",
                column: "PortalId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPortal_PortalsPortalId",
                table: "CustomerPortal",
                column: "PortalsPortalId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_customer_id",
                table: "Rating",
                column: "customer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Customer_CustomerId",
                table: "Assignments",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "customer_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Freelancer_FreelancerId",
                table: "Assignments",
                column: "FreelancerId",
                principalTable: "Freelancer",
                principalColumn: "freelancer_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Portal_PortalId",
                table: "Assignments",
                column: "PortalId",
                principalTable: "Portal",
                principalColumn: "portal_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CodeFiles_Assignments_assignment_id",
                table: "CodeFiles",
                column: "assignment_id",
                principalTable: "Assignments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Customer_CustomerId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Freelancer_FreelancerId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Portal_PortalId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_CodeFiles_Assignments_assignment_id",
                table: "CodeFiles");

            migrationBuilder.DropTable(
                name: "CustomerPortal");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Portal");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Freelancer",
                table: "Freelancer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assignments",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_CustomerId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_PortalId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "PortalId",
                table: "Assignments");

            migrationBuilder.RenameTable(
                name: "Freelancer",
                newName: "freelancer");

            migrationBuilder.RenameTable(
                name: "Assignments",
                newName: "Assignment");

            migrationBuilder.RenameIndex(
                name: "IX_Assignments_FreelancerId",
                table: "Assignment",
                newName: "IX_assignment_FreelancerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_freelancer",
                table: "Freelancer",
                column: "freelancer_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assignments",
                table: "Assignment",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_assignment_freelancer_FreelancerId",
                table: "Assignments",
                column: "FreelancerId",
                principalTable: "Freelancer",
                principalColumn: "freelancer_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CodeFiles_Assignments_assignment_id",
                table: "CodeFiles",
                column: "assignment_id",
                principalTable: "Assignment",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
