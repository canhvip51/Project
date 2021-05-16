using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibData.Configuration
{
    public class OrderConfig
    {
        public enum Status
        {
            WAIT = 2,
            CONFIRM = 3,
            CANCEL = 4,
            SHIP=5,
            FINISH=6,
            ISDELETE = 1,
        }
    }
}
