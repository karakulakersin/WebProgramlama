using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogSosyalMedya.Data.Migrations
{
    public partial class yeni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Otel_Sehir_SehirId",
                table: "Otel");

            migrationBuilder.DropForeignKey(
                name: "FK_Otel_Ulke_UlkeId",
                table: "Otel");

            migrationBuilder.DropColumn(
                name: "SehirAdi",
                table: "Otel");

            migrationBuilder.DropColumn(
                name: "UlkeAdi",
                table: "Otel");

            migrationBuilder.AlterColumn<int>(
                name: "UlkeId",
                table: "Otel",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SehirId",
                table: "Otel",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Otel_Sehir_SehirId",
                table: "Otel",
                column: "SehirId",
                principalTable: "Sehir",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Otel_Ulke_UlkeId",
                table: "Otel",
                column: "UlkeId",
                principalTable: "Ulke",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Otel_Sehir_SehirId",
                table: "Otel");

            migrationBuilder.DropForeignKey(
                name: "FK_Otel_Ulke_UlkeId",
                table: "Otel");

            migrationBuilder.AlterColumn<int>(
                name: "UlkeId",
                table: "Otel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SehirId",
                table: "Otel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "SehirAdi",
                table: "Otel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UlkeAdi",
                table: "Otel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Otel_Sehir_SehirId",
                table: "Otel",
                column: "SehirId",
                principalTable: "Sehir",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Otel_Ulke_UlkeId",
                table: "Otel",
                column: "UlkeId",
                principalTable: "Ulke",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
