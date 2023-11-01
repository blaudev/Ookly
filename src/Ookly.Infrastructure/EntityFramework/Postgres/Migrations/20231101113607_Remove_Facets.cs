using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ookly.Infrastructure.EntityFramework.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Facets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdProperty_Filter_FilterTypeId",
                table: "AdProperty");

            migrationBuilder.DropTable(
                name: "VehicleModels");

            migrationBuilder.DropTable(
                name: "VehicleBrands");

            migrationBuilder.RenameColumn(
                name: "FilterTypeId",
                table: "AdProperty",
                newName: "FilterId");

            migrationBuilder.RenameIndex(
                name: "IX_AdProperty_FilterTypeId",
                table: "AdProperty",
                newName: "IX_AdProperty_FilterId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdProperty_Filter_FilterId",
                table: "AdProperty",
                column: "FilterId",
                principalTable: "Filter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdProperty_Filter_FilterId",
                table: "AdProperty");

            migrationBuilder.RenameColumn(
                name: "FilterId",
                table: "AdProperty",
                newName: "FilterTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_AdProperty_FilterId",
                table: "AdProperty",
                newName: "IX_AdProperty_FilterTypeId");

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

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_VehicleBrandId",
                table: "VehicleModels",
                column: "VehicleBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdProperty_Filter_FilterTypeId",
                table: "AdProperty",
                column: "FilterTypeId",
                principalTable: "Filter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
