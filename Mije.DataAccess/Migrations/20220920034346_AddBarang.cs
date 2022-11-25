using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mije.DataAccess.Migrations
{
    public partial class AddBarang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "barangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProdukID = table.Column<int>(type: "int", nullable: false),
                    desk = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_barangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_barangs_produks_ProdukID",
                        column: x => x.ProdukID,
                        principalTable: "produks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_barangs_ProdukID",
                table: "barangs",
                column: "ProdukID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "barangs");
        }
    }
}
