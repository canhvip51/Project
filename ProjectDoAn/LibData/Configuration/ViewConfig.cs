using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibData.Configuration
{
   public static class ViewConfig
    {
        public static string ALL = "All";
        public static string TOPSALE = "TOPSALE";
        public static string PRODUCTNEW = "PRODUCTNEW";
        public static string DISCOUNT = "DISCOUNT";
        public static string MALE = "MALE";
        public static string FEMALE = "FEMALE";
        public static int MALE_INT = 1;
        public static int FEMALE_INT = 2;
        public static Dictionary<string, string> StatusToDictionaryProduct = new Dictionary<string, string>()
        {
            {ALL, "Tất cả" },
            {TOPSALE, "Hot" },
            {PRODUCTNEW, "Sản phẩm mới" },
            {DISCOUNT, "Sản phẩm khuyễn mãi" },
        };
        public static string PRICEUP = "PRICEUP";
        public static string PRICEDOWN = "PROCEDOWN";
        public static string ATOZ = "ATOZ";
        public static string ZTOA = "ZTOA";
        public static Dictionary<string, string> StatusToDictionarySort = new Dictionary<string, string>()
        {
              {ALL, "Sắp xếp" },
            {TOPSALE, "Hot" },
            {PRODUCTNEW, "Sản phẩm mới" },
            {DISCOUNT, "Sản phẩm khuyễn mãi" },
            {PRICEUP, "Giá tăng dần" },
            {PRICEDOWN, "Giá giảm dần" },
            {ATOZ, "A đến Z" },
              {ZTOA, "Z đến A" },
        };
    }

}
