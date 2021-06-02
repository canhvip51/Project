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
            WAIT = 1,
            CONFIRM = 2,
            CANCEL = 3,
            SHIP = 4,
            FINISH = 5,
            ISDELETE = 1,
            WAITFORPAY = 0,
        }
        public static Dictionary<int, string> StatusToDictionaryHTML = new Dictionary<int, string>()
        {
            {-1, "Tất cả" },
           // {(int)Status.WAITFORPAY, "Chờ thanh toán" },
            {(int)Status.WAIT, "Chờ xử lý" },
            {(int)Status.CONFIRM, "Xác nhận" },
            {(int)Status.CANCEL, "Hủy" },
            //{(int)Status.SHIP, "Đang giao" },
            {(int)Status.FINISH, "Hoàn thành" },
        };
    }
}
