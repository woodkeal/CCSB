using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CCSB.Migrations
{
    public partial class appointmentsadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "IsDoctorApproved",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "AppointmentDate",
                table: "Appointments",
                newName: "AppointmentDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AppointmentDate",
                table: "Appointments",
                newName: "AppointmentDate");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Appointments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDoctorApproved",
                table: "Appointments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
