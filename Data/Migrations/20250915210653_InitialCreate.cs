using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    EnName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Desires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    EnName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desires", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nationality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ArName = table.Column<string>(type: "text", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationality", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tournament",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    EnName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Capacity = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TournamentSteps = table.Column<int>(type: "integer", nullable: false),
                    Enable = table.Column<bool>(type: "boolean", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournament", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeightRange",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    From = table.Column<string>(type: "text", nullable: false),
                    To = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightRange", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CountryId = table.Column<int>(type: "integer", nullable: true),
                    ArName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    EnName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NationalityId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IdNo = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    BirthPlace = table.Column<string>(type: "text", nullable: true),
                    MartialArts = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: true),
                    Weight = table.Column<double>(type: "double precision", nullable: true),
                    ParticipationPeriod = table.Column<int>(type: "integer", nullable: true),
                    DurationType = table.Column<string>(type: "text", nullable: true),
                    Photo = table.Column<string>(type: "text", nullable: true),
                    Certificates = table.Column<string>(type: "text", nullable: true),
                    VideoUrl = table.Column<string>(type: "text", nullable: true),
                    ApproveStatus = table.Column<int>(type: "integer", nullable: false),
                    SendToAccreditation = table.Column<bool>(type: "boolean", nullable: false),
                    SendAtAccreditation = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SendEmail = table.Column<bool>(type: "boolean", nullable: false),
                    SendEmailAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Genders = table.Column<int>(type: "integer", nullable: false),
                    SecurityApproval = table.Column<bool>(type: "boolean", nullable: false),
                    SendEmailMedical = table.Column<bool>(type: "boolean", nullable: false),
                    SendEmailMedicalAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MedicalPending = table.Column<bool>(type: "boolean", nullable: false),
                    MedicalApproval = table.Column<bool>(type: "boolean", nullable: false),
                    FirstApproval = table.Column<bool>(type: "boolean", nullable: false),
                    SendFirstApprovalBooking = table.Column<bool>(type: "boolean", nullable: false),
                    ApproveFirstApprovalBooking = table.Column<bool>(type: "boolean", nullable: false),
                    SendFirstApprovalBookingAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Token = table.Column<string>(type: "text", nullable: true),
                    TokenExpiry = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SentBookingCount = table.Column<int>(type: "integer", nullable: false),
                    PassportUploadToken = table.Column<string>(type: "text", nullable: true),
                    PassportUploadTokenExpiry = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PassportDocument = table.Column<string>(type: "text", nullable: true),
                    SentCompleteThePassportPhotoDataEmail = table.Column<bool>(type: "boolean", nullable: false),
                    ApprovedCompleteThePassport = table.Column<bool>(type: "boolean", nullable: false),
                    SendCompleteThePassportPhotoDataEmailAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SentCompletePassportDocumentCount = table.Column<int>(type: "integer", nullable: false),
                    MoveToBookingApprovel = table.Column<bool>(type: "boolean", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false)
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
                name: "Calendar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TournamentId = table.Column<int>(type: "integer", nullable: false),
                    NextAvailableDays = table.Column<int>(type: "integer", nullable: false),
                    TransactionTime = table.Column<int>(type: "integer", nullable: false),
                    EnableCapacityForSlots = table.Column<bool>(type: "boolean", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false)
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
                name: "WeightRangeWithDay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WeightRangeId = table.Column<int>(type: "integer", nullable: false),
                    TournamentId = table.Column<int>(type: "integer", nullable: false),
                    Day = table.Column<int>(type: "integer", nullable: false),
                    CategoryType = table.Column<int>(type: "integer", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false)
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    CountryCode = table.Column<string>(type: "text", nullable: true),
                    Mobile = table.Column<string>(type: "text", nullable: false),
                    Picture = table.Column<string>(type: "text", nullable: true),
                    UserType = table.Column<int>(type: "integer", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    NationalityId = table.Column<string>(type: "text", nullable: true),
                    RegistrationId = table.Column<int>(type: "integer", nullable: true),
                    RefreshTokenExpiryUTC = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    MobileAppId = table.Column<string>(type: "text", nullable: true),
                    Language = table.Column<string>(type: "text", nullable: true),
                    LoginDevice = table.Column<string>(type: "text", nullable: true),
                    LoginIPAddress = table.Column<string>(type: "text", nullable: true),
                    LoginIpCity = table.Column<string>(type: "text", nullable: true),
                    LoginIpCountry = table.Column<string>(type: "text", nullable: true),
                    LoginLocation = table.Column<string>(type: "text", nullable: true),
                    RegisterDevice = table.Column<string>(type: "text", nullable: true),
                    RegisterIPAddress = table.Column<string>(type: "text", nullable: true),
                    RegisterIpCity = table.Column<string>(type: "text", nullable: true),
                    RegisterIpCountry = table.Column<string>(type: "text", nullable: true),
                    RegisterLocation = table.Column<string>(type: "text", nullable: true),
                    IsMobileDevice = table.Column<bool>(type: "boolean", nullable: false),
                    Headers = table.Column<string>(type: "text", nullable: true),
                    EndpointArn = table.Column<string>(type: "text", nullable: true),
                    HasTopic = table.Column<bool>(type: "boolean", nullable: false),
                    EnableNotification = table.Column<bool>(type: "boolean", nullable: false),
                    TopicArn = table.Column<string>(type: "text", nullable: true),
                    BirthDay = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Gender = table.Column<int>(type: "integer", nullable: true),
                    IsOTPEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    DeviceType = table.Column<int>(type: "integer", nullable: false),
                    Provider = table.Column<int>(type: "integer", nullable: false),
                    LevelId = table.Column<int>(type: "integer", nullable: true),
                    IsSubscriber = table.Column<bool>(type: "boolean", nullable: false),
                    SubscriptionTill = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AppleClientSecret = table.Column<string>(type: "text", nullable: true),
                    OriginalTransactionId = table.Column<string>(type: "text", nullable: true),
                    DeletionRequestURL = table.Column<string>(type: "text", nullable: true),
                    DeletionConfirmCode = table.Column<string>(type: "text", nullable: true),
                    AppleAccessToken = table.Column<string>(type: "text", nullable: true),
                    AppleRefreshToken = table.Column<string>(type: "text", nullable: true),
                    AppleTokenType = table.Column<string>(type: "text", nullable: true),
                    GoogleAccessToken = table.Column<string>(type: "text", nullable: true),
                    FacebookAccessToken = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: true),
                    Weight = table.Column<double>(type: "double precision", nullable: true),
                    TotalScorePoint = table.Column<double>(type: "double precision", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Registration_RegistrationId",
                        column: x => x.RegistrationId,
                        principalTable: "Registration",
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
                    CategoryType = table.Column<int>(type: "integer", nullable: false),
                    WeightRangeId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Time = table.Column<TimeSpan>(type: "interval", nullable: true),
                    Canceled = table.Column<bool>(type: "boolean", nullable: false),
                    BookedType = table.Column<int>(type: "integer", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false)
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
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CalendarId = table.Column<int>(type: "integer", nullable: false),
                    AllDates = table.Column<bool>(type: "boolean", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SundayAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    SundayFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SundayTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SundayPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    SundayMatchTime = table.Column<int>(type: "integer", nullable: true),
                    SundayAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    SundayAnotherFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SundayAnotherTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SundayAnotherShift = table.Column<bool>(type: "boolean", nullable: false),
                    SundayAnotherPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    SundayAnotherMatchTime = table.Column<int>(type: "integer", nullable: true),
                    SundayAnotherAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    SundayAnotherCapacity = table.Column<int>(type: "integer", nullable: false),
                    SundayCapacity = table.Column<int>(type: "integer", nullable: false),
                    MondayAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    MondayFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MondayTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MondayPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    MondayAnotherFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MondayAnotherTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MondayAnotherShift = table.Column<bool>(type: "boolean", nullable: false),
                    MondayAnotherPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    MondayMatchTime = table.Column<int>(type: "integer", nullable: true),
                    MondayAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    MondayAnotherMatchTime = table.Column<int>(type: "integer", nullable: true),
                    MondayAnotherAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    MondayAnotherCapacity = table.Column<int>(type: "integer", nullable: false),
                    MondayCapacity = table.Column<int>(type: "integer", nullable: false),
                    TuesdayAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    TuesdayFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TuesdayTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TuesdayPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    TuesdayAnotherFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TuesdayAnotherTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TuesdayAnotherShift = table.Column<bool>(type: "boolean", nullable: false),
                    TuesdayAnotherPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    TuesdayMatchTime = table.Column<int>(type: "integer", nullable: true),
                    TuesdayAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    TuesdayAnotherMatchTime = table.Column<int>(type: "integer", nullable: true),
                    TuesdayAnotherAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    TuesdayAnotherCapacity = table.Column<int>(type: "integer", nullable: false),
                    TuesdayCapacity = table.Column<int>(type: "integer", nullable: false),
                    WednesdayAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    WednesdayFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    WednesdayTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    WednesdayPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    WednesdayAnotherFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    WednesdayAnotherTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    WednesdayAnotherShift = table.Column<bool>(type: "boolean", nullable: false),
                    WednesdayAnotherPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    WednesdayMatchTime = table.Column<int>(type: "integer", nullable: true),
                    WednesdayAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    WednesdayAnotherMatchTime = table.Column<int>(type: "integer", nullable: true),
                    WednesdayAnotherAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    WednesdayAnotherCapacity = table.Column<int>(type: "integer", nullable: false),
                    WednesdayCapacity = table.Column<int>(type: "integer", nullable: false),
                    ThursdayAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    ThursdayFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ThursdayTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ThursdayPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    ThursdayAnotherFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ThursdayAnotherTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ThursdayAnotherShift = table.Column<bool>(type: "boolean", nullable: false),
                    ThursdayAnotherPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    ThursdayMatchTime = table.Column<int>(type: "integer", nullable: true),
                    ThursdayAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    ThursdayAnotherMatchTime = table.Column<int>(type: "integer", nullable: true),
                    ThursdayAnotherAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    ThursdayAnotherCapacity = table.Column<int>(type: "integer", nullable: false),
                    ThursdayCapacity = table.Column<int>(type: "integer", nullable: false),
                    FridayAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    FridayFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FridayTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FridayPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    FridayAnotherFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FridayAnotherTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FridayAnotherShift = table.Column<bool>(type: "boolean", nullable: false),
                    FridayAnotherPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    FridayMatchTime = table.Column<int>(type: "integer", nullable: true),
                    FridayAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    FridayAnotherMatchTime = table.Column<int>(type: "integer", nullable: true),
                    FridayAnotherAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    FridayAnotherCapacity = table.Column<int>(type: "integer", nullable: false),
                    FridayCapacity = table.Column<int>(type: "integer", nullable: false),
                    SaturdayAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    SaturdayFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SaturdayTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SaturdayPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    SaturdayAnotherFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SaturdayAnotherTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SaturdayAnotherShift = table.Column<bool>(type: "boolean", nullable: false),
                    SaturdayAnotherPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    SaturdayMatchTime = table.Column<int>(type: "integer", nullable: true),
                    SaturdayAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    SaturdayAnotherMatchTime = table.Column<int>(type: "integer", nullable: true),
                    SaturdayAnotherAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    SaturdayAnotherCapacity = table.Column<int>(type: "integer", nullable: false),
                    SaturdayCapacity = table.Column<int>(type: "integer", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false)
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
                name: "WeightRangeWithDayWithSlot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WeightRangeWithDayId = table.Column<int>(type: "integer", nullable: false),
                    Time = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false)
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "UserNotification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArTitle = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    EnTitle = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ArMessage = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    EnMessage = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Seen = table.Column<bool>(type: "boolean", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false)
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
                name: "BookingTicket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookedSessionId = table.Column<int>(type: "integer", nullable: true),
                    UserBookingId = table.Column<int>(type: "integer", nullable: false),
                    Player = table.Column<string>(type: "text", nullable: true),
                    TicketNumber = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Time = table.Column<TimeSpan>(type: "interval", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    Scanned = table.Column<bool>(type: "boolean", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false)
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
                name: "Shift",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ScheduleId = table.Column<int>(type: "integer", nullable: false),
                    SundayAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    SundayFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SundayTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SundayMatchTime = table.Column<int>(type: "integer", nullable: true),
                    SundayCapacity = table.Column<int>(type: "integer", nullable: false),
                    SundayAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    SundayPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    MondayAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    MondayFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MondayTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MondayMatchTime = table.Column<int>(type: "integer", nullable: true),
                    MondayCapacity = table.Column<int>(type: "integer", nullable: false),
                    MondayAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    MondayPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    TuesdayAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    TuesdayFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TuesdayTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TuesdayMatchTime = table.Column<int>(type: "integer", nullable: true),
                    TuesdayCapacity = table.Column<int>(type: "integer", nullable: false),
                    TuesdayAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    TuesdayPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    WednesdayAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    WednesdayFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    WednesdayTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    WednesdayMatchTime = table.Column<int>(type: "integer", nullable: true),
                    WednesdayCapacity = table.Column<int>(type: "integer", nullable: false),
                    WednesdayAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    WednesdayPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    ThursdayAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    ThursdayFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ThursdayTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ThursdayMatchTime = table.Column<int>(type: "integer", nullable: true),
                    ThursdayCapacity = table.Column<int>(type: "integer", nullable: false),
                    ThursdayAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    ThursdayPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    FridayAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    FridayFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FridayTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FridayMatchTime = table.Column<int>(type: "integer", nullable: true),
                    FridayCapacity = table.Column<int>(type: "integer", nullable: false),
                    FridayAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    FridayPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    SaturdayAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    SaturdayFrom = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SaturdayTo = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    SaturdayMatchTime = table.Column<int>(type: "integer", nullable: true),
                    SaturdayCapacity = table.Column<int>(type: "integer", nullable: false),
                    SaturdayAfterMidnight = table.Column<bool>(type: "boolean", nullable: false),
                    SaturdayPrice = table.Column<decimal>(type: "numeric", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RegistrationId",
                table: "AspNetUsers",
                column: "RegistrationId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookingTicket_UserBookingId",
                table: "BookingTicket",
                column: "UserBookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendar_TournamentId",
                table: "Calendar",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                table: "City",
                column: "CountryId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BookingTicket");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Desires");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropTable(
                name: "SNSSubscription");

            migrationBuilder.DropTable(
                name: "UserNotification");

            migrationBuilder.DropTable(
                name: "WeightRangeWithDayWithSlot");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "UserBooking");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "WeightRangeWithDay");

            migrationBuilder.DropTable(
                name: "Calendar");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "WeightRange");

            migrationBuilder.DropTable(
                name: "Tournament");

            migrationBuilder.DropTable(
                name: "Nationality");
        }
    }
}
