using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibData.Provider
{
    public class UserProvider:ApplicationDbContexts
    {
        public LibData.User Login(string userName, string password)
        {
            try
            {
                var userInfo = ApplicationDbContext.Users.Where(x => (x.Phone.Equals(userName) || x.UserName.Equals(userName)) && x.Status != (int)Configuration.UserConfig.Status.DEACTIVE && (x.IsDelete == 0 || x.IsDelete == null) && x.Role == (int)Configuration.UserConfig.Role.SUPERADMIN).FirstOrDefault();
                if (userInfo != null)
                {
                    string stringPwd = userInfo.Password.Trim();
                    string passwordHash = Utilities.SecurityHelper.sha256Hash(userInfo.Password.Trim());
                    if (password==stringPwd)
                    {
                        return userInfo;
                    }
                    else if (passwordHash.Equals(password))
                    {
                        userInfo.Password = password;
                        ApplicationDbContext.SaveChanges();
                        return userInfo;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(User model)
        {
            try
            {
                model.CreateDate = DateTime.Now;
                model.Status = 1;
                ApplicationDbContext.Users.Add(model);
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Update(User model)
        {
            try
            {
                User user = GetById(model.Id);
                user.UpdateDate = DateTime.Now;
                user.Phone = model.Phone;
                user.Status = model.Status;
                user.FullName = model.FullName;
                user.Address = model.Address;
                user.Email = model.Email;
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool UpdatePassword(User model)
        {
            try
            {
                User user = GetById(model.Id);
                user.UpdateDate = DateTime.Now;
                user.Password = model.Password;
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Delete( int id)
        {
            try
            {
                User user = GetById(id);
                user.UpdateDate = DateTime.Now;
                user.IsDelete = 1;
                ApplicationDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public User GetById(int id)
        {
            try
            {
                return ApplicationDbContext.Users.Find(id);
            }
            catch (Exception)
            {
                return null;
            }

        }
        public List<User> GetAllByPhone(string phone)
        {
            return ApplicationDbContext.Users.Where(x => x.Phone.Contains(phone)).ToList();
        }
        public List<User> GetAll()
        {
            try
            {
                return ApplicationDbContext.Users.Where(x => x.IsDelete == 0 || x.IsDelete == null).OrderByDescending(x => x.CreateDate).ToList();
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public List<User> GetAllUser(int skip, int size)
        {
            try
            {
                return ApplicationDbContext.Users.Where(x => x.IsDelete == 0 || x.IsDelete == null).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public List<User> GetAllUserByRole(int role, int skip, int size)
        {
            try
            {
                return ApplicationDbContext.Users.Where(x => (x.IsDelete == 0 || x.IsDelete == null) && x.Role == role).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public List<User> GetAllUserByRoleAndKey(string key, int role, int skip, int size)
        {
            try
            {
                return ApplicationDbContext.Users.Where(x => (x.IsDelete == 0 || x.IsDelete == null) && (x.Phone.Contains(key) || x.Email.Contains(key)) && x.Role == role).OrderByDescending(x => x.CreateDate).Skip(skip).Take(size).ToList();
            }
            catch (Exception e)
            {
                return null;
            }

        }
        //Count
        public int CountAll()
        {
            try
            {
                return ApplicationDbContext.Users.Count(x => x.IsDelete == 0 || x.IsDelete == null);
            }
            catch (Exception)
            {
                return 0;
            }

        }
        public int CountAllUserByRole(int role)
        {
            try
            {
                return ApplicationDbContext.Users.Count(x => (x.IsDelete == 0 || x.IsDelete == null) && x.Role == role);
            }
            catch (Exception e)
            {

                return 0;
            }

        }
        public int CountAllUserByRoleAndKey(string key, int role)
        {
            try
            {
                return ApplicationDbContext.Users.Count(x => (x.IsDelete == 0 || x.IsDelete == null) && (x.Phone.Contains(key) || x.Email.Contains(key)) && x.Role == role);
            }
            catch (Exception e)
            {
                return 0;
            }

        }
        //Check
        public bool CheckExistUserName(string username)
        {
            try
            {
                var user = ApplicationDbContext.Users.First(x => x.UserName == username  && (x.IsDelete == 0 || x.IsDelete == null));
                if (user != null)
                    return true;
                else return false;
            }
            catch (Exception e)
            {

                return false;
            }

        }
    }
}
