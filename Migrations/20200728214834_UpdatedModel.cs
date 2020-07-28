using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsApi.Migrations
{
    public partial class UpdatedModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "PublishedAt",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "News",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HeadLine",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedDate",
                table: "News",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Category",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_News_CategoryId",
                table: "News",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Category_CategoryId",
                table: "News",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Category_CategoryId",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_News_CategoryId",
                table: "News");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "HeadLine",
                table: "News");

            migrationBuilder.DropColumn(
                name: "PublishedDate",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedAt",
                table: "News",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "ID");
        }
    }
}
