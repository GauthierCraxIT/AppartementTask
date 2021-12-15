using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppartementTask.Migrations
{
    public partial class residenceupdatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Storagerooms",
                table: "Residences",
                newName: "Wifi");

            migrationBuilder.RenameColumn(
                name: "Officerooms",
                table: "Residences",
                newName: "Television");

            migrationBuilder.RenameColumn(
                name: "Floors",
                table: "Residences",
                newName: "SwimmingPool");

            migrationBuilder.AddColumn<bool>(
                name: "Breakfast",
                table: "Residences",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Kitchen",
                table: "Residences",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NearbyBeach",
                table: "Residences",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NearbyCity",
                table: "Residences",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NearbySubway",
                table: "Residences",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "NearbyTrainStation",
                table: "Residences",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Breakfast",
                table: "Residences");

            migrationBuilder.DropColumn(
                name: "Kitchen",
                table: "Residences");

            migrationBuilder.DropColumn(
                name: "NearbyBeach",
                table: "Residences");

            migrationBuilder.DropColumn(
                name: "NearbyCity",
                table: "Residences");

            migrationBuilder.DropColumn(
                name: "NearbySubway",
                table: "Residences");

            migrationBuilder.DropColumn(
                name: "NearbyTrainStation",
                table: "Residences");

            migrationBuilder.RenameColumn(
                name: "Wifi",
                table: "Residences",
                newName: "Storagerooms");

            migrationBuilder.RenameColumn(
                name: "Television",
                table: "Residences",
                newName: "Officerooms");

            migrationBuilder.RenameColumn(
                name: "SwimmingPool",
                table: "Residences",
                newName: "Floors");
        }
    }
}
