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
        public static Dictionary<int, string> StatusToDictionaryHTML = new Dictionary<int, string>()
        {
            {-1, "Tất cả" },
            {(int)Status.WAIT, "Chờ xử lý" },
            {(int)Status.CONFIRM, "Xác nhận" },
            {(int)Status.CANCEL, "Hủy" },
            //{(int)Status.SHIP, "Đang giao" },
            {(int)Status.FINISH, "Hoàn thành" },
        };
    }
}
