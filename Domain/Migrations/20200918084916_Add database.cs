using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class Adddatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CastPersonTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastPersonTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Predefined = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoImageTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoImageTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CastPersons",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Biography = table.Column<string>(maxLength: 2000, nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime", nullable: false),
                    CastPersonTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CastPersons_CastPersonTypes_CastPersonTypeId",
                        column: x => x.CastPersonTypeId,
                        principalTable: "CastPersonTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    AgeGroup = table.Column<byte>(type: "tinyint", nullable: false),
                    AvailabilityFrom = table.Column<DateTime>(type: "datetime", nullable: false),
                    AvailabilityTo = table.Column<DateTime>(type: "datetime", nullable: false),
                    Url = table.Column<string>(maxLength: 1000, nullable: true),
                    ParentVideoId = table.Column<long>(nullable: true),
                    VideoTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_Videos_ParentVideoId",
                        column: x => x.ParentVideoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Videos_VideoTypes_VideoTypeId",
                        column: x => x.VideoTypeId,
                        principalTable: "VideoTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoCasts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoId = table.Column<long>(nullable: false),
                    CastPersonId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoCasts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoCasts_CastPersons_CastPersonId",
                        column: x => x.CastPersonId,
                        principalTable: "CastPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoCasts_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoCategories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoId = table.Column<long>(nullable: false),
                    CategoryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoCategories_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoImages",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: true),
                    VideoId = table.Column<long>(nullable: false),
                    VideoImageTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoImages_Videos_VideoId",
                        column: x => x.VideoId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideoImages_VideoImageTypes_VideoImageTypeId",
                        column: x => x.VideoImageTypeId,
                        principalTable: "VideoImageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CastPersonTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Director" },
                    { 2, "Actor" },
                    { 3, "Screenwriter" },
                    { 4, "Producer" },
                    { 5, "Costume Designer" },
                    { 6, "Cinematographer" },
                    { 7, "Editor" },
                    { 8, "Music Supervisor" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 8L, null, "Thriller" },
                    { 7L, null, "Romance" },
                    { 6L, null, "Mystery" },
                    { 5L, null, "Horror" },
                    { 3L, null, "Drama" },
                    { 2L, null, "Comedy" },
                    { 1L, null, "Action" },
                    { 4L, null, "Fantasy" }
                });

            migrationBuilder.InsertData(
                table: "VideoImageTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "FRAME" },
                    { 2, "COVER" }
                });

            migrationBuilder.InsertData(
                table: "VideoTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 6, "Channel" },
                    { 1, "Vod" },
                    { 2, "Live" },
                    { 3, "Series" },
                    { 4, "Season" },
                    { 5, "Episode" },
                    { 7, "Program" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CastPersons_CastPersonTypeId",
                table: "CastPersons",
                column: "CastPersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CastPersonTypes_Name",
                table: "CastPersonTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VideoCasts_CastPersonId",
                table: "VideoCasts",
                column: "CastPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCasts_VideoId",
                table: "VideoCasts",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCategories_CategoryId",
                table: "VideoCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoCategories_VideoId",
                table: "VideoCategories",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoImages_VideoId",
                table: "VideoImages",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoImages_VideoImageTypeId",
                table: "VideoImages",
                column: "VideoImageTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoImageTypes_Name",
                table: "VideoImageTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Videos_ParentVideoId",
                table: "Videos",
                column: "ParentVideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_VideoTypeId",
                table: "Videos",
                column: "VideoTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoTypes_Name",
                table: "VideoTypes",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoCasts");

            migrationBuilder.DropTable(
                name: "VideoCategories");

            migrationBuilder.DropTable(
                name: "VideoImages");

            migrationBuilder.DropTable(
                name: "CastPersons");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "VideoImageTypes");

            migrationBuilder.DropTable(
                name: "CastPersonTypes");

            migrationBuilder.DropTable(
                name: "VideoTypes");
        }
    }
}
