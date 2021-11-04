using Microsoft.EntityFrameworkCore.Migrations;

namespace CCSB.Migrations
{
    public partial class Bugfixforapplicationuserforeignkeyandprimarykey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_AspNetUsers_ApplicationUserId",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_ApplicationUserId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Vehicles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LicensePlate",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "Vehicles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CustomerId",
                table: "Vehicles",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_AspNetUsers_CustomerId",
                table: "Vehicles",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_AspNetUsers_CustomerId",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_CustomerId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<string>(
                name: "LicensePlate",
                table: "Vehicles",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Vehicles",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "LicensePlate");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ApplicationUserId",
                table: "Vehicles",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_AspNetUsers_ApplicationUserId",
                table: "Vehicles",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
