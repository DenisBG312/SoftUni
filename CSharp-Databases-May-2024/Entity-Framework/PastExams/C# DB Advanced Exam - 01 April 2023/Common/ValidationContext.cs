using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Common
{
    public static class ValidationContext
    {
        //Boardgame
        public const byte BoardgameNameMinLength = 10;
        public const byte BoardgameNameMaxLength = 20;
        public const double BoardgameRatingMinLength = 1;
        public const double BoardgameRatingMaxLength = 10.00;
        public const int BoargameYearPublishedMinLength = 2018;
        public const int BoargameYearPublishedMaxLength = 2023;

        //Seller
        public const byte SellerNameMinLength = 5;
        public const byte SellerNameMaxLength = 20;
        public const byte SellerAddressMinLength = 2;
        public const byte SellerAddressMaxLength = 30;
        public const string SellerWebsiteRegex = @"^www\.[a-zA-Z0-9-]+\.com$";

        //Creator
        public const byte CreatorFirstNameMinLength = 2;
        public const byte CreatorFirstNameMaxLength = 7;
        public const byte CreatorLastNameMinLength = 2;
        public const byte CreatorLastNameMaxLength = 7;
    }
}
