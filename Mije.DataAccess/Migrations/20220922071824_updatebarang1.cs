using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mije.DataAccess.Migrations
{
    public partial class updatebarang1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "foto",
                table: "barangs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "foto",
                table: "barangs");
        }
    }
}
