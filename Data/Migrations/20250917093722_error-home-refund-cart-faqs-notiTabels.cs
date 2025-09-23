using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class errorhomerefundcartfaqsnotiTabels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiClient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    APIType = table.Column<string>(type: "text", nullable: true),
                    Client = table.Column<string>(type: "text", nullable: false),
                    ClientId = table.Column<string>(type: "text", nullable: true),
                    ClientToken = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    FullAccess = table.Column<bool>(type: "boolean", nullable: false),
                    SlidingExpiration = table.Column<bool>(type: "boolean", nullable: false),
                    AccessTokenExpiry = table.Column<int>(type: "integer", nullable: false),
                    RefreshTokenExpiry = table.Column<int>(type: "integer", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiClient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TournamentId = table.Column<int>(type: "integer", nullable: false),
                    TrainerId = table.Column<int>(type: "integer", nullable: true),
                    TrainerPackageId = table.Column<int>(type: "integer", nullable: true),
                    Sessions = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    EventId = table.Column<int>(type: "integer", nullable: true),
                    SubEventId = table.Column<int>(type: "integer", nullable: true),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Time = table.Column<TimeSpan>(type: "interval", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    SubTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric", nullable: false),
                    Tax = table.Column<decimal>(type: "numeric", nullable: false),
                    TaxPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: false),
                    TrainerSession = table.Column<int>(type: "integer", nullable: true),
                    CartType = table.Column<int>(type: "integer", nullable: false),
                    PaymentMethod = table.Column<int>(type: "integer", nullable: false),
                    CartStatus = table.Column<int>(type: "integer", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false)
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
                name: "Configuration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    EnName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ArMetaDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    EnMetaDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ArFooterBrief = table.Column<string>(type: "text", nullable: true),
                    EnFooterBrief = table.Column<string>(type: "text", nullable: true),
                    ArKeywords = table.Column<string>(type: "text", nullable: true),
                    EnKeywords = table.Column<string>(type: "text", nullable: true),
                    Android = table.Column<string>(type: "text", nullable: true),
                    IOS = table.Column<string>(type: "text", nullable: true),
                    Facebook = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Twitter = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Youtube = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    LinkedIn = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Instagram = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Tiktok = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Snapchat = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    DefaultEmail = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    DefaultEmailName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    DefaultNotificationEmails = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    SocialPicture = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    WebsiteURL = table.Column<string>(type: "text", nullable: true),
                    EmailSender = table.Column<string>(type: "text", nullable: true),
                    PasswordEmailSender = table.Column<string>(type: "text", nullable: true),
                    Port = table.Column<int>(type: "integer", nullable: true),
                    UseSSL = table.Column<bool>(type: "boolean", nullable: false),
                    Host = table.Column<string>(type: "text", nullable: true),
                    GoogleAnalytics = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    GoogleAnalyticsEmail = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    SEOScripts = table.Column<string>(type: "text", nullable: true),
                    EnableSubscription = table.Column<bool>(type: "boolean", nullable: false),
                    EnableOTP = table.Column<bool>(type: "boolean", nullable: false),
                    Tax = table.Column<int>(type: "integer", nullable: false),
                    CleanCartAfter = table.Column<int>(type: "integer", nullable: false),
                    CleanOrderAfter = table.Column<int>(type: "integer", nullable: false),
                    PointsPerOrder = table.Column<int>(type: "integer", nullable: false),
                    PayTabs = table.Column<bool>(type: "boolean", nullable: false),
                    ApplePay = table.Column<bool>(type: "boolean", nullable: false),
                    Mada = table.Column<bool>(type: "boolean", nullable: false),
                    STCPay = table.Column<bool>(type: "boolean", nullable: false),
                    AnyFailedPaymentReturnToCart = table.Column<bool>(type: "boolean", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErrorMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    EnDescription = table.Column<string>(type: "text", nullable: false),
                    ArDescription = table.Column<string>(type: "text", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FAQS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    EnName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ArDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    EnDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false)
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
                    ArName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    EnName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ArDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    EnDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ArPicture = table.Column<string>(type: "text", nullable: false),
                    EnPicture = table.Column<string>(type: "text", nullable: false),
                    Link = table.Column<string>(type: "text", nullable: true),
                    LinkTarget = table.Column<int>(type: "integer", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeBanners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApplicationUserId = table.Column<string>(type: "character varying(450)", maxLength: 450, nullable: false),
                    IpAddress = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Action = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Table = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Details = table.Column<string>(type: "text", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Log_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    EnName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ArContent = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    EnContent = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CartId = table.Column<int>(type: "integer", nullable: false),
                    TrainerId = table.Column<int>(type: "integer", nullable: true),
                    TrainerPackageId = table.Column<int>(type: "integer", nullable: true),
                    Sessions = table.Column<int>(type: "integer", nullable: true),
                    TournamentId = table.Column<int>(type: "integer", nullable: false),
                    EventId = table.Column<int>(type: "integer", nullable: true),
                    SubEventId = table.Column<int>(type: "integer", nullable: true),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    TournamentName = table.Column<string>(type: "text", nullable: true),
                    TournamentType = table.Column<string>(type: "text", nullable: true),
                    PackageName = table.Column<string>(type: "text", nullable: true),
                    TrainerName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Time = table.Column<TimeSpan>(type: "interval", nullable: true),
                    Tax = table.Column<decimal>(type: "numeric", nullable: false),
                    SubTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentSuccess = table.Column<bool>(type: "boolean", nullable: false),
                    PaymentNote = table.Column<string>(type: "text", nullable: true),
                    RefundAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    Discount = table.Column<decimal>(type: "numeric", nullable: false),
                    IpAddress = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IpCountry = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IpCity = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IpLocation = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    TransactionId = table.Column<string>(type: "text", nullable: true),
                    CartType = table.Column<int>(type: "integer", nullable: false),
                    PaymentMethod = table.Column<int>(type: "integer", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: true),
                    OrderCanceled = table.Column<bool>(type: "boolean", nullable: false),
                    OrderRefund = table.Column<bool>(type: "boolean", nullable: false),
                    UserBookingId = table.Column<int>(type: "integer", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false)
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
                name: "RefundOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    RefundReason = table.Column<string>(type: "text", nullable: false),
                    IsPartial = table.Column<bool>(type: "boolean", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: true),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false)
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
                name: "IX_Cart_TournamentId",
                table: "Cart",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId",
                table: "Cart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Log_ApplicationUserId",
                table: "Log",
                column: "ApplicationUserId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiClient");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Configuration");

            migrationBuilder.DropTable(
                name: "ErrorMessages");

            migrationBuilder.DropTable(
                name: "FAQS");

            migrationBuilder.DropTable(
                name: "HomeBanners");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "RefundOrder");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
