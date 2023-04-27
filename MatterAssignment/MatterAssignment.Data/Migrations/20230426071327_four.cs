using Microsoft.EntityFrameworkCore.Migrations;

namespace MatterAssignment.Data.Migrations
{
    public partial class four : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttorneyRole_RoleMaster_AttorneyId",
                table: "AttorneyRole");

            migrationBuilder.DropIndex(
                name: "IX_Attorneys_JurisdictionId",
                table: "Attorneys");

            migrationBuilder.CreateIndex(
                name: "IX_Attorneys_JurisdictionId",
                table: "Attorneys",
                column: "JurisdictionId");

            migrationBuilder.CreateIndex(
                name: "IX_AttorneyRole_RoleMasterId",
                table: "AttorneyRole",
                column: "RoleMasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttorneyRole_RoleMaster_RoleMasterId",
                table: "AttorneyRole",
                column: "RoleMasterId",
                principalTable: "RoleMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttorneyRole_RoleMaster_RoleMasterId",
                table: "AttorneyRole");

            migrationBuilder.DropIndex(
                name: "IX_Attorneys_JurisdictionId",
                table: "Attorneys");

            migrationBuilder.DropIndex(
                name: "IX_AttorneyRole_RoleMasterId",
                table: "AttorneyRole");

            migrationBuilder.CreateIndex(
                name: "IX_Attorneys_JurisdictionId",
                table: "Attorneys",
                column: "JurisdictionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AttorneyRole_RoleMaster_AttorneyId",
                table: "AttorneyRole",
                column: "AttorneyId",
                principalTable: "RoleMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
