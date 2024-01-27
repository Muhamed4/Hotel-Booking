using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Booking.Migrations
{
    public partial class FirstMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "HotelBooking");

            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.CreateTable(
                name: "Hotels",
                schema: "HotelBooking",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Country = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    City = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Image = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "IdentityRole",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "HotelBooking",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    LastName = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Image = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
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
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                schema: "HotelBooking",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FreeParking = table.Column<bool>(type: "BIT", nullable: true, defaultValueSql: "(0)"),
                    LaundryFacility = table.Column<bool>(type: "BIT", nullable: true, defaultValueSql: "(0)"),
                    NoSmoking = table.Column<bool>(type: "BIT", nullable: true, defaultValueSql: "(0)"),
                    FreeWifi = table.Column<bool>(type: "BIT", nullable: true, defaultValueSql: "(0)"),
                    FreeBreakfast = table.Column<bool>(type: "BIT", nullable: true, defaultValueSql: "(0)"),
                    AirportTransfer = table.Column<bool>(type: "BIT", nullable: true, defaultValueSql: "(0)"),
                    FontDesk247 = table.Column<bool>(type: "BIT", nullable: true, defaultValueSql: "(0)"),
                    Restaurant = table.Column<bool>(type: "BIT", nullable: true, defaultValueSql: "(0)"),
                    AirCondition = table.Column<bool>(type: "BIT", nullable: true, defaultValueSql: "(0)"),
                    HotelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HOTEL_FEATURES",
                        column: x => x.HotelID,
                        principalSchema: "HotelBooking",
                        principalTable: "Hotels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                schema: "HotelBooking",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    RoomNumber = table.Column<int>(type: "INT", nullable: false),
                    BedCount = table.Column<int>(type: "INT", nullable: false),
                    HotelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HOTEL_ROOMS",
                        column: x => x.HotelID,
                        principalSchema: "HotelBooking",
                        principalTable: "Hotels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityRoleClaim",
                schema: "Security",
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
                    table.PrimaryKey("PK_IdentityRoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityRoleClaim_IdentityRole_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Security",
                        principalTable: "IdentityRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserClaim",
                schema: "Security",
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
                    table.PrimaryKey("PK_IdentityUserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityUserClaim_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "HotelBooking",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserLogin",
                schema: "Security",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_IdentityUserLogin_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "HotelBooking",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserRole",
                schema: "Security",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_IdentityUserRole_IdentityRole_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Security",
                        principalTable: "IdentityRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentityUserRole_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "HotelBooking",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUserToken",
                schema: "Security",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_IdentityUserToken_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "HotelBooking",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                schema: "HotelBooking",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    Comment = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Date = table.Column<DateTime>(type: "DATETIME2", nullable: false, defaultValueSql: "GETDATE()"),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HotelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HOTEL_REVIEWS",
                        column: x => x.HotelID,
                        principalSchema: "HotelBooking",
                        principalTable: "Hotels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USER_REVIEWS",
                        column: x => x.UserID,
                        principalSchema: "HotelBooking",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserReactHotels",
                schema: "HotelBooking",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HotelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReactHotels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HOTEL_USErREACTHotels",
                        column: x => x.HotelID,
                        principalSchema: "HotelBooking",
                        principalTable: "Hotels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USER_USER_REACT_HOTEL",
                        column: x => x.UserID,
                        principalSchema: "HotelBooking",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserWatchHotels",
                schema: "HotelBooking",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HotelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWatchHotels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HOTEL_USErWATCHHotels",
                        column: x => x.HotelID,
                        principalSchema: "HotelBooking",
                        principalTable: "Hotels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USER_USER_WATCH_HOTEL",
                        column: x => x.UserID,
                        principalSchema: "HotelBooking",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                schema: "HotelBooking",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    FeatureID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FEATURE_FACILITY",
                        column: x => x.FeatureID,
                        principalSchema: "HotelBooking",
                        principalTable: "Features",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodDrinks",
                schema: "HotelBooking",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    FeatureID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodDrinks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FEATURE_FOODDRINK",
                        column: x => x.FeatureID,
                        principalSchema: "HotelBooking",
                        principalTable: "Features",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FunPrograms",
                schema: "HotelBooking",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    FeatureID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunPrograms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FEATURE_FUNPROGRAM",
                        column: x => x.FeatureID,
                        principalSchema: "HotelBooking",
                        principalTable: "Features",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                schema: "HotelBooking",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    FeatureID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FEATURE_SERVICE",
                        column: x => x.FeatureID,
                        principalSchema: "HotelBooking",
                        principalTable: "Features",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomImages",
                schema: "HotelBooking",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    RoomID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomImages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ROOM_IMAGE",
                        column: x => x.RoomID,
                        principalSchema: "HotelBooking",
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBookRooms",
                schema: "HotelBooking",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckIn = table.Column<DateTime>(type: "DATE", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "DATE", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoomID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBookRooms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USERBOOKROOM_BOOK_ROOM",
                        column: x => x.RoomID,
                        principalSchema: "HotelBooking",
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USERBOOKROOM_BOOK_USER",
                        column: x => x.UserID,
                        principalSchema: "HotelBooking",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_FeatureID",
                schema: "HotelBooking",
                table: "Facilities",
                column: "FeatureID");

            migrationBuilder.CreateIndex(
                name: "IX_Features_HotelID",
                schema: "HotelBooking",
                table: "Features",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodDrinks_FeatureID",
                schema: "HotelBooking",
                table: "FoodDrinks",
                column: "FeatureID");

            migrationBuilder.CreateIndex(
                name: "IX_FunPrograms_FeatureID",
                schema: "HotelBooking",
                table: "FunPrograms",
                column: "FeatureID");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Security",
                table: "IdentityRole",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityRoleClaim_RoleId",
                schema: "Security",
                table: "IdentityRoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserClaim_UserId",
                schema: "Security",
                table: "IdentityUserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserLogin_UserId",
                schema: "Security",
                table: "IdentityUserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentityUserRole_RoleId",
                schema: "Security",
                table: "IdentityUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_HotelID",
                schema: "HotelBooking",
                table: "Reviews",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserID",
                schema: "HotelBooking",
                table: "Reviews",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomImages_RoomID",
                schema: "HotelBooking",
                table: "RoomImages",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "RoomNumberUnique",
                schema: "HotelBooking",
                table: "Rooms",
                columns: new[] { "HotelID", "RoomNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_FeatureID",
                schema: "HotelBooking",
                table: "Services",
                column: "FeatureID");

            migrationBuilder.CreateIndex(
                name: "IX_UserBookRooms_RoomID",
                schema: "HotelBooking",
                table: "UserBookRooms",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_UserBookRooms_UserID",
                schema: "HotelBooking",
                table: "UserBookRooms",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserReactHotels_HotelID",
                schema: "HotelBooking",
                table: "UserReactHotels",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_UserReactHotels_UserID",
                schema: "HotelBooking",
                table: "UserReactHotels",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "HotelBooking",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "EmailUnique",
                schema: "HotelBooking",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "HotelBooking",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserWatchHotels_HotelID",
                schema: "HotelBooking",
                table: "UserWatchHotels",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_UserWatchHotels_UserID",
                schema: "HotelBooking",
                table: "UserWatchHotels",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facilities",
                schema: "HotelBooking");

            migrationBuilder.DropTable(
                name: "FoodDrinks",
                schema: "HotelBooking");

            migrationBuilder.DropTable(
                name: "FunPrograms",
                schema: "HotelBooking");

            migrationBuilder.DropTable(
                name: "IdentityRoleClaim",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "IdentityUserClaim",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "IdentityUserLogin",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "IdentityUserRole",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "IdentityUserToken",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Reviews",
                schema: "HotelBooking");

            migrationBuilder.DropTable(
                name: "RoomImages",
                schema: "HotelBooking");

            migrationBuilder.DropTable(
                name: "Services",
                schema: "HotelBooking");

            migrationBuilder.DropTable(
                name: "UserBookRooms",
                schema: "HotelBooking");

            migrationBuilder.DropTable(
                name: "UserReactHotels",
                schema: "HotelBooking");

            migrationBuilder.DropTable(
                name: "UserWatchHotels",
                schema: "HotelBooking");

            migrationBuilder.DropTable(
                name: "IdentityRole",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Features",
                schema: "HotelBooking");

            migrationBuilder.DropTable(
                name: "Rooms",
                schema: "HotelBooking");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "HotelBooking");

            migrationBuilder.DropTable(
                name: "Hotels",
                schema: "HotelBooking");
        }
    }
}
