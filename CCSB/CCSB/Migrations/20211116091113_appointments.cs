using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CCSB.Migrations
{
    public partial class appointments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Vehicles");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ApplicationUserId",
                table: "Appointments",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_ApplicationUserId",
                table: "Appointments",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_ApplicationUserId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ApplicationUserId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Appointments");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Vehicles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Vehicles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
