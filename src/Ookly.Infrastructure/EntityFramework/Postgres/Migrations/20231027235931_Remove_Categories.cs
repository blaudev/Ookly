using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ookly.Infrastructure.EntityFramework.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Categories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Categories_CategoryId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_Categories_CategoryTypeId",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "CategoryType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryType",
                table: "CategoryType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_CategoryType_CategoryId",
                table: "Ads",
                column: "CategoryId",
                principalTable: "CategoryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_CategoryType_CategoryTypeId",
                table: "Category",
                column: "CategoryTypeId",
                principalTable: "CategoryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_CategoryType_CategoryId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_CategoryType_CategoryTypeId",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryType",
                table: "CategoryType");

            migrationBuilder.RenameTable(
                name: "CategoryType",
                newName: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Categories_CategoryId",
                table: "Ads",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Categories_CategoryTypeId",
                table: "Category",
                column: "CategoryTypeId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
