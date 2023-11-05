using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ookly.Infrastructure.EntityFramework.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class Listing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listing_Countries_CountryId",
                table: "Listing");

            migrationBuilder.DropForeignKey(
                name: "FK_Listing_CountryCategories_CategoryId",
                table: "Listing");

            migrationBuilder.DropForeignKey(
                name: "FK_ListingDetail_Filters_FilterId",
                table: "ListingDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ListingDetail_Listing_AdId",
                table: "ListingDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ListingDetail",
                table: "ListingDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Listing",
                table: "Listing");

            migrationBuilder.RenameTable(
                name: "ListingDetail",
                newName: "ListingDetails");

            migrationBuilder.RenameTable(
                name: "Listing",
                newName: "Listings");

            migrationBuilder.RenameIndex(
                name: "IX_ListingDetail_FilterId",
                table: "ListingDetails",
                newName: "IX_ListingDetails_FilterId");

            migrationBuilder.RenameIndex(
                name: "IX_ListingDetail_AdId",
                table: "ListingDetails",
                newName: "IX_ListingDetails_AdId");

            migrationBuilder.RenameIndex(
                name: "IX_Listing_CountryId",
                table: "Listings",
                newName: "IX_Listings_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Listing_CategoryId",
                table: "Listings",
                newName: "IX_Listings_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListingDetails",
                table: "ListingDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Listings",
                table: "Listings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ListingDetails_Filters_FilterId",
                table: "ListingDetails",
                column: "FilterId",
                principalTable: "Filters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListingDetails_Listings_AdId",
                table: "ListingDetails",
                column: "AdId",
                principalTable: "Listings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Countries_CountryId",
                table: "Listings",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_CountryCategories_CategoryId",
                table: "Listings",
                column: "CategoryId",
                principalTable: "CountryCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListingDetails_Filters_FilterId",
                table: "ListingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ListingDetails_Listings_AdId",
                table: "ListingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Countries_CountryId",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_CountryCategories_CategoryId",
                table: "Listings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Listings",
                table: "Listings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ListingDetails",
                table: "ListingDetails");

            migrationBuilder.RenameTable(
                name: "Listings",
                newName: "Listing");

            migrationBuilder.RenameTable(
                name: "ListingDetails",
                newName: "ListingDetail");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_CountryId",
                table: "Listing",
                newName: "IX_Listing_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Listings_CategoryId",
                table: "Listing",
                newName: "IX_Listing_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ListingDetails_FilterId",
                table: "ListingDetail",
                newName: "IX_ListingDetail_FilterId");

            migrationBuilder.RenameIndex(
                name: "IX_ListingDetails_AdId",
                table: "ListingDetail",
                newName: "IX_ListingDetail_AdId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Listing",
                table: "Listing",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ListingDetail",
                table: "ListingDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Listing_Countries_CountryId",
                table: "Listing",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listing_CountryCategories_CategoryId",
                table: "Listing",
                column: "CategoryId",
                principalTable: "CountryCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListingDetail_Filters_FilterId",
                table: "ListingDetail",
                column: "FilterId",
                principalTable: "Filters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListingDetail_Listing_AdId",
                table: "ListingDetail",
                column: "AdId",
                principalTable: "Listing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
