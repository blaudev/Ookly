using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ookly.Infrastructure.EntityFramework.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class CountryCategoryFilter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filter",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filter", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "CountryCategoryFilter",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CountryId = table.Column<string>(type: "character varying(20)", nullable: false),
                    CategoryId = table.Column<string>(type: "character varying(20)", nullable: false),
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
                        name: "FK_CountryCategoryFilter_Filter_FilterId",
                        column: x => x.FilterId,
                        principalTable: "Filter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryFilter",
                columns: table => new
                {
                    CountriesId = table.Column<string>(type: "character varying(20)", nullable: false),
                    FiltersId = table.Column<string>(type: "character varying(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryFilter", x => new { x.CountriesId, x.FiltersId });
                    table.ForeignKey(
                        name: "FK_CountryFilter_Countries_CountriesId",
                        column: x => x.CountriesId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryFilter_Filter_FiltersId",
                        column: x => x.FiltersId,
                        principalTable: "Filter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryFilter_FiltersId",
                table: "CategoryFilter",
                column: "FiltersId");

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
                name: "IX_CountryFilter_FiltersId",
                table: "CountryFilter",
                column: "FiltersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryFilter");

            migrationBuilder.DropTable(
                name: "CountryCategoryFilter");

            migrationBuilder.DropTable(
                name: "CountryFilter");

            migrationBuilder.DropTable(
                name: "Filter");
        }
    }
}
