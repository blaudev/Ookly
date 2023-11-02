using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ookly.Infrastructure.EntityFramework.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class Update_Names : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryFilter_CountryCategory_CategoryId",
                table: "CategoryFilter");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "CategoryFilter",
                newName: "CountryCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryFilter_CategoryId",
                table: "CategoryFilter",
                newName: "IX_CategoryFilter_CountryCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryFilter_CountryCategory_CountryCategoryId",
                table: "CategoryFilter",
                column: "CountryCategoryId",
                principalTable: "CountryCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryFilter_CountryCategory_CountryCategoryId",
                table: "CategoryFilter");

            migrationBuilder.RenameColumn(
                name: "CountryCategoryId",
                table: "CategoryFilter",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryFilter_CountryCategoryId",
                table: "CategoryFilter",
                newName: "IX_CategoryFilter_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryFilter_CountryCategory_CategoryId",
                table: "CategoryFilter",
                column: "CategoryId",
                principalTable: "CountryCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
