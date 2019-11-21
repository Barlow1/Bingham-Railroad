using Microsoft.EntityFrameworkCore.Migrations;

namespace BinghamRailroad.Migrations
{
    public partial class AddStationAmenityAndTrainAmenity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StationAmenity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StationId = table.Column<int>(nullable: false),
                    AmenityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationAmenity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainAmenity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TrainId = table.Column<int>(nullable: false),
                    AmenityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainAmenity", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StationAmenity");

            migrationBuilder.DropTable(
                name: "TrainAmenity");
        }
    }
}
