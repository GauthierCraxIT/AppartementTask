using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppartementTask.Migrations
{
    public partial class residenceupdatedb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Residences",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Residences");
        }
    }
}
