using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibData.Provider
{
    public class SlideProvider : ApplicationDbContexts
    {
        public List<Slide> GetAll()
        {
            try
            {
                return ApplicationDbContext.Slides.ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
