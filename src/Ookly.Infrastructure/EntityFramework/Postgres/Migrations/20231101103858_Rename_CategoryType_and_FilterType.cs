using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ookly.Infrastructure.EntityFramework.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class Rename_CategoryType_and_FilterType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdProperty_FilterType_FilterTypeId",
                table: "AdProperty");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryFilter_FilterType_FilterTypeId",
                table: "CategoryFilter");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryCategory_CategoryType_CategoryTypeId",
                table: "CountryCategory");

            migrationBuilder.DropTable(
                name: "CategoryType");

            migrationBuilder.DropTable(
                name: "FilterType");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filter",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ValueType = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filter", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AdProperty_Filter_FilterTypeId",
                table: "AdProperty",
                column: "FilterTypeId",
                principalTable: "Filter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdProperty_Filter_FilterTypeId",
                table: "AdProperty");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryFilter_Filter_FilterTypeId",
                table: "CategoryFilter");

            migrationBuilder.DropForeignKey(
                name: "FK_CountryCategory_Category_CategoryTypeId",
                table: "CountryCategory");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Filter");

            migrationBuilder.CreateTable(
                name: "CategoryType",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FilterType",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ValueType = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterType", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AdProperty_FilterType_FilterTypeId",
                table: "AdProperty",
                column: "FilterTypeId",
                principalTable: "FilterType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryFilter_FilterType_FilterTypeId",
                table: "CategoryFilter",
                column: "FilterTypeId",
                principalTable: "FilterType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryCategory_CategoryType_CategoryTypeId",
                table: "CountryCategory",
                column: "CategoryTypeId",
                principalTable: "CategoryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
