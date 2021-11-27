using Microsoft.EntityFrameworkCore.Migrations;

namespace CCSB.Migrations
{
    public partial class CreateIdentityTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CamperRegViewModel",
                columns: table => new
                {
                    LicensePlate = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false),
                    PowereSupply = table.Column<bool>(type: "bit", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KindOfVehicle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SleepingPlaces = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BicycleCarrier = table.Column<bool>(type: "bit", nullable: false),
                    Airco = table.Column<bool>(type: "bit", nullable: false),
                    Pk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TowBar = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CamperRegViewModel", x => x.LicensePlate);
                });

            migrationBuilder.CreateTable(
                name: "CaravanRegViewModel",
                columns: table => new
                {
                    LicensePlate = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false),
                    PowereSupply = table.Column<bool>(type: "bit", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KindOfVehicle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SleepingPlaces = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BicycleCarrier = table.Column<bool>(type: "bit", nullable: false),
                    Airco = table.Column<bool>(type: "bit", nullable: false),
                    EmptyWeight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoldingTank = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaravanRegViewModel", x => x.LicensePlate);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CamperRegViewModel");

            migrationBuilder.DropTable(
                name: "CaravanRegViewModel");
        }
    }
}
