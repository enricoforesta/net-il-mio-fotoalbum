using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_il_mio_fotoalbum.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaFoto_Categoria_CategoriaId",
                table: "CategoriaFoto");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "CategoriaFoto",
                newName: "CategorieId");

            migrationBuilder.AlterColumn<string>(
                name: "Titolo",
                table: "Foto",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descrizione",
                table: "Foto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaFoto_Categoria_CategorieId",
                table: "CategoriaFoto",
                column: "CategorieId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoriaFoto_Categoria_CategorieId",
                table: "CategoriaFoto");

            migrationBuilder.RenameColumn(
                name: "CategorieId",
                table: "CategoriaFoto",
                newName: "CategoriaId");

            migrationBuilder.AlterColumn<string>(
                name: "Titolo",
                table: "Foto",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "Descrizione",
                table: "Foto",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoriaFoto_Categoria_CategoriaId",
                table: "CategoriaFoto",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
