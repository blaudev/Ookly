using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ookly.Infrastructure.EntityFramework.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class Rename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryFilter_Filter_FilterTypeId",
                table: "CategoryFilter");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryCategory_Category_CategoryTypeId",
                table: "CountryCategory");

            migrationBuilder.DropTable(
                name: "Facet");

            migrationBuilder.RenameColumn(
                name: "CategoryTypeId",
                table: "CountryCategory",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_CountryCategory_CategoryTypeId",
                table: "CountryCategory",
                newName: "IX_CountryCategory_CategoryId");

            migrationBuilder.RenameColumn(
                name: "FilterTypeId",
                table: "CategoryFilter",
                newName: "FilterId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryFilter_FilterTypeId",
                table: "CategoryFilter",
                newName: "IX_CategoryFilter_FilterId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryFilter_Filter_FilterId",
                table: "CategoryFilter",
                column: "FilterId",
                principalTable: "Filter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryCategory_Category_CategoryId",
                table: "CountryCategory",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryFilter_Filter_FilterId",
                table: "CategoryFilter");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryCategory_Category_CategoryId",
                table: "CountryCategory");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "CountryCategory",
                newName: "CategoryTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CountryCategory_CategoryId",
                table: "CountryCategory",
                newName: "IX_CountryCategory_CategoryTypeId");

            migrationBuilder.RenameColumn(
                name: "FilterId",
                table: "CategoryFilter",
                newName: "FilterTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryFilter_FilterId",
                table: "CategoryFilter",
                newName: "IX_CategoryFilter_FilterTypeId");

            migrationBuilder.CreateTable(
                name: "Facet",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    FilterId = table.Column<string>(type: "character varying(60)", nullable: false),
                    Key = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facet_CategoryFilter_FilterId",
                        column: x => x.FilterId,
                        principalTable: "CategoryFilter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Facet_FilterId",
                table: "Facet",
                column: "FilterId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryFilter_Filter_FilterTypeId",
                table: "CategoryFilter",
                column: "FilterTypeId",
                principalTable: "Filter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryCategory_Category_CategoryTypeId",
                table: "CountryCategory",
                column: "CategoryTypeId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
