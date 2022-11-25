using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mije.DataAccess.Migrations
{
    public partial class addPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "foto",
                table: "barangs",
                newName: "photo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "photo",
                table: "barangs",
                newName: "foto");
        }
    }
}
