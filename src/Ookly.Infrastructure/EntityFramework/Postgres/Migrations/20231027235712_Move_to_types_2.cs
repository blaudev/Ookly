using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ookly.Infrastructure.EntityFramework.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class Move_to_types_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryTypeFilterType");

            migrationBuilder.DropTable(
                name: "CountryCategory");

            migrationBuilder.DropTable(
                name: "CountryCategoryFilter");

            migrationBuilder.DropTable(
                name: "CountryFilter");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Filter",
                type: "character varying(40)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Filter",
                type: "character varying(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Category",
                type: "character varying(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Filter",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(40)");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Filter",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(60)",
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Category",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldMaxLength: 40);

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

            migrationBuilder.CreateTable(
                name: "CountryCategory",
                columns: table => new
                {
                    CategoryTypesId = table.Column<string>(type: "character varying(20)", nullable: false),
                    CountriesId = table.Column<string>(type: "character varying(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCategory", x => new { x.CategoryTypesId, x.CountriesId });
                    table.ForeignKey(
                        name: "FK_CountryCategory_Categories_CategoryTypesId",
                        column: x => x.CategoryTypesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryCategory_Countries_CountriesId",
                        column: x => x.CountriesId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryCategoryFilter",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<string>(type: "character varying(20)", nullable: false),
                    CountryId = table.Column<string>(type: "character varying(20)", nullable: false),
                    FilterId = table.Column<string>(type: "character varying(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCategoryFilter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryCategoryFilter_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryCategoryFilter_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryCategoryFilter_FilterType_FilterId",
                        column: x => x.FilterId,
                        principalTable: "FilterType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryFilter",
                columns: table => new
                {
                    CountriesId = table.Column<string>(type: "character varying(20)", nullable: false),
                    FilterTypesId = table.Column<string>(type: "character varying(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryFilter", x => new { x.CountriesId, x.FilterTypesId });
                    table.ForeignKey(
                        name: "FK_CountryFilter_Countries_CountriesId",
                        column: x => x.CountriesId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryFilter_FilterType_FilterTypesId",
                        column: x => x.FilterTypesId,
                        principalTable: "FilterType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTypeFilterType_FiltersId",
                table: "CategoryTypeFilterType",
                column: "FiltersId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryCategory_CountriesId",
                table: "CountryCategory",
                column: "CountriesId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryCategoryFilter_CategoryId",
                table: "CountryCategoryFilter",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryCategoryFilter_CountryId",
                table: "CountryCategoryFilter",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryCategoryFilter_FilterId",
                table: "CountryCategoryFilter",
                column: "FilterId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryFilter_FilterTypesId",
                table: "CountryFilter",
                column: "FilterTypesId");
        }
    }
}
