using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ookly.Infrastructure.EntityFramework.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class AdProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_CategoryType_CategoryId",
                table: "Ads");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Ads",
                type: "character varying(40)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)");

            migrationBuilder.CreateTable(
                name: "AdProperty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AdId = table.Column<Guid>(type: "uuid", nullable: false),
                    FilterTypeId = table.Column<string>(type: "character varying(20)", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TextValue = table.Column<string>(type: "text", nullable: true),
                    NumericValue = table.Column<decimal>(type: "numeric", nullable: true),
                    BooleanValue = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdProperty_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdProperty_FilterType_FilterTypeId",
                        column: x => x.FilterTypeId,
                        principalTable: "FilterType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdProperty_AdId",
                table: "AdProperty",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_AdProperty_FilterTypeId",
                table: "AdProperty",
                column: "FilterTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Category_CategoryId",
                table: "Ads",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Category_CategoryId",
                table: "Ads");

            migrationBuilder.DropTable(
                name: "AdProperty");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Ads",
                type: "character varying(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(40)");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_CategoryType_CategoryId",
                table: "Ads",
                column: "CategoryId",
                principalTable: "CategoryType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
