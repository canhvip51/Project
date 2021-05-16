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
        public List<District> GetAddDistricts(int id)
        {
            try
            {
                return ApplicationDbContext.Districts.Where(m=>m.ProvinceId==id).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<Ward> GetAddWard(int id)
        {
            try
            {
                return ApplicationDbContext.Wards.Where(m => m.DistrictId == id).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
