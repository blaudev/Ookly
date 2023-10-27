using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ookly.Infrastructure.EntityFramework.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class Rename_CountryCategory_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryCountry");

            migrationBuilder.CreateTable(
                name: "CountryCategory",
                columns: table => new
                {
                    CategoriesId = table.Column<string>(type: "character varying(20)", nullable: false),
                    CountriesId = table.Column<string>(type: "character varying(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCategory", x => new { x.CategoriesId, x.CountriesId });
                    table.ForeignKey(
                        name: "FK_CountryCategory_Categories_CategoriesId",
                        column: x => x.CategoriesId,
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

            migrationBuilder.CreateIndex(
                name: "IX_CountryCategory_CountriesId",
                table: "CountryCategory",
                column: "CountriesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryCategory");

            migrationBuilder.CreateTable(
                name: "CategoryCountry",
                columns: table => new
                {
                    CategoriesId = table.Column<string>(type: "character varying(20)", nullable: false),
                    CountriesId = table.Column<string>(type: "character varying(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryCountry", x => new { x.CategoriesId, x.CountriesId });
                    table.ForeignKey(
                        name: "FK_CategoryCountry_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryCountry_Countries_CountriesId",
                        column: x => x.CountriesId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryCountry_CountriesId",
                table: "CategoryCountry",
                column: "CountriesId");
        }
    }
}
