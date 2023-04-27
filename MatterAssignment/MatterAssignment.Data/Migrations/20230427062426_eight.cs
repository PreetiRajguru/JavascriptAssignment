using Microsoft.EntityFrameworkCore.Migrations;

namespace MatterAssignment.Data.Migrations
{
    public partial class eight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Matters_JurisdictionId",
                table: "Matters");

            migrationBuilder.CreateIndex(
                name: "IX_Matters_JurisdictionId",
                table: "Matters",
                column: "JurisdictionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Matters_JurisdictionId",
                table: "Matters");

            migrationBuilder.CreateIndex(
                name: "IX_Matters_JurisdictionId",
                table: "Matters",
                column: "JurisdictionId",
                unique: true);
        }
    }
}
