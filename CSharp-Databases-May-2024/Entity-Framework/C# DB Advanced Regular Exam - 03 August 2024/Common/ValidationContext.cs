using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Common
{
    public static class ValidationContext
    {
        //Customer
        public const byte CustomerFullNameMinLength = 4;
        public const byte CustomerFullNameMaxLength = 60;
        public const byte CustomerEmailMinLength = 6;
        public const byte CustomerEmailMaxLength = 50;
        public const string CustomerPhoneNumberRegex = @"^\+\d{12}$";

        //Booking

        //Guide
        public const byte GuideFullNameMinLength = 4;
        public const byte GuideFullNameMaxLength = 60;

        //TourPackage
        public const byte TourPackagePackageNameMinLength = 2;
        public const byte TourPackagePackageNameMaxLength = 40;
        public const byte TourPackageDescriptionMaxLength = 200;
        public const string TourPackagePriceMinValue = "0.01";
        public const string TourPackagePriceMaxValue = "79228162514264337593543950335";
    }
}
