using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Areas.Admin.Models
{
    public class DashboardModel
    {
        public List<string> lable { set; get; }
        public List<string> result { set; get; }
        public List<string> color { set; get; }
    }
}