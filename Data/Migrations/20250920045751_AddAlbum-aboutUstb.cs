using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAlbumaboutUstb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutUsGallery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArName = table.Column<string>(type: "text", nullable: true),
                    EnName = table.Column<string>(type: "text", nullable: true),
                    ArImage = table.Column<string>(type: "text", nullable: true),
                    EnImage = table.Column<string>(type: "text", nullable: true),
                    ArYouTubeLink = table.Column<string>(type: "text", nullable: true),
                    EnYouTubeLink = table.Column<string>(type: "text", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUsGallery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    EnName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    EnPicture = table.Column<string>(type: "text", nullable: true),
                    ArPicture = table.Column<string>(type: "text", nullable: true),
                    ArVideo = table.Column<string>(type: "text", nullable: true),
                    EnVideo = table.Column<string>(type: "text", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlbumMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MediaType = table.Column<int>(type: "integer", nullable: false),
                    Picture = table.Column<string>(type: "text", nullable: true),
                    YouTubeLink = table.Column<string>(type: "text", nullable: true),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    FileLink = table.Column<string>(type: "text", nullable: true),
                    AlbumId = table.Column<int>(type: "integer", nullable: true),
                    AboutUsRelatedImagesId = table.Column<int>(type: "integer", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlbumMedias_AboutUsGallery_AboutUsRelatedImagesId",
                        column: x => x.AboutUsRelatedImagesId,
                        principalTable: "AboutUsGallery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlbumMedias_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlbumMedias_AboutUsRelatedImagesId",
                table: "AlbumMedias",
                column: "AboutUsRelatedImagesId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumMedias_AlbumId",
                table: "AlbumMedias",
                column: "AlbumId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumMedias");

            migrationBuilder.DropTable(
                name: "AboutUsGallery");

            migrationBuilder.DropTable(
                name: "Albums");
        }
    }
}
