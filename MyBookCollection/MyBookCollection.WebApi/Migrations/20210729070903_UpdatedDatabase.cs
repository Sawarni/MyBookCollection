using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBookCollection.WebApi.Migrations
{
    public partial class UpdatedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookImageImageId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookImageImageId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ImageFile",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageContent = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageFile", x => x.ImageId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_BookImageImageId",
                table: "Characters",
                column: "BookImageImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookImageImageId",
                table: "Books",
                column: "BookImageImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_ImageFile_BookImageImageId",
                table: "Books",
                column: "BookImageImageId",
                principalTable: "ImageFile",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_ImageFile_BookImageImageId",
                table: "Characters",
                column: "BookImageImageId",
                principalTable: "ImageFile",
                principalColumn: "ImageId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_ImageFile_BookImageImageId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Characters_ImageFile_BookImageImageId",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "ImageFile");

            migrationBuilder.DropIndex(
                name: "IX_Characters_BookImageImageId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookImageImageId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookImageImageId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "BookImageImageId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Books");
        }
    }
}
