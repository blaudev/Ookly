using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ookly.Infrastructure.EntityFramework.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class Ad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Ads",
                type: "character varying(300)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Ads",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

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
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "Ads",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Ads",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
                name: "PictureUrl",
                table: "Ads",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "Price",
                table: "Ads",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProcessedAt",
                table: "Ads",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceUrl",
                table: "Ads",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Ads",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Ads",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Surface",
                table: "Ads",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleBrandId",
                table: "Ads",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleColor",
                table: "Ads",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VehicleFuelType",
                table: "Ads",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleMileage",
                table: "Ads",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VehicleModelId",
                table: "Ads",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VehicleYear",
                table: "Ads",
                type: "integer",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Countries_CountryId",
                table: "Ads",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Countries_CountryId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Ads_VehicleBrands_VehicleBrandId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Ads_VehicleModels_VehicleModelId",
                table: "Ads");

            migrationBuilder.DropIndex(
                name: "IX_Ads_CountryId",
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
                name: "CountryId",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "Furnished",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "Pets",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "ProcessedAt",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "SourceUrl",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "Status",
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
                name: "Title",
                table: "Ads",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(300)",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Ads",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
