using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogSosyalMedya.Data.Migrations
{
    public partial class yeniguncelleme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GidilecekYerler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YerAdi = table.Column<string>(nullable: true),
                    SehirId = table.Column<int>(nullable: false),
                    UlkeId = table.Column<int>(nullable: false),
                    KategoriId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GidilecekYerler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GidilecekYerler_Kategori_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GidilecekYerler_Sehir_SehirId",
                        column: x => x.SehirId,
                        principalTable: "Sehir",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GidilecekYerler_Ulke_UlkeId",
                        column: x => x.UlkeId,
                        principalTable: "Ulke",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GidilecekYerler_KategoriId",
                table: "GidilecekYerler",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_GidilecekYerler_SehirId",
                table: "GidilecekYerler",
                column: "SehirId");

            migrationBuilder.CreateIndex(
                name: "IX_GidilecekYerler_UlkeId",
                table: "GidilecekYerler",
                column: "UlkeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GidilecekYerler");
        }
    }
}
