using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogSosyalMedya.Data.Migrations
{
    public partial class eklers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Cinsiyet",
                table: "TurGorevlisi",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Cinsiyet",
                table: "TurGorevlisi",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
