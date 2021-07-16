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
        public Size GetById(int id)
        {
            try
            {
                return ApplicationDbContext.Sizes.FirstOrDefault(x => x.Id==id);
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
                return ApplicationDbContext.Sizes.Where(x =>(sex!=-1? x.Type.Value == sex:true)).OrderBy(x => x.Id).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
