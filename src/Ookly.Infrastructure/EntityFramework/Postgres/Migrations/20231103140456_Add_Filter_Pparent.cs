using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ookly.Infrastructure.EntityFramework.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class Add_Filter_Pparent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ParentId",
                table: "Filter",
                type: "character varying(20)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Filter_ParentId",
                table: "Filter",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filter_Filter_ParentId",
                table: "Filter",
                column: "ParentId",
                principalTable: "Filter",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filter_Filter_ParentId",
                table: "Filter");

            migrationBuilder.DropIndex(
                name: "IX_Filter_ParentId",
                table: "Filter");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Filter");
        }
    }
}
