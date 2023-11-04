using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ookly.Infrastructure.EntityFramework.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class Country_Name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryFilter_CountryCategory_CountryCategoryId",
                table: "CategoryFilter");

            migrationBuilder.DropForeignKey(
                name: "FK_Filter_Category_CategoryId",
                table: "Filter");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_CountryCategory_CategoryId",
                table: "Listings");

            migrationBuilder.DropTable(
                name: "CountryCategory");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Countries",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Category",
                type: "character varying(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "CategoryId",
                table: "Category",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CategoryTypeId",
                table: "Category",
                type: "character varying(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryId",
                table: "Category",
                type: "character varying(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Category",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Category_CategoryTypeId",
                table: "Category",
                column: "CategoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_CountryId",
                table: "Category",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_CategoryType_CategoryTypeId",
                table: "Category",
                column: "CategoryTypeId",
                principalTable: "CategoryType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Countries_CountryId",
                table: "Category",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryFilter_Category_CountryCategoryId",
                table: "CategoryFilter",
                column: "CountryCategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Filter_CategoryType_CategoryId",
                table: "Filter",
                column: "CategoryId",
                principalTable: "CategoryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Category_CategoryId",
                table: "Listings",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_CategoryType_CategoryTypeId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_Category_Countries_CountryId",
                table: "Category");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryFilter_Category_CountryCategoryId",
                table: "CategoryFilter");

            migrationBuilder.DropForeignKey(
                name: "FK_Filter_CategoryType_CategoryId",
                table: "Filter");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Category_CategoryId",
                table: "Listings");

            migrationBuilder.DropTable(
                name: "CategoryType");

            migrationBuilder.DropIndex(
                name: "IX_Category_CategoryTypeId",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_CountryId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CategoryTypeId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Category");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Category",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldMaxLength: 40);

            migrationBuilder.CreateTable(
                name: "CountryCategory",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    CategoryId = table.Column<string>(type: "character varying(20)", nullable: false),
                    CountryId = table.Column<string>(type: "character varying(20)", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryCategory_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryCategory_CategoryId",
                table: "CountryCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryCategory_CountryId",
                table: "CountryCategory",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryFilter_CountryCategory_CountryCategoryId",
                table: "CategoryFilter",
                column: "CountryCategoryId",
                principalTable: "CountryCategory",
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
                name: "FK_Listings_CountryCategory_CategoryId",
                table: "Listings",
                column: "CategoryId",
                principalTable: "CountryCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
