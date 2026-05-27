using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookmory.Migrations
{
    /// <inheritdoc />
    public partial class Editorial_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EditorialId",
                table: "Libros",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Editoriales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editoriales", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libros_EditorialId",
                table: "Libros",
                column: "EditorialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_Editoriales_EditorialId",
                table: "Libros",
                column: "EditorialId",
                principalTable: "Editoriales",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_Editoriales_EditorialId",
                table: "Libros");

            migrationBuilder.DropTable(
                name: "Editoriales");

            migrationBuilder.DropIndex(
                name: "IX_Libros_EditorialId",
                table: "Libros");

            migrationBuilder.DropColumn(
                name: "EditorialId",
                table: "Libros");
        }
    }
}
