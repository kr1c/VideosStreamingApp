using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class Addedchangesinmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "AvailabilityTo",
                table: "Videos",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "AgeGroup", "AvailabilityFrom", "AvailabilityTo", "Description", "ParentVideoId", "Title", "Url", "VideoTypeId" },
                values: new object[,]
                {
                    { 1L, (byte)18, new DateTime(1994, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Skazani na Shawsank", null, "The Shawshank Redemption", null, 1 },
                    { 2L, (byte)16, new DateTime(1972, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "The Godfather", null, 1 },
                    { 3L, (byte)16, new DateTime(1974, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "The Godfather: Part II", null, 1 },
                    { 4L, (byte)12, new DateTime(2008, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "The Dark Knight", null, 1 },
                    { 5L, (byte)12, new DateTime(1957, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "12 Angry Men", null, 1 },
                    { 6L, (byte)12, new DateTime(1993, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Schindler's List", null, 1 },
                    { 7L, (byte)7, new DateTime(2003, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "The Lord of the Rings: The Return of the King", null, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AvailabilityTo",
                table: "Videos",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);
        }
    }
}
