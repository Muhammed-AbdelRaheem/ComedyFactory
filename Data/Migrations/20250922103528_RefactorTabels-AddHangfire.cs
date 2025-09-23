using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactorTabelsAddHangfire : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Registration_RegistrationId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AlbumMedias");

            migrationBuilder.DropTable(
                name: "BookingTicket");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "FAQS");

            migrationBuilder.DropTable(
                name: "HomeBanners");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "RefundOrder");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropTable(
                name: "SNSSubscription");

            migrationBuilder.DropTable(
                name: "UserNotification");

            migrationBuilder.DropTable(
                name: "WeightRangeWithDayWithSlot");

            migrationBuilder.DropTable(
                name: "AboutUsGallery");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "WeightRangeWithDay");

            migrationBuilder.DropTable(
                name: "UserBooking");

            migrationBuilder.DropTable(
                name: "Calendar");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "WeightRange");

            migrationBuilder.DropTable(
                name: "Tournament");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RegistrationId",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutUsGallery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArImage = table.Column<string>(type: "text", nullable: true),
                    ArName = table.Column<string>(type: "text", nullable: true),
                    ArYouTubeLink = table.Column<string>(type: "text", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    EnImage = table.Column<string>(type: "text", nullable: true),
                    EnName = table.Column<string>(type: "text", nullable: true),
                    EnYouTubeLink = table.Column<string>(type: "text", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                    ArPicture = table.Column<string>(type: "text", nullable: true),
                    ArVideo = table.Column<string>(type: "text", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    EnName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    EnPicture = table.Column<string>(type: "text", nullable: true),
                    EnVideo = table.Column<string>(type: "text", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FAQS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ArName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    EnDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    EnName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeBanners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ArName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ArPicture = table.Column<string>(type: "text", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    EnDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    EnName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    EnPicture = table.Column<string>(type: "text", nullable: false),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false),
                    Link = table.Column<string>(type: "text", nullable: true),
                    LinkTarget = table.Column<int>(type: "integer", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeBanners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArContent = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ArName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    EnContent = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    EnName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NationalityId = table.Column<int>(type: "integer", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: true),
                    ApproveFirstApprovalBooking = table.Column<bool>(type: "boolean", nullable: false),
                    ApproveStatus = table.Column<int>(type: "integer", nullable: false),
                    ApprovedCompleteThePassport = table.Column<bool>(type: "boolean", nullable: false),
                    BirthPlace = table.Column<string>(type: "text", nullable: true),
                    Certificates = table.Column<string>(type: "text", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    DurationType = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    FirstApproval = table.Column<bool>(type: "boolean", nullable: false),
                    Genders = table.Column<int>(type: "integer", nullable: false),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false),
                    IdNo = table.Column<string>(type: "text", nullable: true),
                    MartialArts = table.Column<string>(type: "text", nullable: true),
                    MedicalApproval = table.Column<bool>(type: "boolean", nullable: false),
                    MedicalPending = table.Column<bool>(type: "boolean", nullable: false),
                    MoveToBookingApprovel = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ParticipationPeriod = table.Column<int>(type: "integer", nullable: true),
                    PassportDocument = table.Column<string>(type: "text", nullable: true),
                    PassportUploadToken = table.Column<string>(type: "text", nullable: true),
                    PassportUploadTokenExpiry = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Photo = table.Column<string>(type: "text", nullable: true),
                    SecurityApproval = table.Column<bool>(type: "boolean", nullable: false),
                    SendAtAccreditation = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SendCompleteThePassportPhotoDataEmailAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SendEmail = table.Column<bool>(type: "boolean", nullable: false),
                    SendEmailAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SendEmailMedical = table.Column<bool>(type: "boolean", nullable: false),
                    SendEmailMedicalAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SendFirstApprovalBooking = table.Column<bool>(type: "boolean", nullable: false),
                    SendFirstApprovalBookingAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SendToAccreditation = table.Column<bool>(type: "boolean", nullable: false),
                    SentBookingCount = table.Column<int>(type: "integer", nullable: false),
                    SentCompletePassportDocumentCount = table.Column<int>(type: "integer", nullable: false),
                    SentCompleteThePassportPhotoDataEmail = table.Column<bool>(type: "boolean", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: true),
                    TokenExpiry = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VideoUrl = table.Column<string>(type: "text", nullable: true),
                    Weight = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registration_Nationality_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SNSSubscription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationUserId = table.Column<string>(type: "text", nullable: false),
                    SubscriptionArn = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SNSSubscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SNSSubscription_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tournament",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Capacity = table.Column<string>(type: "text", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    EnName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Enable = table.Column<bool>(type: "boolean", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TournamentSteps = table.Column<int>(type: "integer", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournament", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserNotification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ArMessage = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ArTitle = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    EnMessage = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    EnTitle = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false),
                    Seen = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNotification_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeightRange",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Color = table.Column<string>(type: "text", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    From = table.Column<string>(type: "text", nullable: false),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false),
                    To = table.Column<string>(type: "text", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightRange", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlbumMedias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AboutUsRelatedImagesId = table.Column<int>(type: "integer", nullable: true),
                    AlbumId = table.Column<int>(type: "integer", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false),
                    FileLink = table.Column<string>(type: "text", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false),
                    MediaType = table.Column<int>(type: "integer", nullable: false),
                    Picture = table.Column<string>(type: "text", nullable: true),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    YouTubeLink = table.Column<string>(type: "text", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Calendar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TournamentId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    EnableCapacityForSlots = table.Column<bool>(type: "boolean", nullable: false),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false),
                    NextAvailableDays = table.Column<int>(type: "integer", nullable: false),
                    TransactionTime = table.Column<int>(type: "integer", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calendar_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TournamentId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CartStatus = table.Column<int>(type: "integer", nullable: false),
                    CartType = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    EventId = table.Column<int>(type: "integer", nullable: true),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: false),
                    PaymentMethod = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Sessions = table.Column<int>(type: "integer", nullable: true),
                    SubEventId = table.Column<int>(type: "integer", nullable: true),
                    SubTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    Tax = table.Column<decimal>(type: "numeric", nullable: false),
                    TaxPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Time = table.Column<TimeSpan>(type: "interval", nullable: true),
                    Total = table.Column<decimal>(type: "numeric", nullable: false),
                    TrainerId = table.Column<int>(type: "integer", nullable: true),
                    TrainerPackageId = table.Column<int>(type: "integer", nullable: true),
                    TrainerSession = table.Column<int>(type: "integer", nullable: true),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cart_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserBooking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RegistrationId = table.Column<int>(type: "integer", nullable: false),
                    TournamentId = table.Column<int>(type: "integer", nullable: false),
                    WeightRangeId = table.Column<int>(type: "integer", nullable: false),
                    BookedType = table.Column<int>(type: "integer", nullable: false),
                    Canceled = table.Column<bool>(type: "boolean", nullable: false),
                    CategoryType = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false),
                    Time = table.Column<TimeSpan>(type: "interval", nullable: true),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBooking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBooking_Registration_RegistrationId",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserBooking_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserBooking_WeightRange_WeightRangeId",
                        column: x => x.WeightRangeId,
                        principalTable: "WeightRange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeightRangeWithDay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TournamentId = table.Column<int>(type: "integer", nullable: false),
                    WeightRangeId = table.Column<int>(type: "integer", nullable: false),
                    CategoryType = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Day = table.Column<int>(type: "integer", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightRangeWithDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeightRangeWithDay_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeightRangeWithDay_WeightRange_WeightRangeId",
                        column: x => x.WeightRangeId,
                        principalTable: "WeightRange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CalendarId = table.Column<int>(type: "integer", nullable: false),
                    AllDates = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    FridayAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    FridayAnotherAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    FridayAnotherCapacity = table.Column<int>(type: "integer", nullable: false),
                    FridayAnotherFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FridayAnotherMatchTime = table.Column<int>(type: "integer", nullable: true),
                    FridayAnotherPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    FridayAnotherShift = table.Column<bool>(type: "boolean", nullable: false),
                    FridayAnotherTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FridayAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    FridayCapacity = table.Column<int>(type: "integer", nullable: false),
                    FridayFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FridayMatchTime = table.Column<int>(type: "integer", nullable: true),
                    FridayPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    FridayTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false),
                    MondayAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    MondayAnotherAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    MondayAnotherCapacity = table.Column<int>(type: "integer", nullable: false),
                    MondayAnotherFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MondayAnotherMatchTime = table.Column<int>(type: "integer", nullable: true),
                    MondayAnotherPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    MondayAnotherShift = table.Column<bool>(type: "boolean", nullable: false),
                    MondayAnotherTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MondayAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    MondayCapacity = table.Column<int>(type: "integer", nullable: false),
                    MondayFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MondayMatchTime = table.Column<int>(type: "integer", nullable: true),
                    MondayPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    MondayTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SaturdayAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    SaturdayAnotherAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    SaturdayAnotherCapacity = table.Column<int>(type: "integer", nullable: false),
                    SaturdayAnotherFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SaturdayAnotherMatchTime = table.Column<int>(type: "integer", nullable: true),
                    SaturdayAnotherPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    SaturdayAnotherShift = table.Column<bool>(type: "boolean", nullable: false),
                    SaturdayAnotherTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SaturdayAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    SaturdayCapacity = table.Column<int>(type: "integer", nullable: false),
                    SaturdayFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SaturdayMatchTime = table.Column<int>(type: "integer", nullable: true),
                    SaturdayPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    SaturdayTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SundayAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    SundayAnotherAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    SundayAnotherCapacity = table.Column<int>(type: "integer", nullable: false),
                    SundayAnotherFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SundayAnotherMatchTime = table.Column<int>(type: "integer", nullable: true),
                    SundayAnotherPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    SundayAnotherShift = table.Column<bool>(type: "boolean", nullable: false),
                    SundayAnotherTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SundayAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    SundayCapacity = table.Column<int>(type: "integer", nullable: false),
                    SundayFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SundayMatchTime = table.Column<int>(type: "integer", nullable: true),
                    SundayPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    SundayTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ThursdayAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    ThursdayAnotherAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    ThursdayAnotherCapacity = table.Column<int>(type: "integer", nullable: false),
                    ThursdayAnotherFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ThursdayAnotherMatchTime = table.Column<int>(type: "integer", nullable: true),
                    ThursdayAnotherPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    ThursdayAnotherShift = table.Column<bool>(type: "boolean", nullable: false),
                    ThursdayAnotherTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ThursdayAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    ThursdayCapacity = table.Column<int>(type: "integer", nullable: false),
                    ThursdayFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ThursdayMatchTime = table.Column<int>(type: "integer", nullable: true),
                    ThursdayPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    ThursdayTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TuesdayAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    TuesdayAnotherAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    TuesdayAnotherCapacity = table.Column<int>(type: "integer", nullable: false),
                    TuesdayAnotherFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TuesdayAnotherMatchTime = table.Column<int>(type: "integer", nullable: true),
                    TuesdayAnotherPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    TuesdayAnotherShift = table.Column<bool>(type: "boolean", nullable: false),
                    TuesdayAnotherTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TuesdayAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    TuesdayCapacity = table.Column<int>(type: "integer", nullable: false),
                    TuesdayFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TuesdayMatchTime = table.Column<int>(type: "integer", nullable: true),
                    TuesdayPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    TuesdayTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WednesdayAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    WednesdayAnotherAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    WednesdayAnotherCapacity = table.Column<int>(type: "integer", nullable: false),
                    WednesdayAnotherFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    WednesdayAnotherMatchTime = table.Column<int>(type: "integer", nullable: true),
                    WednesdayAnotherPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    WednesdayAnotherShift = table.Column<bool>(type: "boolean", nullable: false),
                    WednesdayAnotherTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    WednesdayAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    WednesdayCapacity = table.Column<int>(type: "integer", nullable: false),
                    WednesdayFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    WednesdayMatchTime = table.Column<int>(type: "integer", nullable: true),
                    WednesdayPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    WednesdayTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule_Calendar_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookingTicket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserBookingId = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    BookedSessionId = table.Column<int>(type: "integer", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false),
                    Player = table.Column<string>(type: "text", nullable: true),
                    Scanned = table.Column<bool>(type: "boolean", nullable: false),
                    TicketNumber = table.Column<string>(type: "text", nullable: false),
                    Time = table.Column<TimeSpan>(type: "interval", nullable: true),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingTicket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingTicket_UserBooking_UserBookingId",
                        column: x => x.UserBookingId,
                        principalTable: "UserBooking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TournamentId = table.Column<int>(type: "integer", nullable: false),
                    UserBookingId = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CartId = table.Column<int>(type: "integer", nullable: false),
                    CartType = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    EventId = table.Column<int>(type: "integer", nullable: true),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false),
                    IpAddress = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IpCity = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IpCountry = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IpLocation = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Language = table.Column<string>(type: "text", nullable: true),
                    OrderCanceled = table.Column<bool>(type: "boolean", nullable: false),
                    OrderRefund = table.Column<bool>(type: "boolean", nullable: false),
                    PackageName = table.Column<string>(type: "text", nullable: true),
                    PaymentMethod = table.Column<int>(type: "integer", nullable: false),
                    PaymentNote = table.Column<string>(type: "text", nullable: true),
                    PaymentSuccess = table.Column<bool>(type: "boolean", nullable: false),
                    RefundAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    Sessions = table.Column<int>(type: "integer", nullable: true),
                    SubEventId = table.Column<int>(type: "integer", nullable: true),
                    SubTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    Tax = table.Column<decimal>(type: "numeric", nullable: false),
                    Time = table.Column<TimeSpan>(type: "interval", nullable: true),
                    Total = table.Column<decimal>(type: "numeric", nullable: false),
                    TournamentName = table.Column<string>(type: "text", nullable: true),
                    TournamentType = table.Column<string>(type: "text", nullable: true),
                    TrainerId = table.Column<int>(type: "integer", nullable: true),
                    TrainerName = table.Column<string>(type: "text", nullable: true),
                    TrainerPackageId = table.Column<int>(type: "integer", nullable: true),
                    TransactionId = table.Column<string>(type: "text", nullable: true),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Tournament_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournament",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_UserBooking_UserBookingId",
                        column: x => x.UserBookingId,
                        principalTable: "UserBooking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeightRangeWithDayWithSlot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WeightRangeWithDayId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false),
                    Time = table.Column<TimeSpan>(type: "interval", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightRangeWithDayWithSlot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeightRangeWithDayWithSlot_WeightRangeWithDay_WeightRangeWi~",
                        column: x => x.WeightRangeWithDayId,
                        principalTable: "WeightRangeWithDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ScheduleId = table.Column<int>(type: "integer", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    FridayAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    FridayAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    FridayCapacity = table.Column<int>(type: "integer", nullable: false),
                    FridayFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FridayMatchTime = table.Column<int>(type: "integer", nullable: true),
                    FridayPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    FridayTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false),
                    MondayAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    MondayAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    MondayCapacity = table.Column<int>(type: "integer", nullable: false),
                    MondayFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MondayMatchTime = table.Column<int>(type: "integer", nullable: true),
                    MondayPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    MondayTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SaturdayAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    SaturdayAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    SaturdayCapacity = table.Column<int>(type: "integer", nullable: false),
                    SaturdayFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SaturdayMatchTime = table.Column<int>(type: "integer", nullable: true),
                    SaturdayPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    SaturdayTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SundayAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    SundayAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    SundayCapacity = table.Column<int>(type: "integer", nullable: false),
                    SundayFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SundayMatchTime = table.Column<int>(type: "integer", nullable: true),
                    SundayPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    SundayTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ThursdayAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    ThursdayAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    ThursdayCapacity = table.Column<int>(type: "integer", nullable: false),
                    ThursdayFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ThursdayMatchTime = table.Column<int>(type: "integer", nullable: true),
                    ThursdayPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    ThursdayTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TuesdayAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    TuesdayAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    TuesdayCapacity = table.Column<int>(type: "integer", nullable: false),
                    TuesdayFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TuesdayMatchTime = table.Column<int>(type: "integer", nullable: true),
                    TuesdayPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    TuesdayTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WednesdayAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    WednesdayAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    WednesdayCapacity = table.Column<int>(type: "integer", nullable: false),
                    WednesdayFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    WednesdayMatchTime = table.Column<int>(type: "integer", nullable: true),
                    WednesdayPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    WednesdayTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shift_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RefundOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false),
                    IsPartial = table.Column<bool>(type: "boolean", nullable: false),
                    RefundReason = table.Column<string>(type: "text", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefundOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefundOrder_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RegistrationId",
                table: "AspNetUsers",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumMedias_AboutUsRelatedImagesId",
                table: "AlbumMedias",
                column: "AboutUsRelatedImagesId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumMedias_AlbumId",
                table: "AlbumMedias",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingTicket_UserBookingId",
                table: "BookingTicket",
                column: "UserBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendar_TournamentId",
                table: "Calendar",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_TournamentId",
                table: "Cart",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId",
                table: "Cart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_TournamentId",
                table: "Order",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserBookingId",
                table: "Order",
                column: "UserBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefundOrder_OrderId",
                table: "RefundOrder",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Registration_NationalityId",
                table: "Registration",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_CalendarId",
                table: "Schedule",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_Shift_ScheduleId",
                table: "Shift",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_SNSSubscription_ApplicationUserId",
                table: "SNSSubscription",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBooking_RegistrationId",
                table: "UserBooking",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBooking_TournamentId",
                table: "UserBooking",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBooking_WeightRangeId",
                table: "UserBooking",
                column: "WeightRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotification_UserId",
                table: "UserNotification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WeightRangeWithDay_TournamentId",
                table: "WeightRangeWithDay",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_WeightRangeWithDay_WeightRangeId",
                table: "WeightRangeWithDay",
                column: "WeightRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_WeightRangeWithDayWithSlot_WeightRangeWithDayId",
                table: "WeightRangeWithDayWithSlot",
                column: "WeightRangeWithDayId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Registration_RegistrationId",
                table: "AspNetUsers",
                column: "RegistrationId",
                principalTable: "Registration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
