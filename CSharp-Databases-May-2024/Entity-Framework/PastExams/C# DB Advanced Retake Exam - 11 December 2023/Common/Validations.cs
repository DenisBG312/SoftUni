using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cadastre.Common
{
    public static class Validations
    {

        //District
        public const int DistrictNameMinLength = 2;
        public const int DistrictNameMaxLength = 80;
        public const int DistrictPostalCodeLength = 8;
        public const string DistrictPostalCodeRegExpression = @"^[A-Z]{2}-\d{5}$";
        public const int RegionMaxCategoryDigit = 3;

        //Property
        public const int PropertyIdentifierMinLength = 16;
        public const int PropertyIdentifierMaxLength = 20;
        public const int PropertyDetailsMinLength = 5;
        public const int PropertyDetailsMaxLength = 500;
        public const int PropertyAddressMinLength = 5;
        public const int PropertyAddressMaxLength = 200;

        //Citizen
        public const int CitizenFirstNameMinLength = 2;
        public const int CitizenFirstNameMaxLength = 30;
        public const int CitizenLastNameMinLength = 2;
        public const int CitizenLastNameMaxLength = 30;
        public const int CitizenMaritalStatusMaxCategoryDigit = 3;


    }
}
