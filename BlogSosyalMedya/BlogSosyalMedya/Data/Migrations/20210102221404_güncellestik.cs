using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogSosyalMedya.Data.Migrations
{
    public partial class güncellestik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GorevliAdi",
                table: "TurGorevlisi");

            migrationBuilder.AddColumn<string>(
                name: "Adı",
                table: "TurGorevlisi",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Cinsiyet",
                table: "TurGorevlisi",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Soyadı",
                table: "TurGorevlisi",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adı",
                table: "TurGorevlisi");

            migrationBuilder.DropColumn(
                name: "Cinsiyet",
                table: "TurGorevlisi");

            migrationBuilder.DropColumn(
                name: "Soyadı",
                table: "TurGorevlisi");

            migrationBuilder.AddColumn<string>(
                name: "GorevliAdi",
                table: "TurGorevlisi",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
