using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibData.Configuration
{
    class ProductConfig
    {
        public enum Type
        {
          MALE=1,
          FEMALE=2,
        }
        public enum Status
        {
            ACTIVE = 1,
            STOPSELL = 2,
            ISDELETE = 1,
        }
    }
}
