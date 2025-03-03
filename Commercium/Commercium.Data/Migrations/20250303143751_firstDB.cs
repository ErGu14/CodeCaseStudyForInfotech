using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Commercium.Data.Migrations
{
    /// <inheritdoc />
    public partial class firstDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "BusinessProfiles",
                columns: table => new
                {
                    BusinessProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClickCount = table.Column<int>(type: "int", nullable: false),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    NotificationId = table.Column<int>(type: "int", nullable: true),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessProfiles", x => x.BusinessProfileId);
                    table.ForeignKey(
                        name: "FK_BusinessProfiles_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    ConversationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReceiverId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastMessageDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.ConversationId);
                    table.ForeignKey(
                        name: "FK_Conversations_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Conversations_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReceiverId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConversationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SearchHistories",
                columns: table => new
                {
                    SearchHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SearchQuery = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SearchDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchHistories", x => x.SearchHistoryId);
                    table.ForeignKey(
                        name: "FK_SearchHistories_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFollows",
                columns: table => new
                {
                    FollowerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FollowedId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFollows", x => new { x.FollowerId, x.FollowedId });
                    table.ForeignKey(
                        name: "FK_UserFollows_AspNetUsers_FollowedId",
                        column: x => x.FollowedId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserFollows_AspNetUsers_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserProfileCustomizations",
                columns: table => new
                {
                    UserProfileCustomizationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomBackgroundImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileCustomizations", x => x.UserProfileCustomizationId);
                    table.ForeignKey(
                        name: "FK_UserProfileCustomizations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessProfileCustomizations",
                columns: table => new
                {
                    BusinessProfileCustomizationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomBackgroundImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessProfileCustomizations", x => x.BusinessProfileCustomizationId);
                    table.ForeignKey(
                        name: "FK_BusinessProfileCustomizations_BusinessProfiles_BusinessProfileId",
                        column: x => x.BusinessProfileId,
                        principalTable: "BusinessProfiles",
                        principalColumn: "BusinessProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessProfileTags",
                columns: table => new
                {
                    BusinessProfileId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessProfileTags", x => new { x.BusinessProfileId, x.TagId });
                    table.ForeignKey(
                        name: "FK_BusinessProfileTags_BusinessProfiles_BusinessProfileId",
                        column: x => x.BusinessProfileId,
                        principalTable: "BusinessProfiles",
                        principalColumn: "BusinessProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessProfileTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    CampaignId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BusinessProfileId = table.Column<int>(type: "int", nullable: false),
                    ClickCount = table.Column<int>(type: "int", nullable: false),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.CampaignId);
                    table.ForeignKey(
                        name: "FK_Campaigns_BusinessProfiles_BusinessProfileId",
                        column: x => x.BusinessProfileId,
                        principalTable: "BusinessProfiles",
                        principalColumn: "BusinessProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConversationMessage",
                columns: table => new
                {
                    ConversationsConversationId = table.Column<int>(type: "int", nullable: false),
                    MessagesMessageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversationMessage", x => new { x.ConversationsConversationId, x.MessagesMessageId });
                    table.ForeignKey(
                        name: "FK_ConversationMessage_Conversations_ConversationsConversationId",
                        column: x => x.ConversationsConversationId,
                        principalTable: "Conversations",
                        principalColumn: "ConversationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConversationMessage_Messages_MessagesMessageId",
                        column: x => x.MessagesMessageId,
                        principalTable: "Messages",
                        principalColumn: "MessageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityLogs",
                columns: table => new
                {
                    ActivityLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityType = table.Column<int>(type: "int", nullable: false),
                    ActivityDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: false),
                    EntityType = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLogs", x => x.ActivityLogId);
                    table.ForeignKey(
                        name: "FK_ActivityLogs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    FavoriteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.FavoriteId);
                    table.ForeignKey(
                        name: "FK_Favorites_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClickCount = table.Column<int>(type: "int", nullable: false),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BusinessProfileId = table.Column<int>(type: "int", nullable: false),
                    FavoriteId = table.Column<int>(type: "int", nullable: true),
                    FavoriteId1 = table.Column<int>(type: "int", nullable: true),
                    CampaignId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_BusinessProfiles_BusinessProfileId",
                        column: x => x.BusinessProfileId,
                        principalTable: "BusinessProfiles",
                        principalColumn: "BusinessProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "CampaignId");
                    table.ForeignKey(
                        name: "FK_Products_Favorites_FavoriteId1",
                        column: x => x.FavoriteId1,
                        principalTable: "Favorites",
                        principalColumn: "FavoriteId");
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClickCount = table.Column<int>(type: "int", nullable: false),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    FavoriteId = table.Column<int>(type: "int", nullable: true),
                    FavoriteId1 = table.Column<int>(type: "int", nullable: true),
                    BusinessProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_Services_BusinessProfiles_BusinessProfileId",
                        column: x => x.BusinessProfileId,
                        principalTable: "BusinessProfiles",
                        principalColumn: "BusinessProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Services_Favorites_FavoriteId1",
                        column: x => x.FavoriteId1,
                        principalTable: "Favorites",
                        principalColumn: "FavoriteId");
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTags",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTags", x => new { x.ProductId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ProductTags_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NotificationType = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: true),
                    BusinessProfileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifications_BusinessProfiles_BusinessProfileId",
                        column: x => x.BusinessProfileId,
                        principalTable: "BusinessProfiles",
                        principalColumn: "BusinessProfileId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_Notifications_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_Reviews_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId");
                });

            migrationBuilder.CreateTable(
                name: "SearchResults",
                columns: table => new
                {
                    SearchResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SearchQuery = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: true),
                    BusinessProfileId = table.Column<int>(type: "int", nullable: false),
                    SearchDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchResults", x => x.SearchResultId);
                    table.ForeignKey(
                        name: "FK_SearchResults_BusinessProfiles_BusinessProfileId",
                        column: x => x.BusinessProfileId,
                        principalTable: "BusinessProfiles",
                        principalColumn: "BusinessProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SearchResults_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_SearchResults_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId");
                });

            migrationBuilder.CreateTable(
                name: "ServiceTags",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTags", x => new { x.ServiceId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ServiceTags_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e01f984-8836-4e4b-902a-d60fa23b1833", null, "Standart kullanıcılar için bir rol.", "User", "USER" },
                    { "ab5cd8c9-8f8e-48b2-83c1-b96e5f98413a", null, "İşletme sahipleri için bir rol.", "BusinessOwner", "BUSINESSOWNER" },
                    { "d4b8c6bc-0182-4c29-8c88-8e68bc8a7b2b", null, "Satıcılar için bir rol.", "Seller", "SELLER" },
                    { "fa5c0d5b-8b9b-4377-a2ba-d5765a8ed25c", null, "Yönetici rolü, tüm yetkilere sahip.", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b", 0, "0c841f7e-6380-40da-99c2-290ab4d51ada", new DateTime(1988, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmetyilmaz41@outlook.com", true, "Ahmet", 5, "Yıldız", false, null, "", "AHMETYILMAZ41@OUTLOOK.COM", null, "AQAAAAIAAYagAAAAEFwBGfLoDAKmlbCijLYhoOC3g9siyq3edOrHw2iV+mvHciNXp/WZoljys6jOJbg6vQ==", "5346530901", false, 0, "1c06adda-d363-4ffe-be83-252715041f0f", 0, false, null },
                    { "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3", 0, "5e0859ef-f42d-4f8d-ad6c-3a437d75c813", new DateTime(1985, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "ayseyilmaz@admin.com", true, "Ayşe", 2, "Yılmaz", false, null, "Fidan", "AYSEYILMAZ@ADMIN.COM", null, "AQAAAAIAAYagAAAAEK7jvqyZc7uJt+CVkWUgTHQGLttMlCqsY9x3hhsdstRotVcgob+vWDsy+AKD2w//SA==", "5327654321", false, 0, "3fe5c7dd-e418-41f3-b0de-3f55705f3d83", 0, false, null },
                    { "d04b2879-cff4-4d92-8e3f-97acdc6c0e42", 0, "9ba4e367-15cf-488f-8e35-fabc832a586d", new DateTime(1990, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alicelik@business.com", true, "Ali", 1, "Çelik", false, null, "", "ALICELIK@BUSINESS.COM", null, "AQAAAAIAAYagAAAAEFl16tGXciOP49pQuQqh8tI7ds7W+Jh/4m4X9bDXKC82i2wEt9Yfqtr5Fz24a4oHCw==", "5364567890", false, 0, "2d6b6e0e-201e-4bb0-a0e2-37ab363cff4c", 0, false, null },
                    { "f8c9debe-935b-432a-b8a2-7c417f7767b1", 0, "b5439ad4-2061-4c71-9522-0f8c77e77fba", new DateTime(1992, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "mehmetguler@hotmail.com", true, "Mehmet", 1, "Güler", false, null, "", "MEHMETGULER@HOTMAIL.COM", null, "AQAAAAIAAYagAAAAEB/SuG+XD4eVLWU3BJOCoSFmaGLVMGivaSeMWib5B+wpiEvNuS6M7ydFQhBKhJ8sTw==", "5551234567", false, 0, "37a533c4-fb74-40db-ae96-8201492a886e", 0, false, null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Teknoloji" },
                    { 2, "Bilgisayar & Tablet" },
                    { 3, "Telefon & Aksesuar" },
                    { 4, "Cilt Bakımı" },
                    { 5, "Makyaj" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagId", "Name" },
                values: new object[,]
                {
                    { 1, "Gaming" },
                    { 2, "Laptop" },
                    { 3, "Bluetooth" },
                    { 4, "Kulaklık" },
                    { 5, "Klavye" },
                    { 6, "Akıllı Telefon" },
                    { 7, "Aksesuar" },
                    { 8, "Cilt Bakımı" },
                    { 9, "Serum" },
                    { 10, "Makyaj" },
                    { 11, "Fondöten" }
                });

            migrationBuilder.InsertData(
                table: "ActivityLogs",
                columns: new[] { "ActivityLogId", "ActivityDate", "ActivityType", "Details", "EntityId", "EntityName", "EntityType", "ProductId", "ServiceId", "UserId" },
                values: new object[,]
                {
                    { 4, new DateTime(2025, 2, 21, 14, 37, 51, 228, DateTimeKind.Utc).AddTicks(4990), 5, "Yeni kullanıcı kaydoldu.", 1, "Ali Çelik", 6, null, null, "d04b2879-cff4-4d92-8e3f-97acdc6c0e42" },
                    { 5, new DateTime(2025, 3, 2, 14, 37, 51, 228, DateTimeKind.Utc).AddTicks(4992), 4, "Ahmet Yıldız giriş yaptı.", 1, "Ahmet Yıldız", 6, null, null, "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1e01f984-8836-4e4b-902a-d60fa23b1833", "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b" },
                    { "fa5c0d5b-8b9b-4377-a2ba-d5765a8ed25c", "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3" },
                    { "ab5cd8c9-8f8e-48b2-83c1-b96e5f98413a", "d04b2879-cff4-4d92-8e3f-97acdc6c0e42" },
                    { "d4b8c6bc-0182-4c29-8c88-8e68bc8a7b2b", "f8c9debe-935b-432a-b8a2-7c417f7767b1" }
                });

            migrationBuilder.InsertData(
                table: "BusinessProfiles",
                columns: new[] { "BusinessProfileId", "BusinessDescription", "BusinessName", "ClickCount", "ContactInfo", "LikeCount", "Location", "NotificationId", "OwnerId" },
                values: new object[,]
                {
                    { 1, "En yeni teknolojik ürünleri bulabileceğiniz mağaza.", "TechWorld", 0, "techworld@business.com - 0212 123 45 67", 0, "İstanbul, Türkiye", null, "d04b2879-cff4-4d92-8e3f-97acdc6c0e42" },
                    { 2, "Kozmetik ve cilt bakım ürünleri üzerine uzmanlaşmış bir mağaza.", "BeautyGlow", 0, "beautyglow@business.com - 0216 765 43 21", 0, "Ankara, Türkiye", null, "d04b2879-cff4-4d92-8e3f-97acdc6c0e42" }
                });

            migrationBuilder.InsertData(
                table: "Conversations",
                columns: new[] { "ConversationId", "LastMessageDate", "ReceiverId", "SenderId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 2, 14, 37, 51, 228, DateTimeKind.Utc).AddTicks(5055), "f8c9debe-935b-432a-b8a2-7c417f7767b1", "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b" },
                    { 2, new DateTime(2025, 3, 1, 14, 37, 51, 228, DateTimeKind.Utc).AddTicks(5058), "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b", "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3" },
                    { 3, new DateTime(2025, 2, 28, 14, 37, 51, 228, DateTimeKind.Utc).AddTicks(5059), "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3", "f8c9debe-935b-432a-b8a2-7c417f7767b1" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "Content", "ConversationId", "FileUrl", "IsRead", "ReceiverId", "SenderId", "SentDate" },
                values: new object[,]
                {
                    { 1, "Merhaba, Gaming Laptop hakkında daha fazla bilgi alabilir miyim?", 1, "/images/product.jpg", false, "f8c9debe-935b-432a-b8a2-7c417f7767b1", "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b", new DateTime(2025, 3, 1, 14, 37, 51, 228, DateTimeKind.Utc).AddTicks(5146) },
                    { 2, "Tabii, Gaming Laptop hakkında her türlü bilgiyi verebilirim. Hangi özelliklere bakıyorsunuz?", 1, "/images/product.jpg", false, "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b", "f8c9debe-935b-432a-b8a2-7c417f7767b1", new DateTime(2025, 3, 2, 14, 37, 51, 228, DateTimeKind.Utc).AddTicks(5150) },
                    { 3, "Merhaba Ahmet, cilt bakım ürünlerimiz hakkında bilgi almak ister misiniz?", 2, null, true, "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b", "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3", new DateTime(2025, 2, 28, 14, 37, 51, 228, DateTimeKind.Utc).AddTicks(5152) },
                    { 4, "Evet, ilgileniyorum. Hangi ürünleri önerirsiniz?", 2, null, false, "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3", "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b", new DateTime(2025, 3, 1, 14, 37, 51, 228, DateTimeKind.Utc).AddTicks(5154) },
                    { 5, "Merhaba Ayşe, telefon kılıfını almak istiyorum, hangi renkleri önerirsin?", 3, "/images/product.jpg", false, "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3", "f8c9debe-935b-432a-b8a2-7c417f7767b1", new DateTime(2025, 3, 2, 14, 37, 51, 228, DateTimeKind.Utc).AddTicks(5156) }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "NotificationId", "BusinessProfileId", "DateCreated", "IsRead", "Message", "NotificationType", "ProductId", "ServiceId", "UserId" },
                values: new object[,]
                {
                    { 4, null, new DateTime(2025, 3, 2, 17, 37, 51, 228, DateTimeKind.Local).AddTicks(5217), true, "Yeni mesajınız var.", 4, null, null, "d04b2879-cff4-4d92-8e3f-97acdc6c0e42" },
                    { 5, null, new DateTime(2025, 2, 26, 17, 37, 51, 228, DateTimeKind.Local).AddTicks(5219), false, "Profiliniz güncellendi.", 5, null, null, "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b" }
                });

            migrationBuilder.InsertData(
                table: "SearchHistories",
                columns: new[] { "SearchHistoryId", "SearchDate", "SearchQuery", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 26, 14, 37, 51, 228, DateTimeKind.Utc).AddTicks(5777), "Gaming Laptop", "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b" },
                    { 2, new DateTime(2025, 2, 28, 14, 37, 51, 228, DateTimeKind.Utc).AddTicks(5780), "Kablosuz Kulaklık", "f8c9debe-935b-432a-b8a2-7c417f7767b1" },
                    { 3, new DateTime(2025, 3, 1, 14, 37, 51, 228, DateTimeKind.Utc).AddTicks(5781), "Hyaluronik Asit Serum", "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3" },
                    { 4, new DateTime(2025, 3, 2, 14, 37, 51, 228, DateTimeKind.Utc).AddTicks(5782), "Akıllı Telefon X", "d04b2879-cff4-4d92-8e3f-97acdc6c0e42" }
                });

            migrationBuilder.InsertData(
                table: "UserFollows",
                columns: new[] { "FollowedId", "FollowerId" },
                values: new object[,]
                {
                    { "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3", "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b" },
                    { "f8c9debe-935b-432a-b8a2-7c417f7767b1", "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b" },
                    { "f8c9debe-935b-432a-b8a2-7c417f7767b1", "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3" },
                    { "d04b2879-cff4-4d92-8e3f-97acdc6c0e42", "f8c9debe-935b-432a-b8a2-7c417f7767b1" }
                });

            migrationBuilder.InsertData(
                table: "UserProfileCustomizations",
                columns: new[] { "UserProfileCustomizationId", "CustomBackgroundImage", "CustomDescription", "CustomProfileImage", "UserId" },
                values: new object[,]
                {
                    { 1, "/images/businnesBackground.png", "Kişisel teknoloji meraklısı, oyun bilgisayarları ve aksesuarları hakkında bilgi sahibi.", "/images/user1.jpg", "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b" },
                    { 2, "/images/businnesBackground.png", "Satış uzmanı, kulaklıklar ve telefon aksesuarları konusunda uzman.", "/images/user2.jpg", "f8c9debe-935b-432a-b8a2-7c417f7767b1" },
                    { 3, "/images/businnesBackground.png", "Cilt bakımına meraklı, makyaj ürünleri ve kişisel bakım konusunda bilgi sahibiyim.", "/images/user4.jpg", "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3" },
                    { 4, "/images/businnesBackground.png", "İşletme sahibi, teknoloji ürünleri ve kişisel bakım ürünleri satışı yapıyorum.", "/images/user3.jpg", "d04b2879-cff4-4d92-8e3f-97acdc6c0e42" }
                });

            migrationBuilder.InsertData(
                table: "BusinessProfileCustomizations",
                columns: new[] { "BusinessProfileCustomizationId", "BusinessProfileId", "CustomBackgroundImage", "CustomDescription", "CustomProfileImage" },
                values: new object[,]
                {
                    { 1, 1, "/images/businnesBackground.png", "Teknoloji severler için en yeni ürünleri sunuyoruz.", "/images/businnesProfile.png" },
                    { 2, 2, "/images/businnesBackground.png", "Cilt bakımında en kaliteli ürünleri sizin için seçiyoruz.", "/images/businnesProfile.png" }
                });

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "CampaignId", "BusinessProfileId", "ClickCount", "Description", "DiscountPercentage", "EndDate", "LikeCount", "StartDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { 1, 1, 0, "Tüm teknolojik ürünlerde %15 indirim!", 15.00m, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bahar İndirimi", 0 },
                    { 2, 2, 0, "Seçili cilt bakım ürünlerinde %20 indirim fırsatı!", 20.00m, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cilt Bakım Günleri", 0 }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "NotificationId", "BusinessProfileId", "DateCreated", "IsRead", "Message", "NotificationType", "ProductId", "ServiceId", "UserId" },
                values: new object[] { 3, 1, new DateTime(2025, 2, 28, 17, 37, 51, 228, DateTimeKind.Local).AddTicks(5214), false, "Kampanya güncellendi.", 3, null, null, "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "BusinessProfileId", "CampaignId", "ClickCount", "CreatedDate", "Description", "FavoriteId", "FavoriteId1", "LikeCount", "Name", "Price", "ViewCount", "imgUrl" },
                values: new object[,]
                {
                    { 1, 1, null, 0, new DateTime(2025, 3, 3, 14, 37, 50, 977, DateTimeKind.Utc).AddTicks(8776), "Yüksek performanslı oyuncu laptopu.", null, null, 0, "Gaming Laptop", 25000.00m, 0, "/images/product.jpg" },
                    { 2, 1, null, 0, new DateTime(2025, 3, 3, 14, 37, 50, 977, DateTimeKind.Utc).AddTicks(8781), "Bluetooth bağlantılı yüksek ses kalitesi sunan kulaklık.", null, null, 0, "Kablosuz Kulaklık", 1500.00m, 0, "/images/product.jpg" },
                    { 3, 1, null, 0, new DateTime(2025, 3, 3, 14, 37, 50, 977, DateTimeKind.Utc).AddTicks(8783), "Yüksek çözünürlüklü ekran ve uzun pil ömrü ile profesyonel tablet.", null, null, 0, "Tablet Pro 2025", 12000.00m, 0, "/images/product.jpg" },
                    { 4, 1, null, 0, new DateTime(2025, 3, 3, 14, 37, 50, 977, DateTimeKind.Utc).AddTicks(8786), "RGB ışıklı, mekanik anahtarlı gaming klavye.", null, null, 0, "Mekanik Klavye", 2500.00m, 0, "/images/product.jpg" },
                    { 5, 1, null, 0, new DateTime(2025, 3, 3, 14, 37, 50, 977, DateTimeKind.Utc).AddTicks(8787), "Üst düzey performans sunan en yeni akıllı telefon modeli.", null, null, 0, "Akıllı Telefon X", 18000.00m, 0, "/images/product.jpg" },
                    { 6, 1, null, 0, new DateTime(2025, 3, 3, 14, 37, 50, 977, DateTimeKind.Utc).AddTicks(8789), "Dayanıklı silikon kılıf, farklı renk seçenekleriyle.", null, null, 0, "Telefon Kılıfı", 250.00m, 0, "/images/product.jpg" },
                    { 7, 2, null, 0, new DateTime(2025, 3, 3, 14, 37, 50, 977, DateTimeKind.Utc).AddTicks(8790), "Yoğun nemlendirme sağlayan hyaluronik asit içeren serum.", null, null, 0, "Hyaluronik Asit Serum", 500.00m, 0, "/images/product.jpg" },
                    { 8, 2, null, 0, new DateTime(2025, 3, 3, 14, 37, 50, 977, DateTimeKind.Utc).AddTicks(8792), "Yüksek koruma sağlayan güneş kremi.", null, null, 0, "Güneş Koruyucu Krem SPF 50", 450.00m, 0, "/images/product.jpg" },
                    { 9, 2, null, 0, new DateTime(2025, 3, 3, 14, 37, 50, 977, DateTimeKind.Utc).AddTicks(8793), "Uzun süre kalıcı, mat bitişli likit ruj.", null, null, 0, "Mat Likit Ruj", 300.00m, 0, "/images/product.jpg" },
                    { 10, 2, null, 0, new DateTime(2025, 3, 3, 14, 37, 50, 977, DateTimeKind.Utc).AddTicks(8795), "Doğal bitişli, cilt tonunu eşitleyen fondöten.", null, null, 0, "Fondöten", 600.00m, 0, "/images/product.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "BusinessProfileId", "ClickCount", "Description", "FavoriteId", "FavoriteId1", "LikeCount", "Price", "ServiceName" },
                values: new object[,]
                {
                    { 1, 1, 0, "Her marka laptop için profesyonel teknik servis hizmeti.", null, null, 0, 250.00m, "Laptop Teknik Servisi" },
                    { 2, 1, 0, "Ekran değişimi, batarya değişimi ve diğer tamir hizmetleri.", null, null, 0, 150.00m, "Telefon Tamiri" },
                    { 3, 2, 0, "Cilt tipinize uygun bakım önerileri ile analiz hizmeti.", null, null, 0, 100.00m, "Cilt Analizi" },
                    { 4, 2, 0, "Özel günler için profesyonel makyaj hizmeti.", null, null, 0, 300.00m, "Profesyonel Makyaj" }
                });

            migrationBuilder.InsertData(
                table: "ActivityLogs",
                columns: new[] { "ActivityLogId", "ActivityDate", "ActivityType", "Details", "EntityId", "EntityName", "EntityType", "ProductId", "ServiceId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 26, 14, 37, 51, 228, DateTimeKind.Utc).AddTicks(4966), 1, "Gaming Laptop ürününe tıklandı.", 1, "Gaming Laptop", 1, 1, null, "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b" },
                    { 2, new DateTime(2025, 2, 28, 14, 37, 51, 228, DateTimeKind.Utc).AddTicks(4984), 2, "Telefon Kılıfı ürünü beğenildi.", 6, "Telefon Kılıfı", 1, 6, null, "f8c9debe-935b-432a-b8a2-7c417f7767b1" },
                    { 3, new DateTime(2025, 3, 1, 14, 37, 51, 228, DateTimeKind.Utc).AddTicks(4987), 3, "Hyaluronik Asit Serum görüntülendi.", 7, "Hyaluronik Asit Serum", 1, 7, null, "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3" }
                });

            migrationBuilder.InsertData(
                table: "Favorites",
                columns: new[] { "FavoriteId", "ProductId", "ServiceId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, null, "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b" },
                    { 2, 2, null, "f8c9debe-935b-432a-b8a2-7c417f7767b1" },
                    { 3, 7, null, "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3" },
                    { 4, 5, null, "d04b2879-cff4-4d92-8e3f-97acdc6c0e42" }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "NotificationId", "BusinessProfileId", "DateCreated", "IsRead", "Message", "NotificationType", "ProductId", "ServiceId", "UserId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 3, 1, 17, 37, 51, 228, DateTimeKind.Local).AddTicks(5194), false, "Ürünün beğenildi.", 1, 1, null, "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b" },
                    { 2, null, new DateTime(2025, 3, 2, 17, 37, 51, 228, DateTimeKind.Local).AddTicks(5212), true, "Ürüne yorum yapıldı.", 2, 2, null, "f8c9debe-935b-432a-b8a2-7c417f7767b1" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 4, 7 },
                    { 4, 8 },
                    { 5, 9 },
                    { 5, 10 }
                });

            migrationBuilder.InsertData(
                table: "ProductTags",
                columns: new[] { "ProductId", "TagId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 2 },
                    { 4, 5 },
                    { 5, 6 },
                    { 6, 7 },
                    { 7, 8 },
                    { 8, 9 },
                    { 9, 10 },
                    { 10, 11 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "Comment", "DateCreated", "ProductId", "Rating", "ServiceId", "UserId" },
                values: new object[,]
                {
                    { 1, "Gaming Laptop gerçekten harika, yüksek performans ve uzun pil ömrü ile çok beğendim!", new DateTime(2025, 2, 26, 14, 37, 51, 228, DateTimeKind.Utc).AddTicks(5312), 1, 5, null, "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b" },
                    { 2, "Kablosuz Kulaklık güzel ama biraz daha ses yalıtımı olabilirdi.", new DateTime(2025, 2, 27, 14, 37, 51, 228, DateTimeKind.Utc).AddTicks(5317), 2, 4, null, "f8c9debe-935b-432a-b8a2-7c417f7767b1" },
                    { 3, "Tablet Pro 2025 fena değil ancak ekranı biraz daha parlak olabilirdi.", new DateTime(2025, 2, 28, 14, 37, 51, 228, DateTimeKind.Utc).AddTicks(5318), 3, 3, null, "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3" },
                    { 4, "Telefon Kılıfı çok sağlam ve şık. Telefonu koruma konusunda çok başarılı.", new DateTime(2025, 3, 1, 14, 37, 51, 228, DateTimeKind.Utc).AddTicks(5320), 6, 5, null, "1e5c4d9b-cd72-41f1-b123-57b66ac50f3b" },
                    { 5, "Cilt bakımında gerçekten iyi sonuçlar aldım, fakat biraz daha nemlendirici olabilir.", new DateTime(2025, 3, 2, 14, 37, 51, 228, DateTimeKind.Utc).AddTicks(5322), 7, 4, null, "f8c9debe-935b-432a-b8a2-7c417f7767b1" },
                    { 6, "Makyaj seti beklediğimi vermedi. Kalıcılığı çok düşük.", new DateTime(2025, 2, 24, 14, 37, 51, 228, DateTimeKind.Utc).AddTicks(5323), 9, 2, null, "8d1a2c8f-bd5f-48c7-a6fe-bf1a31fe63d3" },
                    { 7, "Hyaluronik Asit Serum mükemmel. Cildim çok daha parlak ve nemli oldu.", new DateTime(2025, 2, 25, 14, 37, 51, 228, DateTimeKind.Utc).AddTicks(5374), 7, 5, null, "d04b2879-cff4-4d92-8e3f-97acdc6c0e42" }
                });

            migrationBuilder.InsertData(
                table: "SearchResults",
                columns: new[] { "SearchResultId", "BusinessProfileId", "ProductId", "SearchDate", "SearchQuery", "ServiceId" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2025, 2, 26, 14, 37, 51, 228, DateTimeKind.Utc).AddTicks(5823), "Gaming Laptop", null },
                    { 2, 1, 2, new DateTime(2025, 2, 28, 14, 37, 51, 228, DateTimeKind.Utc).AddTicks(5825), "Kablosuz Kulaklık", null },
                    { 3, 2, 7, new DateTime(2025, 3, 1, 14, 37, 51, 228, DateTimeKind.Utc).AddTicks(5826), "Hyaluronik Asit Serum", null },
                    { 4, 1, 5, new DateTime(2025, 3, 2, 14, 37, 51, 228, DateTimeKind.Utc).AddTicks(5828), "Akıllı Telefon X", null }
                });

            migrationBuilder.InsertData(
                table: "ServiceTags",
                columns: new[] { "ServiceId", "TagId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 8 },
                    { 3, 9 },
                    { 4, 10 },
                    { 4, 11 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_ProductId",
                table: "ActivityLogs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_ServiceId",
                table: "ActivityLogs",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_UserId",
                table: "ActivityLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProfileCustomizations_BusinessProfileId",
                table: "BusinessProfileCustomizations",
                column: "BusinessProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProfiles_OwnerId",
                table: "BusinessProfiles",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProfileTags_TagId",
                table: "BusinessProfileTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_BusinessProfileId",
                table: "Campaigns",
                column: "BusinessProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ConversationMessage_MessagesMessageId",
                table: "ConversationMessage",
                column: "MessagesMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_ReceiverId",
                table: "Conversations",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversations_SenderId",
                table: "Conversations",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_ProductId",
                table: "Favorites",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_ServiceId",
                table: "Favorites",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverId",
                table: "Messages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_BusinessProfileId",
                table: "Notifications",
                column: "BusinessProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ProductId",
                table: "Notifications",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ServiceId",
                table: "Notifications",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BusinessProfileId",
                table: "Products",
                column: "BusinessProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CampaignId",
                table: "Products",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FavoriteId1",
                table: "Products",
                column: "FavoriteId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTags_TagId",
                table: "ProductTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ServiceId",
                table: "Reviews",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SearchHistories_UserId",
                table: "SearchHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SearchResults_BusinessProfileId",
                table: "SearchResults",
                column: "BusinessProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_SearchResults_ProductId",
                table: "SearchResults",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SearchResults_ServiceId",
                table: "SearchResults",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_BusinessProfileId",
                table: "Services",
                column: "BusinessProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_FavoriteId1",
                table: "Services",
                column: "FavoriteId1");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTags_TagId",
                table: "ServiceTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFollows_FollowedId",
                table: "UserFollows",
                column: "FollowedId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileCustomizations_UserId",
                table: "UserProfileCustomizations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityLogs_Products_ProductId",
                table: "ActivityLogs",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityLogs_Services_ServiceId",
                table: "ActivityLogs",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Products_ProductId",
                table: "Favorites",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Services_ServiceId",
                table: "Favorites",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessProfiles_AspNetUsers_OwnerId",
                table: "BusinessProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_AspNetUsers_UserId",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Products_ProductId",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Services_ServiceId",
                table: "Favorites");

            migrationBuilder.DropTable(
                name: "ActivityLogs");

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
                name: "BusinessProfileCustomizations");

            migrationBuilder.DropTable(
                name: "BusinessProfileTags");

            migrationBuilder.DropTable(
                name: "ConversationMessage");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ProductTags");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "SearchHistories");

            migrationBuilder.DropTable(
                name: "SearchResults");

            migrationBuilder.DropTable(
                name: "ServiceTags");

            migrationBuilder.DropTable(
                name: "UserFollows");

            migrationBuilder.DropTable(
                name: "UserProfileCustomizations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Conversations");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "BusinessProfiles");

            migrationBuilder.DropTable(
                name: "Favorites");
        }
    }
}
