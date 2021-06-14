using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibData.Provider
{
    public class ConfigProvider : ApplicationDbContexts
    {
        public string GetTimeOut_Hours_Cookie()
        {
            return ApplicationDbContext.Configs.FirstOrDefault(x => x.Name == "TIMEOUT_COOKIE_HOURS").Value;
        }
        public string GetDefault_Pass()
        {
            return ApplicationDbContext.Configs.FirstOrDefault(x => x.Name == "DEFAULT_PASS").Value;
        }
    }
}
