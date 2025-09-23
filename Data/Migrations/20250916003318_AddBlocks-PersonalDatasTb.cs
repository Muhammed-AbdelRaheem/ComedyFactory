using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBlocksPersonalDatasTb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    EnName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ArLine1 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    EnLine1 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ArLine2 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    EnLine2 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    ArContent = table.Column<string>(type: "text", nullable: true),
                    EnContent = table.Column<string>(type: "text", nullable: true),
                    ArPicture = table.Column<string>(type: "text", nullable: true),
                    EnPicture = table.Column<string>(type: "text", nullable: true),
                    VideoURL = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Mobile = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Fax = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    BlockType = table.Column<int>(type: "integer", nullable: false),
                    ArDescription = table.Column<string>(type: "text", nullable: true),
                    EnDescription = table.Column<string>(type: "text", nullable: true),
                    ArYoutubeVideo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    EnYoutubeVideo = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    BirthPlace = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    Nationality = table.Column<string>(type: "text", nullable: true),
                    Photo = table.Column<string>(type: "text", nullable: true),
                    DesireToRegister = table.Column<int>(type: "integer", nullable: false),
                    Genders = table.Column<int>(type: "integer", nullable: false),
                    NationalityId = table.Column<int>(type: "integer", nullable: true),
                    CountryId = table.Column<int>(type: "integer", nullable: true),
                    CityId = table.Column<int>(type: "integer", nullable: true),
                    DesireId = table.Column<int>(type: "integer", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalDatas_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonalDatas_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonalDatas_Desires_DesireId",
                        column: x => x.DesireId,
                        principalTable: "Desires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonalDatas_Nationality_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDatas_CityId",
                table: "PersonalDatas",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDatas_CountryId",
                table: "PersonalDatas",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDatas_DesireId",
                table: "PersonalDatas",
                column: "DesireId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDatas_NationalityId",
                table: "PersonalDatas",
                column: "NationalityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blocks");

            migrationBuilder.DropTable(
                name: "PersonalDatas");
        }
    }
}
