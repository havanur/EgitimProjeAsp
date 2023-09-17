using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EgitimProjeAsp.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyEkle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KitapTuruId",
                table: "Kitaplar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Kitaplar_KitapTuruId",
                table: "Kitaplar",
                column: "KitapTuruId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitaplar_KitapTuruleri_KitapTuruId",
                table: "Kitaplar",
                column: "KitapTuruId",
                principalTable: "KitapTuruleri",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitaplar_KitapTuruleri_KitapTuruId",
                table: "Kitaplar");

            migrationBuilder.DropIndex(
                name: "IX_Kitaplar_KitapTuruId",
                table: "Kitaplar");

            migrationBuilder.DropColumn(
                name: "KitapTuruId",
                table: "Kitaplar");
        }
    }
}
