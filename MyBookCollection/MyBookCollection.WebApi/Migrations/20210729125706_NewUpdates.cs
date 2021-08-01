using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBookCollection.WebApi.Migrations
{
    public partial class NewUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_ImageFile_BookImageImageId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_ImageFile_CharacterImageImageId",
                table: "Characters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageFile",
                table: "ImageFile");

            migrationBuilder.RenameTable(
                name: "ImageFile",
                newName: "ImageFiles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageFiles",
                table: "ImageFiles",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_ImageFiles_BookImageImageId",
                table: "Books",
                column: "BookImageImageId",
                principalTable: "ImageFiles",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_ImageFiles_CharacterImageImageId",
                table: "Characters",
                column: "CharacterImageImageId",
                principalTable: "ImageFiles",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_ImageFiles_BookImageImageId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_ImageFiles_CharacterImageImageId",
                table: "Characters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ImageFiles",
                table: "ImageFiles");

            migrationBuilder.RenameTable(
                name: "ImageFiles",
                newName: "ImageFile");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImageFile",
                table: "ImageFile",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_ImageFile_BookImageImageId",
                table: "Books",
                column: "BookImageImageId",
                principalTable: "ImageFile",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_ImageFile_CharacterImageImageId",
                table: "Characters",
                column: "CharacterImageImageId",
                principalTable: "ImageFile",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
