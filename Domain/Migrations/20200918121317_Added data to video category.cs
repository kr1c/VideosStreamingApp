using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class Addeddatatovideocategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VideoCategories",
                columns: new[] { "Id", "CategoryId", "VideoId" },
                values: new object[,]
                {
                    { 1L, 1L, 1L },
                    { 2L, 1L, 2L },
                    { 3L, 3L, 2L },
                    { 4L, 1L, 3L },
                    { 5L, 1L, 4L },
                    { 6L, 4L, 4L },
                    { 7L, 3L, 5L },
                    { 8L, 1L, 6L },
                    { 9L, 3L, 6L },
                    { 10L, 4L, 7L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VideoCategories",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "VideoCategories",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "VideoCategories",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "VideoCategories",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "VideoCategories",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "VideoCategories",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "VideoCategories",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "VideoCategories",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "VideoCategories",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "VideoCategories",
                keyColumn: "Id",
                keyValue: 10L);
        }
    }
}
