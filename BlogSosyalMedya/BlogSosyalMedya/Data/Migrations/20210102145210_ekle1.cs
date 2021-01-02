using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogSosyalMedya.Data.Migrations
{
    public partial class ekle1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TatilYerleri_Kategori_KategoriId1",
                table: "TatilYerleri");

            migrationBuilder.DropForeignKey(
                name: "FK_TatilYerleri_Sehir_SehirId1",
                table: "TatilYerleri");

            migrationBuilder.DropForeignKey(
                name: "FK_TatilYerleri_Ulke_UlkeId1",
                table: "TatilYerleri");

            migrationBuilder.DropIndex(
                name: "IX_TatilYerleri_KategoriId1",
                table: "TatilYerleri");

            migrationBuilder.DropIndex(
                name: "IX_TatilYerleri_SehirId1",
                table: "TatilYerleri");

            migrationBuilder.DropIndex(
                name: "IX_TatilYerleri_UlkeId1",
                table: "TatilYerleri");

            migrationBuilder.DropColumn(
                name: "KategoriId1",
                table: "TatilYerleri");

            migrationBuilder.DropColumn(
                name: "SehirId1",
                table: "TatilYerleri");

            migrationBuilder.DropColumn(
                name: "UlkeId1",
                table: "TatilYerleri");

            migrationBuilder.AlterColumn<int>(
                name: "UlkeId",
                table: "TatilYerleri",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SehirId",
                table: "TatilYerleri",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KategoriId",
                table: "TatilYerleri",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TurAdi",
                table: "TatilTuru",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UlkeAdi",
                table: "Otel",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SehirAdi",
                table: "Otel",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TatilYerleri_KategoriId",
                table: "TatilYerleri",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_TatilYerleri_SehirId",
                table: "TatilYerleri",
                column: "SehirId");

            migrationBuilder.CreateIndex(
                name: "IX_TatilYerleri_UlkeId",
                table: "TatilYerleri",
                column: "UlkeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TatilYerleri_Kategori_KategoriId",
                table: "TatilYerleri",
                column: "KategoriId",
                principalTable: "Kategori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TatilYerleri_Sehir_SehirId",
                table: "TatilYerleri",
                column: "SehirId",
                principalTable: "Sehir",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TatilYerleri_Ulke_UlkeId",
                table: "TatilYerleri",
                column: "UlkeId",
                principalTable: "Ulke",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TatilYerleri_Kategori_KategoriId",
                table: "TatilYerleri");

            migrationBuilder.DropForeignKey(
                name: "FK_TatilYerleri_Sehir_SehirId",
                table: "TatilYerleri");

            migrationBuilder.DropForeignKey(
                name: "FK_TatilYerleri_Ulke_UlkeId",
                table: "TatilYerleri");

            migrationBuilder.DropIndex(
                name: "IX_TatilYerleri_KategoriId",
                table: "TatilYerleri");

            migrationBuilder.DropIndex(
                name: "IX_TatilYerleri_SehirId",
                table: "TatilYerleri");

            migrationBuilder.DropIndex(
                name: "IX_TatilYerleri_UlkeId",
                table: "TatilYerleri");

            migrationBuilder.AlterColumn<string>(
                name: "UlkeId",
                table: "TatilYerleri",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "SehirId",
                table: "TatilYerleri",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "KategoriId",
                table: "TatilYerleri",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "KategoriId1",
                table: "TatilYerleri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SehirId1",
                table: "TatilYerleri",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UlkeId1",
                table: "TatilYerleri",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TurAdi",
                table: "TatilTuru",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UlkeAdi",
                table: "Otel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "SehirAdi",
                table: "Otel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

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

            migrationBuilder.AddForeignKey(
                name: "FK_TatilYerleri_Kategori_KategoriId1",
                table: "TatilYerleri",
                column: "KategoriId1",
                principalTable: "Kategori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TatilYerleri_Sehir_SehirId1",
                table: "TatilYerleri",
                column: "SehirId1",
                principalTable: "Sehir",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TatilYerleri_Ulke_UlkeId1",
                table: "TatilYerleri",
                column: "UlkeId1",
                principalTable: "Ulke",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
