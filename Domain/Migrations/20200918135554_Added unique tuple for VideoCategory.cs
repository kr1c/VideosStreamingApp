using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class AddeduniquetupleforVideoCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VideoCategories_CategoryId",
                table: "VideoCategories");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCategories_CategoryId_VideoId",
                table: "VideoCategories",
                columns: new[] { "CategoryId", "VideoId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VideoCategories_CategoryId_VideoId",
                table: "VideoCategories");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCategories_CategoryId",
                table: "VideoCategories",
                column: "CategoryId");
        }
    }
}
