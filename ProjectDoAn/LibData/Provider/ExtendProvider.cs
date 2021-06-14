using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibData.Provider
{
     public class ExtendProvider : ApplicationDbContexts
    {
        public List<Province> GetAddProvice()
        {
            try
            {
                return ApplicationDbContext.Provinces.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    
    }
}
