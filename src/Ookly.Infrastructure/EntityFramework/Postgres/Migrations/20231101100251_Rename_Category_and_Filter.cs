using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ookly.Infrastructure.EntityFramework.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class Rename_Category_and_Filter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Category_CategoryId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Facet_Filter_FilterId",
                table: "Facet");

            migrationBuilder.DropTable(
                name: "Filter");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.CreateTable(
                name: "CountryCategory",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CountryId = table.Column<string>(type: "character varying(20)", nullable: false),
                    CategoryTypeId = table.Column<string>(type: "character varying(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryCategory_CategoryType_CategoryTypeId",
                        column: x => x.CategoryTypeId,
                        principalTable: "CategoryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryCategory_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryFilter",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    CategoryId = table.Column<string>(type: "character varying(40)", nullable: false),
                    FilterTypeId = table.Column<string>(type: "character varying(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryFilter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryFilter_CountryCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CountryCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryFilter_FilterType_FilterTypeId",
                        column: x => x.FilterTypeId,
                        principalTable: "FilterType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryFilter_CategoryId",
                table: "CategoryFilter",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryFilter_FilterTypeId",
                table: "CategoryFilter",
                column: "FilterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryCategory_CategoryTypeId",
                table: "CountryCategory",
                column: "CategoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryCategory_CountryId",
                table: "CountryCategory",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_CountryCategory_CategoryId",
                table: "Ads",
                column: "CategoryId",
                principalTable: "CountryCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facet_CategoryFilter_FilterId",
                table: "Facet",
                column: "FilterId",
                principalTable: "CategoryFilter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_CountryCategory_CategoryId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Facet_CategoryFilter_FilterId",
                table: "Facet");

            migrationBuilder.DropTable(
                name: "CategoryFilter");

            migrationBuilder.DropTable(
                name: "CountryCategory");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CategoryTypeId = table.Column<string>(type: "character varying(20)", nullable: false),
                    CountryId = table.Column<string>(type: "character varying(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_CategoryType_CategoryTypeId",
                        column: x => x.CategoryTypeId,
                        principalTable: "CategoryType",
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
                name: "Filter",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    CategoryId = table.Column<string>(type: "character varying(40)", nullable: false),
                    FilterTypeId = table.Column<string>(type: "character varying(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filter_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Filter_FilterType_FilterTypeId",
                        column: x => x.FilterTypeId,
                        principalTable: "FilterType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_CategoryTypeId",
                table: "Category",
                column: "CategoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_CountryId",
                table: "Category",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Filter_CategoryId",
                table: "Filter",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Filter_FilterTypeId",
                table: "Filter",
                column: "FilterTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Category_CategoryId",
                table: "Ads",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facet_Filter_FilterId",
                table: "Facet",
                column: "FilterId",
                principalTable: "Filter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
