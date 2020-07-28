using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsApi.Migrations
{
    public partial class CategoryIdRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Category_CategoryId",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "News",
                newName: "CategoryID");

            migrationBuilder.RenameIndex(
                name: "IX_News_CategoryId",
                table: "News",
                newName: "IX_News_CategoryID");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "News",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Category_CategoryID",
                table: "News",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Category_CategoryID",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "News",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_News_CategoryID",
                table: "News",
                newName: "IX_News_CategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "News",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_News_Category_CategoryId",
                table: "News",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
