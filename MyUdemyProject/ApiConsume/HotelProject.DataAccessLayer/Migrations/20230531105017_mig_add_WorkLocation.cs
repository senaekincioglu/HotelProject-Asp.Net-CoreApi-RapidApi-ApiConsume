using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelProject.DataAccessLayer.Migrations
{
    public partial class mig_add_WorkLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WorkDepartment",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkLocationID",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkLocationID1",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WorkLocations",
                columns: table => new
                {
                    WorkLocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkLocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkLocationCity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkLocations", x => x.WorkLocationID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WorkLocationID1",
                table: "AspNetUsers",
                column: "WorkLocationID1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_WorkLocations_WorkLocationID1",
                table: "AspNetUsers",
                column: "WorkLocationID1",
                principalTable: "WorkLocations",
                principalColumn: "WorkLocationID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_WorkLocations_WorkLocationID1",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "WorkLocations");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_WorkLocationID1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WorkDepartment",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WorkLocationID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WorkLocationID1",
                table: "AspNetUsers");
        }
    }
}
