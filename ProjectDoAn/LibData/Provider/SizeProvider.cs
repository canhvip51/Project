using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibData.Provider
{
    public class SizeProvider : ApplicationDbContexts
    {
        public List<Size> GetAll()
        {
            try
            {
                return ApplicationDbContext.Sizes.OrderBy(x => x.Id).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<Size> GetAllBySex(int sex)
        {
            try
            {
                return ApplicationDbContext.Sizes.Where(x => x.Type.Value == sex).OrderBy(x => x.Id).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
