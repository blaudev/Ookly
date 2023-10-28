using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ookly.Infrastructure.EntityFramework.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class Move_to_types : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryCategory_Categories_CategoriesId",
                table: "CountryCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryCategoryFilter_Filter_FilterId",
                table: "CountryCategoryFilter");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryFilter_Filter_FiltersId",
                table: "CountryFilter");

            migrationBuilder.DropTable(
                name: "CategoryFilter");

            migrationBuilder.RenameColumn(
                name: "FiltersId",
                table: "CountryFilter",
                newName: "FilterTypesId");

            migrationBuilder.RenameIndex(
                name: "IX_CountryFilter_FiltersId",
                table: "CountryFilter",
                newName: "IX_CountryFilter_FilterTypesId");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                table: "CountryCategory",
                newName: "CategoryTypesId");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Filter",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "Filter",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FilterTypeId",
                table: "Filter",
                type: "character varying(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CountryId = table.Column<string>(type: "character varying(20)", nullable: false),
                    CategoryTypeId = table.Column<string>(type: "character varying(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Categories_CategoryTypeId",
                        column: x => x.CategoryTypeId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Category_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilterType",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTypeFilterType",
                columns: table => new
                {
                    CategoriesId = table.Column<string>(type: "character varying(20)", nullable: false),
                    FiltersId = table.Column<string>(type: "character varying(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTypeFilterType", x => new { x.CategoriesId, x.FiltersId });
                    table.ForeignKey(
                        name: "FK_CategoryTypeFilterType_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryTypeFilterType_FilterType_FiltersId",
                        column: x => x.FiltersId,
                        principalTable: "FilterType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filter_CategoryId",
                table: "Filter",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Filter_FilterTypeId",
                table: "Filter",
                column: "FilterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_CategoryTypeId",
                table: "Category",
                column: "CategoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_CountryId",
                table: "Category",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTypeFilterType_FiltersId",
                table: "CategoryTypeFilterType",
                column: "FiltersId");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryCategory_Categories_CategoryTypesId",
                table: "CountryCategory",
                column: "CategoryTypesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryCategoryFilter_FilterType_FilterId",
                table: "CountryCategoryFilter",
                column: "FilterId",
                principalTable: "FilterType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryFilter_FilterType_FilterTypesId",
                table: "CountryFilter",
                column: "FilterTypesId",
                principalTable: "FilterType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Filter_Category_CategoryId",
                table: "Filter",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Filter_FilterType_FilterTypeId",
                table: "Filter",
                column: "FilterTypeId",
                principalTable: "FilterType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CountryCategory_Categories_CategoryTypesId",
                table: "CountryCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryCategoryFilter_FilterType_FilterId",
                table: "CountryCategoryFilter");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryFilter_FilterType_FilterTypesId",
                table: "CountryFilter");

            migrationBuilder.DropForeignKey(
                name: "FK_Filter_Category_CategoryId",
                table: "Filter");

            migrationBuilder.DropForeignKey(
                name: "FK_Filter_FilterType_FilterTypeId",
                table: "Filter");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "CategoryTypeFilterType");

            migrationBuilder.DropTable(
                name: "FilterType");

            migrationBuilder.DropIndex(
                name: "IX_Filter_CategoryId",
                table: "Filter");

            migrationBuilder.DropIndex(
                name: "IX_Filter_FilterTypeId",
                table: "Filter");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Filter");

            migrationBuilder.DropColumn(
                name: "FilterTypeId",
                table: "Filter");

            migrationBuilder.RenameColumn(
                name: "FilterTypesId",
                table: "CountryFilter",
                newName: "FiltersId");

            migrationBuilder.RenameIndex(
                name: "IX_CountryFilter_FilterTypesId",
                table: "CountryFilter",
                newName: "IX_CountryFilter_FiltersId");

            migrationBuilder.RenameColumn(
                name: "CategoryTypesId",
                table: "CountryCategory",
                newName: "CategoriesId");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Filter",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "CategoryFilter",
                columns: table => new
                {
                    CategoriesId = table.Column<string>(type: "character varying(20)", nullable: false),
                    FiltersId = table.Column<string>(type: "character varying(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryFilter", x => new { x.CategoriesId, x.FiltersId });
                    table.ForeignKey(
                        name: "FK_CategoryFilter_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryFilter_Filter_FiltersId",
                        column: x => x.FiltersId,
                        principalTable: "Filter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryFilter_FiltersId",
                table: "CategoryFilter",
                column: "FiltersId");

            migrationBuilder.AddForeignKey(
                name: "FK_CountryCategory_Categories_CategoriesId",
                table: "CountryCategory",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryCategoryFilter_Filter_FilterId",
                table: "CountryCategoryFilter",
                column: "FilterId",
                principalTable: "Filter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryFilter_Filter_FiltersId",
                table: "CountryFilter",
                column: "FiltersId",
                principalTable: "Filter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
