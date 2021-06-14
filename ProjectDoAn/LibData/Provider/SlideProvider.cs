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
                return ApplicationDbContext.Slides.Where(x=>x.IsDelete==0||x.IsDelete==null).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public int CountAll()
        {
            try
            {
                return ApplicationDbContext.Slides.Count(x => x.IsDelete == 0 || x.IsDelete == null);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public List<Slide> GetAllByStatus(int status)
        {
            try
            {
                return ApplicationDbContext.Slides.Where(x => (x.IsDelete == 0 || x.IsDelete == null) && (status != -1 ? x.Status == status : true)).OrderBy(x => x.OrderNumber).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<Slide> GetAllByStatus(int status,int skip, int size)
        {
            try
            {
                return ApplicationDbContext.Slides.Where(x => (x.IsDelete == 0 || x.IsDelete == null)&&(status!=-1?x.Status==status:true)).OrderBy(x=>x.OrderNumber).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public int CountAllByStatus(int status)
        {
            try
            {
                return ApplicationDbContext.Slides.Count(x => (x.IsDelete == 0 || x.IsDelete == null) && (status != -1 ? x.Status == status : true));
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public Slide GetById(int id)
        {
            try
            {
                return ApplicationDbContext.Slides.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public bool Insert(Slide model)
        {
            try
            {
                ApplicationDbContext.Slides.Add(model);
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Update()
        {
            try
            {
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Delete(Slide slide)
        {
            try
            {
                ApplicationDbContext.Slides.Remove(slide);
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
