using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ookly.Infrastructure.EntityFramework.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class CategoryFilter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "Filter",
                type: "character varying(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Filter_CategoryId",
                table: "Filter",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filter_Category_CategoryId",
                table: "Filter",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filter_Category_CategoryId",
                table: "Filter");

            migrationBuilder.DropIndex(
                name: "IX_Filter_CategoryId",
                table: "Filter");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Filter");
        }
    }
}
