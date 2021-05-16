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
            SUPERADMIN=1,
            MANAGER=2,
            CUSTOMER=9
        }
        public enum Status
        {
            ACTIVE = 1,
            DEACTIVE = -1,
            ISDELETE = 1,
        }
    }
}
