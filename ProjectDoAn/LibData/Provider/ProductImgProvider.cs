using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibData.Provider
{
   public class ProductImgProvider : ApplicationDbContexts
    {
        public bool Insert(ProductImg model)
        {
            try
            {
                //model.CreateDate = DateTime.Now;
                ApplicationDbContext.ProductImgs.Add(model);
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Update(ProductImg model)
        {
            try
            {
                ProductImg productImg = GetById(model.Id);
                productImg.Color = model.Color;
                productImg.Url = model.Url;
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
       
        public ProductImg GetById(int id)
        {
            try
            {
                return ApplicationDbContext.ProductImgs.Find(id);
            }
            catch (Exception)
            {
                return null;
            }

        }
        public List<ProductImg> GetAll()
        {
            try
            {
                return ApplicationDbContext.ProductImgs.Where(x=> (x.IsDelete != 1 || x.IsDelete == null)).OrderBy(x => x.Id).ToList();
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public List<ProductImg> GetAll(int? projectid)
        {
            try
            {
                return ApplicationDbContext.ProductImgs.Where(x=>(x.IsDelete!=1 || x.IsDelete==null)&&(projectid.HasValue?x.ProductId==projectid:true)).OrderBy(x => x.Id).ToList();
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public List<ProductImg> GetAll(int skip, int size)
        {
            try
            {
                return ApplicationDbContext.ProductImgs.Where(x=> (x.IsDelete != 1 || x.IsDelete == null)).OrderBy(x =>x.Id).Skip(skip).Take(size).ToList();
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
                return ApplicationDbContext.ProductImgs.Count(x=> (x.IsDelete != 1 || x.IsDelete == null));
            }
            catch (Exception e)
            {
                return 0;
            }

        }
        public List<ProductImg> GetAllByProductId(int productid)
        {
            try
            {
                return ApplicationDbContext.ProductImgs.Where(x => (x.IsDelete != 1 || x.IsDelete == null) && x.ProductId.Value == productid).OrderByDescending(x => x.Id).ToList();
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public List<ProductImg> GetAllByProductId(int productid,int skip, int size)
        {
            try
            {
                return ApplicationDbContext.ProductImgs.Where(x=> (x.IsDelete != 1 || x.IsDelete == null) && x.ProductId.Value==productid).OrderByDescending(x => x.Id).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public int CountAllByProductId(int productid)
        {
            try
            {
                return ApplicationDbContext.ProductImgs.Count(x => (x.IsDelete != 1 || x.IsDelete == null) && x.ProductId.Value == productid);
            }
            catch (Exception e)
            {
                return 0;
            }

        }
    }
}
