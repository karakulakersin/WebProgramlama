using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogSosyalMedya.Data.Migrations
{
    public partial class Ekle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategori",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdı = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sehir",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SehirAdi = table.Column<string>(nullable: true),
                    CografiBolge = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sehir", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TatilTuru",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurAdi = table.Column<int>(nullable: false),
                    Ucret = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TatilTuru", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TurGorevlisi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GorevliAdi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurGorevlisi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ulke",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UlkeAd = table.Column<string>(nullable: true),
                    BulunduguKita = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ulke", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Otel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OtelYildizi = table.Column<int>(nullable: false),
                    OtelAdi = table.Column<string>(nullable: true),
                    SehirAdi = table.Column<string>(nullable: true),
                    SehirId = table.Column<int>(nullable: true),
                    UlkeAdi = table.Column<string>(nullable: true),
                    UlkeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Otel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Otel_Sehir_SehirId",
                        column: x => x.SehirId,
                        principalTable: "Sehir",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Otel_Ulke_UlkeId",
                        column: x => x.UlkeId,
                        principalTable: "Ulke",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TatilYerleri",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YerAdı = table.Column<string>(nullable: true),
                    SehirId = table.Column<string>(nullable: true),
                    SehirId1 = table.Column<int>(nullable: true),
                    UlkeId = table.Column<string>(nullable: true),
                    UlkeId1 = table.Column<int>(nullable: true),
                    KategoriId = table.Column<string>(nullable: true),
                    KategoriId1 = table.Column<int>(nullable: true),
                    Puani = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TatilYerleri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TatilYerleri_Kategori_KategoriId1",
                        column: x => x.KategoriId1,
                        principalTable: "Kategori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TatilYerleri_Sehir_SehirId1",
                        column: x => x.SehirId1,
                        principalTable: "Sehir",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TatilYerleri_Ulke_UlkeId1",
                        column: x => x.UlkeId1,
                        principalTable: "Ulke",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Otel_SehirId",
                table: "Otel",
                column: "SehirId");

            migrationBuilder.CreateIndex(
                name: "IX_Otel_UlkeId",
                table: "Otel",
                column: "UlkeId");

            migrationBuilder.CreateIndex(
                name: "IX_TatilYerleri_KategoriId1",
                table: "TatilYerleri",
                column: "KategoriId1");

            migrationBuilder.CreateIndex(
                name: "IX_TatilYerleri_SehirId1",
                table: "TatilYerleri",
                column: "SehirId1");

            migrationBuilder.CreateIndex(
                name: "IX_TatilYerleri_UlkeId1",
                table: "TatilYerleri",
                column: "UlkeId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Otel");

            migrationBuilder.DropTable(
                name: "TatilTuru");

            migrationBuilder.DropTable(
                name: "TatilYerleri");

            migrationBuilder.DropTable(
                name: "TurGorevlisi");

            migrationBuilder.DropTable(
                name: "Kategori");

            migrationBuilder.DropTable(
                name: "Sehir");

            migrationBuilder.DropTable(
                name: "Ulke");
        }
    }
}
