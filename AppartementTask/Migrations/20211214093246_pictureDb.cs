using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppartementTask.Migrations
{
    public partial class pictureDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Residences_AspNetUsers_PersonId",
                table: "Residences");

            migrationBuilder.DropIndex(
                name: "IX_Residences_PersonId",
                table: "Residences");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Residences");

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Residences",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FileName = table.Column<string>(type: "TEXT", nullable: false),
                    ResidenceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Picture_Residences_ResidenceId",
                        column: x => x.ResidenceId,
                        principalTable: "Residences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Picture_ResidenceId",
                table: "Picture",
                column: "ResidenceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Residences");

            migrationBuilder.AddColumn<string>(
                name: "PersonId",
                table: "Residences",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Residences_PersonId",
                table: "Residences",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Residences_AspNetUsers_PersonId",
                table: "Residences",
                column: "PersonId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
