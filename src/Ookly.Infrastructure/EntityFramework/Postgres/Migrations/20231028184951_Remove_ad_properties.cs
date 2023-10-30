using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ookly.Infrastructure.EntityFramework.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class Remove_ad_properties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdProperty_FilterType_FilterTypeId",
                table: "AdProperty");

            migrationBuilder.DropForeignKey(
                name: "FK_Ads_VehicleBrands_VehicleBrandId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Ads_VehicleModels_VehicleModelId",
                table: "Ads");

            migrationBuilder.DropIndex(
                name: "IX_Ads_VehicleBrandId",
                table: "Ads");

            migrationBuilder.DropIndex(
                name: "IX_Ads_VehicleModelId",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "Bathrooms",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "Bedrooms",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "Furnished",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "Pets",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "Surface",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "VehicleBrandId",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "VehicleColor",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "VehicleFuelType",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "VehicleMileage",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "VehicleModelId",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "VehicleYear",
                table: "Ads");

            migrationBuilder.AlterColumn<string>(
                name: "FilterTypeId",
                table: "AdProperty",
                type: "character varying(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AdProperty_FilterType_FilterTypeId",
                table: "AdProperty",
                column: "FilterTypeId",
                principalTable: "FilterType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdProperty_FilterType_FilterTypeId",
                table: "AdProperty");

            migrationBuilder.AddColumn<int>(
                name: "Bathrooms",
                table: "Ads",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Bedrooms",
                table: "Ads",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Ads",
                type: "character varying(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Furnished",
                table: "Ads",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Pets",
                table: "Ads",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Ads",
                type: "character varying(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Surface",
                table: "Ads",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleBrandId",
                table: "Ads",
                type: "character varying(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleColor",
                table: "Ads",
                type: "character varying(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleFuelType",
                table: "Ads",
                type: "character varying(10)",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleMileage",
                table: "Ads",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleModelId",
                table: "Ads",
                type: "character varying(20)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleYear",
                table: "Ads",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FilterTypeId",
                table: "AdProperty",
                type: "character varying(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_VehicleBrandId",
                table: "Ads",
                column: "VehicleBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_VehicleModelId",
                table: "Ads",
                column: "VehicleModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdProperty_FilterType_FilterTypeId",
                table: "AdProperty",
                column: "FilterTypeId",
                principalTable: "FilterType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_VehicleBrands_VehicleBrandId",
                table: "Ads",
                column: "VehicleBrandId",
                principalTable: "VehicleBrands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_VehicleModels_VehicleModelId",
                table: "Ads",
                column: "VehicleModelId",
                principalTable: "VehicleModels",
                principalColumn: "Id");
        }
    }
}
