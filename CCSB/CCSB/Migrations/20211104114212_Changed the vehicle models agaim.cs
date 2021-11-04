using Microsoft.EntityFrameworkCore.Migrations;

namespace CCSB.Migrations
{
    public partial class Changedthevehiclemodelsagaim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_AspNetUsers_CustomerId",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Vehicles",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_CustomerId",
                table: "Vehicles",
                newName: "IX_Vehicles_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_AspNetUsers_ApplicationUserId",
                table: "Vehicles",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_AspNetUsers_ApplicationUserId",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Vehicles",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_ApplicationUserId",
                table: "Vehicles",
                newName: "IX_Vehicles_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_AspNetUsers_CustomerId",
                table: "Vehicles",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
