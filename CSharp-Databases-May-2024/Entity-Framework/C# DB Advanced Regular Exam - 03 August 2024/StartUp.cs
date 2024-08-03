using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using TravelAgency.Data;

namespace TravelAgency
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            TravelAgencyContext context = new TravelAgencyContext();

            //ResetDatabase(context, shouldDropDatabse: true);

            var projectDir = GetProjectDirectory();

            //ImportEntities(context, projectDir + @"Datasets/", projectDir + @"ImportResults/");
            ExportEntities(context, projectDir + @"ExportResults/");

            using (var transaction = context.Database.BeginTransaction())
            {
                transaction.Rollback();
            }
        }

        private static void ExportEntities(TravelAgencyContext context, string exportDir)
        {
            var GuidesWithSpanishLanguageWithAllTheirTourPackages = DataProcessor
                .Serializer.ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(context);
            
            Console
                .WriteLine(GuidesWithSpanishLanguageWithAllTheirTourPackages);
            File
                .WriteAllText(exportDir + "Actual Result - Export Guides With Spanish Language With All Their Tour Packages.xml", GuidesWithSpanishLanguageWithAllTheirTourPackages);

            var CustomersThatHaveBookedHorseRidingTourPackage = DataProcessor
                .Serializer.ExportCustomersThatHaveBookedHorseRidingTourPackage(context);
            
            Console
                .WriteLine(CustomersThatHaveBookedHorseRidingTourPackage);
            File
                .WriteAllText(exportDir + "Actual Result - Export Customers With Their Bookings.json", CustomersThatHaveBookedHorseRidingTourPackage);
        }

        private static void ImportEntities(TravelAgencyContext context, string baseDir, string exportDir)
        {
            var customers = DataProcessor.Deserializer
                .ImportCustomers(context, File.ReadAllText(baseDir + "customers.xml"));
            
            PrintAndExportEntityToFile(customers, exportDir + "Actual Result - Import Customers.txt");

            var bookings = DataProcessor.Deserializer
                .ImportBookings(context, File.ReadAllText(baseDir + "bookings.json"));
            
            PrintAndExportEntityToFile(bookings, exportDir + "Actual Result - Import Bookings.txt");
        }

        private static void PrintAndExportEntityToFile(string entityOutput, string outputPath)
        {
            Console.WriteLine(entityOutput);
            File.WriteAllText(outputPath, entityOutput.TrimEnd());
        }

        private static object GetProjectDirectory()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var directoryName = Path.GetFileName(currentDirectory);
            var relativePath = directoryName.StartsWith("net6.0") ? @"../../../" : string.Empty;

            return relativePath;
        }

        private static void ResetDatabase(TravelAgencyContext context, bool shouldDropDatabse = false)
        {
            if (shouldDropDatabse)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
            else
            {
                if(context.Database.EnsureCreated())
                {
                    return;
                }

                string disableIntegrityChecksQuery = "EXEC sp_MSforeachtable @command1='ALTER TABLE ? NOCHECK CONSTRAINT ALL'";
                context.Database.ExecuteSqlRaw(disableIntegrityChecksQuery);

                string deleteRowsQuery = "EXEC sp_MSforeachtable @command1='SET QUOTED_IDENTIFIER ON;DELETE FROM ?'";
                context.Database.ExecuteSqlRaw(deleteRowsQuery);

                string enableIntegrityChecksQuery = "EXEC sp_MSforeachtable @command1='ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL'";
                context.Database.ExecuteSqlRaw(enableIntegrityChecksQuery);

                string reseedQuery = "EXEC sp_MSforeachtable @command1='IF OBJECT_ID(''?'') IN (SELECT OBJECT_ID FROM SYS.IDENTITY_COLUMNS) DBCC CHECKIDENT(''?'', RESEED, 0)'";
                context.Database.ExecuteSqlRaw(reseedQuery);
            }
        }
    }
}
