using Microsoft.EntityFrameworkCore;
using TravelAgency.Data.Models;
using TravelAgency.Data.Models.Enums;

namespace TravelAgency.Data
{
    public class TravelAgencyContext : DbContext
    {
        private const string connectionString = @"Server=.;Database=TravelAgencyDB;Trusted_Connection=True;";

        public TravelAgencyContext()
        {

        }

        public TravelAgencyContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<TourPackage> TourPackages { get; set; }
        public DbSet<TourPackageGuide> TourPackagesGuides { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<TourPackageGuide>()
                .HasKey(tg => new { tg.TourPackageId, tg.GuideId });


            modelBuilder.Entity<Guide>().HasData(
                new Guide { Id = 1, FullName = "John Doe", Language = Language.Russian },
                new Guide { Id = 2, FullName = "Jane Smith", Language = Language.English },
                new Guide { Id = 3, FullName = "Alex Johnson", Language = Language.Spanish },
                new Guide { Id = 4, FullName = "Emily Davis", Language = Language.French },
                new Guide { Id = 5, FullName = "Michael Brown", Language = Language.German },
                new Guide { Id = 6, FullName = "Sarah Wilson", Language = Language.Russian },
                new Guide { Id = 7, FullName = "David Lee", Language = Language.English },
                new Guide { Id = 8, FullName = "Laura Garcia", Language = Language.German },
                new Guide { Id = 9, FullName = "Chris Martin", Language = Language.Spanish },
                new Guide { Id = 10, FullName = "Anna Thompson", Language = Language.French }
                );

            modelBuilder.Entity<TourPackage>().HasData(
                new TourPackage
                {
                    Id = 1,
                    PackageName = "Horse Riding Tour",
                    Description = "Experience the thrill of a guided horse riding tour through picturesque landscapes. Suitable for all skill levels. Enjoy nature and create unforgettable memories. Duration: 3 hours.",
                    Price = 199.99m
                },
                new TourPackage
                {
                    Id = 2,
                    PackageName = "Sightseeing Tour",
                    Description = "Explore the city's top attractions with a guided sightseeing tour. Visit historical landmarks, iconic buildings, and scenic spots. Perfect for all ages. Duration: 4 hours.",
                    Price = 149.99m
                },
                new TourPackage
                {
                    Id = 3,
                    PackageName = "Diving Tour",
                    Description = "Dive into the crystal-clear waters and explore vibrant coral reefs and marine life. Suitable for beginners and experienced divers. Equipment provided. Duration: 2 hours.",
                    Price = 299.99m
                },
                new TourPackage
                {
                    Id = 4,
                    PackageName = "Mountain Hiking",
                    Description = "Embark on an exhilarating mountain hiking tour. Enjoy breathtaking views, fresh air, and challenging trails. Suitable for all fitness levels. Duration: 5 hours.",
                    Price = 179.99m
                },
                new TourPackage
                {
                    Id = 5,
                    PackageName = "City Tour",
                    Description = "Discover the charm of the city with a guided tour. Visit famous landmarks, bustling markets, and hidden gems. Perfect for all ages. Duration: 3 hours.",
                    Price = 129.99m
                },
                new TourPackage
                {
                    Id = 6,
                    PackageName = "Food Tour",
                    Description = "Savor the local flavors on a guided food tour. Taste a variety of dishes, visit top eateries, and learn about the culinary culture. Suitable for all food lovers. Duration: 3 hours.",
                    Price = 99.99m
                },
                new TourPackage
                {
                    Id = 7,
                    PackageName = "Wildlife Safari",
                    Description = "Embark on an exciting wildlife safari. Spot exotic animals in their natural habitat, guided by experts. Perfect for nature enthusiasts. Duration: 4 hours.",
                    Price = 249.99m
                },
                new TourPackage
                {
                    Id = 8,
                    PackageName = "Historical Sites",
                    Description = "Explore ancient ruins, museums, and landmarks on a guided tour. Learn about the rich history and culture of the area. Ideal for history buffs. Duration: 4 hours.",
                    Price = 159.99m
                },
                new TourPackage
                {
                    Id = 9,
                    PackageName = "Sunset Cruise",
                    Description = "Experience a breathtaking sunset on a luxury cruise. Enjoy stunning views, delicious refreshments, and a relaxing atmosphere. Perfect for couples and families. Duration: 2 hours.",
                    Price = 399.99m
                }
                );

            modelBuilder.Entity<TourPackageGuide>().HasData(
                new TourPackageGuide { TourPackageId = 1, GuideId = 1 },
                new TourPackageGuide { TourPackageId = 1, GuideId = 2 },
                new TourPackageGuide { TourPackageId = 1, GuideId = 3 },
                new TourPackageGuide { TourPackageId = 2, GuideId = 4 },
                new TourPackageGuide { TourPackageId = 2, GuideId = 5 },
                new TourPackageGuide { TourPackageId = 2, GuideId = 6 },
                new TourPackageGuide { TourPackageId = 3, GuideId = 7 },
                new TourPackageGuide { TourPackageId = 3, GuideId = 8 },
                new TourPackageGuide { TourPackageId = 3, GuideId = 9 },
                new TourPackageGuide { TourPackageId = 4, GuideId = 10 },
                new TourPackageGuide { TourPackageId = 4, GuideId = 1 },
                new TourPackageGuide { TourPackageId = 4, GuideId = 2 },
                new TourPackageGuide { TourPackageId = 5, GuideId = 3 },
                new TourPackageGuide { TourPackageId = 5, GuideId = 4 },
                new TourPackageGuide { TourPackageId = 5, GuideId = 5 },
                new TourPackageGuide { TourPackageId = 6, GuideId = 6 },
                new TourPackageGuide { TourPackageId = 6, GuideId = 7 },
                new TourPackageGuide { TourPackageId = 6, GuideId = 8 },
                new TourPackageGuide { TourPackageId = 7, GuideId = 9 },
                new TourPackageGuide { TourPackageId = 7, GuideId = 10 },
                new TourPackageGuide { TourPackageId = 7, GuideId = 1 },
                new TourPackageGuide { TourPackageId = 8, GuideId = 2 },
                new TourPackageGuide { TourPackageId = 8, GuideId = 3 },
                new TourPackageGuide { TourPackageId = 8, GuideId = 4 },
                new TourPackageGuide { TourPackageId = 9, GuideId = 5 },
                new TourPackageGuide { TourPackageId = 9, GuideId = 6 },
                new TourPackageGuide { TourPackageId = 9, GuideId = 7 }
                );
        }
    }
}
