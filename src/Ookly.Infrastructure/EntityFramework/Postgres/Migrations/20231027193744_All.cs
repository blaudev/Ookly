using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ookly.Infrastructure.EntityFramework.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class All : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleBrands",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleBrands", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "VehicleModels",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    VehicleBrandId = table.Column<string>(type: "character varying(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleModels_VehicleBrands_VehicleBrandId",
                        column: x => x.VehicleBrandId,
                        principalTable: "VehicleBrands",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ads",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ProcessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CategoryId = table.Column<string>(type: "character varying(20)", nullable: false),
                    SourceUrl = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Title = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    PictureUrl = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    CountryId = table.Column<string>(type: "character varying(20)", nullable: false),
                    State = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    City = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    VehicleBrandId = table.Column<string>(type: "character varying(20)", nullable: true),
                    VehicleModelId = table.Column<string>(type: "character varying(20)", nullable: true),
                    VehicleYear = table.Column<int>(type: "integer", nullable: true),
                    VehicleMileage = table.Column<int>(type: "integer", nullable: true),
                    VehicleFuelType = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    VehicleColor = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Surface = table.Column<int>(type: "integer", nullable: true),
                    Bedrooms = table.Column<int>(type: "integer", nullable: true),
                    Bathrooms = table.Column<int>(type: "integer", nullable: true),
                    Pets = table.Column<bool>(type: "boolean", nullable: true),
                    Furnished = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ads_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ads_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ads_VehicleBrands_VehicleBrandId",
                        column: x => x.VehicleBrandId,
                        principalTable: "VehicleBrands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ads_VehicleModels_VehicleModelId",
                        column: x => x.VehicleModelId,
                        principalTable: "VehicleModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ads_CategoryId",
                table: "Ads",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_CountryId",
                table: "Ads",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_VehicleBrandId",
                table: "Ads",
                column: "VehicleBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_VehicleModelId",
                table: "Ads",
                column: "VehicleModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryCountry_CountriesId",
                table: "CategoryCountry",
                column: "CountriesId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_VehicleBrandId",
                table: "VehicleModels",
                column: "VehicleBrandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ads");

            migrationBuilder.DropTable(
                name: "CategoryCountry");

            migrationBuilder.DropTable(
                name: "VehicleModels");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "VehicleBrands");
        }
    }
}
