using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ookly.Infrastructure.EntityFramework.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class Filters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryCategoryFilter_Filter_FiltersId",
                table: "CountryCategoryFilter");

            migrationBuilder.DropForeignKey(
                name: "FK_Filter_Categories_CategoryId",
                table: "Filter");

            migrationBuilder.DropForeignKey(
                name: "FK_Filter_Filter_ParentId",
                table: "Filter");

            migrationBuilder.DropForeignKey(
                name: "FK_ListingDetail_Filter_FilterId",
                table: "ListingDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filter",
                table: "Filter");

            migrationBuilder.RenameTable(
                name: "Filter",
                newName: "Filters");

            migrationBuilder.RenameIndex(
                name: "IX_Filter_ParentId",
                table: "Filters",
                newName: "IX_Filters_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_Filter_CategoryId",
                table: "Filters",
                newName: "IX_Filters_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filters",
                table: "Filters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryCategoryFilter_Filters_FiltersId",
                table: "CountryCategoryFilter",
                column: "FiltersId",
                principalTable: "Filters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Filters_Categories_CategoryId",
                table: "Filters",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Filters_Filters_ParentId",
                table: "Filters",
                column: "ParentId",
                principalTable: "Filters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ListingDetail_Filters_FilterId",
                table: "ListingDetail",
                column: "FilterId",
                principalTable: "Filters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryCategoryFilter_Filters_FiltersId",
                table: "CountryCategoryFilter");

            migrationBuilder.DropForeignKey(
                name: "FK_Filters_Categories_CategoryId",
                table: "Filters");

            migrationBuilder.DropForeignKey(
                name: "FK_Filters_Filters_ParentId",
                table: "Filters");

            migrationBuilder.DropForeignKey(
                name: "FK_ListingDetail_Filters_FilterId",
                table: "ListingDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Filters",
                table: "Filters");

            migrationBuilder.RenameTable(
                name: "Filters",
                newName: "Filter");

            migrationBuilder.RenameIndex(
                name: "IX_Filters_ParentId",
                table: "Filter",
                newName: "IX_Filter_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_Filters_CategoryId",
                table: "Filter",
                newName: "IX_Filter_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Filter",
                table: "Filter",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryCategoryFilter_Filter_FiltersId",
                table: "CountryCategoryFilter",
                column: "FiltersId",
                principalTable: "Filter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Filter_Categories_CategoryId",
                table: "Filter",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Filter_Filter_ParentId",
                table: "Filter",
                column: "ParentId",
                principalTable: "Filter",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ListingDetail_Filter_FilterId",
                table: "ListingDetail",
                column: "FilterId",
                principalTable: "Filter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
