using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class Addedmissingunique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VideoCategories_CategoryId_VideoId",
                table: "VideoCategories");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCategories_CategoryId_VideoId",
                table: "VideoCategories",
                columns: new[] { "CategoryId", "VideoId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VideoCategories_CategoryId_VideoId",
                table: "VideoCategories");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCategories_CategoryId_VideoId",
                table: "VideoCategories",
                columns: new[] { "CategoryId", "VideoId" });
        }
    }
}
