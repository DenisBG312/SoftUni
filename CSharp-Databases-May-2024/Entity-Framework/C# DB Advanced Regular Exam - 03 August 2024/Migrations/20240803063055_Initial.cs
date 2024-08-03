using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAgency.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TourPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourPackages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    TourPackageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_TourPackages_TourPackageId",
                        column: x => x.TourPackageId,
                        principalTable: "TourPackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TourPackagesGuides",
                columns: table => new
                {
                    TourPackageId = table.Column<int>(type: "int", nullable: false),
                    GuideId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourPackagesGuides", x => new { x.TourPackageId, x.GuideId });
                    table.ForeignKey(
                        name: "FK_TourPackagesGuides_Guides_GuideId",
                        column: x => x.GuideId,
                        principalTable: "Guides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TourPackagesGuides_TourPackages_TourPackageId",
                        column: x => x.TourPackageId,
                        principalTable: "TourPackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Guides",
                columns: new[] { "Id", "FullName", "Language" },
                values: new object[,]
                {
                    { 1, "John Doe", 4 },
                    { 2, "Jane Smith", 0 },
                    { 3, "Alex Johnson", 3 },
                    { 4, "Emily Davis", 2 },
                    { 5, "Michael Brown", 1 },
                    { 6, "Sarah Wilson", 4 },
                    { 7, "David Lee", 0 },
                    { 8, "Laura Garcia", 1 },
                    { 9, "Chris Martin", 3 },
                    { 10, "Anna Thompson", 2 }
                });

            migrationBuilder.InsertData(
                table: "TourPackages",
                columns: new[] { "Id", "Description", "PackageName", "Price" },
                values: new object[,]
                {
                    { 1, "Experience the thrill of a guided horse riding tour through picturesque landscapes. Suitable for all skill levels. Enjoy nature and create unforgettable memories. Duration: 3 hours.", "Horse Riding Tour", 199.99m },
                    { 2, "Explore the city's top attractions with a guided sightseeing tour. Visit historical landmarks, iconic buildings, and scenic spots. Perfect for all ages. Duration: 4 hours.", "Sightseeing Tour", 149.99m },
                    { 3, "Dive into the crystal-clear waters and explore vibrant coral reefs and marine life. Suitable for beginners and experienced divers. Equipment provided. Duration: 2 hours.", "Diving Tour", 299.99m },
                    { 4, "Embark on an exhilarating mountain hiking tour. Enjoy breathtaking views, fresh air, and challenging trails. Suitable for all fitness levels. Duration: 5 hours.", "Mountain Hiking", 179.99m },
                    { 5, "Discover the charm of the city with a guided tour. Visit famous landmarks, bustling markets, and hidden gems. Perfect for all ages. Duration: 3 hours.", "City Tour", 129.99m },
                    { 6, "Savor the local flavors on a guided food tour. Taste a variety of dishes, visit top eateries, and learn about the culinary culture. Suitable for all food lovers. Duration: 3 hours.", "Food Tour", 99.99m },
                    { 7, "Embark on an exciting wildlife safari. Spot exotic animals in their natural habitat, guided by experts. Perfect for nature enthusiasts. Duration: 4 hours.", "Wildlife Safari", 249.99m },
                    { 8, "Explore ancient ruins, museums, and landmarks on a guided tour. Learn about the rich history and culture of the area. Ideal for history buffs. Duration: 4 hours.", "Historical Sites", 159.99m },
                    { 9, "Experience a breathtaking sunset on a luxury cruise. Enjoy stunning views, delicious refreshments, and a relaxing atmosphere. Perfect for couples and families. Duration: 2 hours.", "Sunset Cruise", 399.99m }
                });

            migrationBuilder.InsertData(
                table: "TourPackagesGuides",
                columns: new[] { "GuideId", "TourPackageId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 2 },
                    { 5, 2 },
                    { 6, 2 },
                    { 7, 3 },
                    { 8, 3 },
                    { 9, 3 },
                    { 1, 4 },
                    { 2, 4 },
                    { 10, 4 },
                    { 3, 5 },
                    { 4, 5 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 6 },
                    { 8, 6 },
                    { 1, 7 },
                    { 9, 7 },
                    { 10, 7 },
                    { 2, 8 },
                    { 3, 8 },
                    { 4, 8 },
                    { 5, 9 },
                    { 6, 9 },
                    { 7, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CustomerId",
                table: "Bookings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TourPackageId",
                table: "Bookings",
                column: "TourPackageId");

            migrationBuilder.CreateIndex(
                name: "IX_TourPackagesGuides_GuideId",
                table: "TourPackagesGuides",
                column: "GuideId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "TourPackagesGuides");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Guides");

            migrationBuilder.DropTable(
                name: "TourPackages");
        }
    }
}
