using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppartementTask.Migrations
{
    public partial class residenceupdatedb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_Residences_ResidenceId",
                table: "Picture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Picture",
                table: "Picture");

            migrationBuilder.RenameTable(
                name: "Picture",
                newName: "Pictures");

            migrationBuilder.RenameIndex(
                name: "IX_Picture_ResidenceId",
                table: "Pictures",
                newName: "IX_Pictures_ResidenceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pictures",
                table: "Pictures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Residences_ResidenceId",
                table: "Pictures",
                column: "ResidenceId",
                principalTable: "Residences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Residences_ResidenceId",
                table: "Pictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pictures",
                table: "Pictures");

            migrationBuilder.RenameTable(
                name: "Pictures",
                newName: "Picture");

            migrationBuilder.RenameIndex(
                name: "IX_Pictures_ResidenceId",
                table: "Picture",
                newName: "IX_Picture_ResidenceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Picture",
                table: "Picture",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_Residences_ResidenceId",
                table: "Picture",
                column: "ResidenceId",
                principalTable: "Residences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
