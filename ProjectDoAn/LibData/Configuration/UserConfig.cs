using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibData.Configuration
{
    public class UserConfig
    {
        public enum Role
        {
            ADMIN = 1,
            MANAGER = 2,
            CUSTOMER = 9
        }
        public enum Status
        {
            ACTIVE = 1,
            LOCK = 2,
         
        }
        public static Dictionary<int, string> StatusToDictionarySelect = new Dictionary<int, string>()
        {
            {(int)Status.ACTIVE, "Hoạt động" },
            {(int)Status.LOCK, "Khóa" },
        };
        public static Dictionary<int, string> RoleToDictionaryHTML = new Dictionary<int, string>()
        {
            {-1, "Tất cả" },
            {(int)Role.ADMIN, "Admin" },
            {(int)Role.MANAGER, "Manager" },
            {(int)Role.CUSTOMER, "Customer" },
        };
        public static int MALE_INT = 1;
        public static int FEMALE_INT = 2;
        public static Dictionary<int, string> StatusToDictionarySex = new Dictionary<int, string>()
        {
              {MALE_INT, "Nam" },
            {FEMALE_INT, "Nữ" },
        };
    }
}
