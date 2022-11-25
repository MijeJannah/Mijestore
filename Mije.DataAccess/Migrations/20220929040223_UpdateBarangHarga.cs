using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mije.DataAccess.Migrations
{
    public partial class UpdateBarangHarga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Harga",
                table: "barangs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Harga",
                table: "barangs");
        }
    }
}
