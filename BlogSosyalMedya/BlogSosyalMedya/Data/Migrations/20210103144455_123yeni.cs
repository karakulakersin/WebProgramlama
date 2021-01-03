using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogSosyalMedya.Data.Migrations
{
    public partial class _123yeni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KategoriId",
                table: "Otel",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Otel_KategoriId",
                table: "Otel",
                column: "KategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Otel_Kategori_KategoriId",
                table: "Otel",
                column: "KategoriId",
                principalTable: "Kategori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Otel_Kategori_KategoriId",
                table: "Otel");

            migrationBuilder.DropIndex(
                name: "IX_Otel_KategoriId",
                table: "Otel");

            migrationBuilder.DropColumn(
                name: "KategoriId",
                table: "Otel");
        }
    }
}
