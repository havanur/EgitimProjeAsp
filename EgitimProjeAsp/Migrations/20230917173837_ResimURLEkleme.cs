using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EgitimProjeAsp.Migrations
{
    /// <inheritdoc />
    public partial class ResimURLEkleme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResimURL",
                table: "Kitaplar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResimURL",
                table: "Kitaplar");
        }
    }
}
