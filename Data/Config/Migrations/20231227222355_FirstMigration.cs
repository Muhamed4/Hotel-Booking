using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel_Booking.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "HotelBooking");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "HotelBooking",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    FirstName = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    LastName = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Image = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

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
                    Image = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USER_HOTEL",
                        column: x => x.UserID,
                        principalSchema: "HotelBooking",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                schema: "HotelBooking",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FreeParking = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    LaundryFacility = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    NoSmoking = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    FreeWifi = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    FreeBreakfast = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    AirportTransfer = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    FontDesk247 = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    Restaurant = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    AirCondition = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
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
                name: "Reviews",
                schema: "HotelBooking",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<decimal>(type: "DECIMAL(10,2)", precision: 10, scale: 2, nullable: false),
                    Comment = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Date = table.Column<DateTime>(type: "DATETIME2(3)", nullable: false, defaultValueSql: "GETDATE()"),
                    UserID = table.Column<int>(type: "int", nullable: false),
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
                    Price = table.Column<decimal>(type: "DECIMAL(10,2)", precision: 10, scale: 2, nullable: false),
                    RoomNumber = table.Column<int>(type: "INT", nullable: false),
                    BedCount = table.Column<int>(type: "INT", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "DATETIME(3)", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "DATETIME(3)", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    HotelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_HOTEL_CONSISTSOF_ROOMS",
                        column: x => x.HotelID,
                        principalSchema: "HotelBooking",
                        principalTable: "Hotels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USER_BOOK_ROOM",
                        column: x => x.UserID,
                        principalSchema: "HotelBooking",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "UserReactHotels",
                schema: "HotelBooking",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    HotelID = table.Column<int>(type: "int", nullable: false),
                    Like = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReactHotels", x => new { x.UserID, x.HotelID });
                    table.ForeignKey(
                        name: "FK_HOTEL_USER_REACT_HOTEL",
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
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserWatchHotels",
                schema: "HotelBooking",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    HotelID = table.Column<int>(type: "int", nullable: false),
                    WatchCount = table.Column<int>(type: "INT", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWatchHotels", x => new { x.UserID, x.HotelID });
                    table.ForeignKey(
                        name: "FK_HOTEL_USERWATCHHOTELS",
                        column: x => x.HotelID,
                        principalSchema: "HotelBooking",
                        principalTable: "Hotels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USER_USERWATCHHOTELS",
                        column: x => x.UserID,
                        principalSchema: "HotelBooking",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeatureFacilities",
                schema: "HotelBooking",
                columns: table => new
                {
                    FeatureID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureFacilities", x => new { x.FeatureID, x.Description });
                    table.ForeignKey(
                        name: "FK_FEATURE_FACILITY",
                        column: x => x.FeatureID,
                        principalSchema: "HotelBooking",
                        principalTable: "Features",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeatureFoodDrinks",
                schema: "HotelBooking",
                columns: table => new
                {
                    FeatureID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureFoodDrinks", x => new { x.FeatureID, x.Description });
                    table.ForeignKey(
                        name: "FK_FEATURE_FOODDRINK",
                        column: x => x.FeatureID,
                        principalSchema: "HotelBooking",
                        principalTable: "Features",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeatureFunPrograms",
                schema: "HotelBooking",
                columns: table => new
                {
                    FeatureID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureFunPrograms", x => new { x.FeatureID, x.Description });
                    table.ForeignKey(
                        name: "FK_FEATURE_FUNPROGRAM",
                        column: x => x.FeatureID,
                        principalSchema: "HotelBooking",
                        principalTable: "Features",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeatureServices",
                schema: "HotelBooking",
                columns: table => new
                {
                    FeatureID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureServices", x => new { x.FeatureID, x.Description });
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

            migrationBuilder.CreateIndex(
                name: "IX_Features_HotelID",
                schema: "HotelBooking",
                table: "Features",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_UserID",
                schema: "HotelBooking",
                table: "Hotels",
                column: "UserID");

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
                name: "IX_Rooms_HotelID",
                schema: "HotelBooking",
                table: "Rooms",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_UserID",
                schema: "HotelBooking",
                table: "Rooms",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserReactHotels_HotelID",
                schema: "HotelBooking",
                table: "UserReactHotels",
                column: "HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_UserWatchHotels_HotelID",
                schema: "HotelBooking",
                table: "UserWatchHotels",
                column: "HotelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeatureFacilities",
                schema: "HotelBooking");

            migrationBuilder.DropTable(
                name: "FeatureFoodDrinks",
                schema: "HotelBooking");

            migrationBuilder.DropTable(
                name: "FeatureFunPrograms",
                schema: "HotelBooking");

            migrationBuilder.DropTable(
                name: "FeatureServices",
                schema: "HotelBooking");

            migrationBuilder.DropTable(
                name: "Reviews",
                schema: "HotelBooking");

            migrationBuilder.DropTable(
                name: "RoomImages",
                schema: "HotelBooking");

            migrationBuilder.DropTable(
                name: "UserReactHotels",
                schema: "HotelBooking");

            migrationBuilder.DropTable(
                name: "UserWatchHotels",
                schema: "HotelBooking");

            migrationBuilder.DropTable(
                name: "Features",
                schema: "HotelBooking");

            migrationBuilder.DropTable(
                name: "Rooms",
                schema: "HotelBooking");

            migrationBuilder.DropTable(
                name: "Hotels",
                schema: "HotelBooking");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "HotelBooking");
        }
    }
}
