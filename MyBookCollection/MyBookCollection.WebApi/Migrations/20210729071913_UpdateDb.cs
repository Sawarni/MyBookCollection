using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBookCollection.WebApi.Migrations
{
    public partial class UpdateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_ImageFile_BookImageImageId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_BookImageImageId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "BookImageImageId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "PiublisherName",
                table: "Publishers",
                newName: "PublisherName");

            migrationBuilder.RenameColumn(
                name: "ImageId",
                table: "Characters",
                newName: "CharacterImageImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharacterImageImageId",
                table: "Characters",
                column: "CharacterImageImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_ImageFile_CharacterImageImageId",
                table: "Characters",
                column: "CharacterImageImageId",
                principalTable: "ImageFile",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_ImageFile_CharacterImageImageId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_CharacterImageImageId",
                table: "Characters");

            migrationBuilder.RenameColumn(
                name: "PublisherName",
                table: "Publishers",
                newName: "PiublisherName");

            migrationBuilder.RenameColumn(
                name: "CharacterImageImageId",
                table: "Characters",
                newName: "ImageId");

            migrationBuilder.AddColumn<int>(
                name: "BookImageImageId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_BookImageImageId",
                table: "Characters",
                column: "BookImageImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_ImageFile_BookImageImageId",
                table: "Characters",
                column: "BookImageImageId",
                principalTable: "ImageFile",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
