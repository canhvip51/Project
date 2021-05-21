using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Website.Business
{

    public class OrderList
    {

        public void AddCart(int id)
        {
            try
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["orderlist"];
                if (cookie == null)
                {
                    cookie = new HttpCookie("orderlist");
                }

                if (cookie["list"] == null)
                {
                    cookie["list"] = id.ToString();
                    cookie["amount"] = "1";
                }
                else
                {
                    string list = cookie["list"];
                    string amount = cookie["amount"];
                    List<string> listO = list.Split(',').ToList();
                    List<string> listA = amount.Split(',').ToList();
                    //int value;

                    if (listO.Contains(id.ToString()))
                    {

                        for (int i = 0; i < listO.Count; i++)
                        {
                            //if (int.TryParse(listO[i], out value))
                            if (Int32.Parse(listO[i]) == id)
                            {
                                listA[i] = (Int32.Parse(listA[i]) + 1).ToString();
                                break;
                            }
                        }
                        cookie["amount"] = string.Join(",", listA);
                    }
                    else
                    {

                        cookie["list"] += "," + id.ToString();
                        cookie["amount"] += ",1";
                    }
                }
                cookie.Expires = DateTime.Now.AddDays(30);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            catch (Exception)
            {
            }
        }
        public void DeleteProduct(int id)
        {
            try
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["orderlist"];
                if (cookie == null)
                {
                    return;
                }
                string list = cookie["list"];
                string amount = cookie["amount"];
                List<string> listO = list.Split(',').ToList();
                List<string> listA = amount.Split(',').ToList();
                //int value;
                if (listO.Contains(id.ToString()))
                {

                    for (int i = 0; i < listO.Count; i++)
                    {
                        //if (int.TryParse(listO[i], out value))
                        if (Int32.Parse(listO[i]) == id)
                        {
                            listA[i] = "";
                            listO[i] = "";
                            break;
                        }
                    }
                    cookie["list"] = string.Join(",", listA);
                    cookie["amount"] = string.Join(",", listA);
                }
                cookie.Expires = DateTime.Now.AddDays(30);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            catch (Exception)
            {
            }
        }
        public void Order()
        {
            try
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["orderlist"];
                if (cookie == null)
                {
                    return;
                }
                cookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            catch (Exception)
            {
            }
        }
        public CookieOrder GetCookieOrder()
        {
            try
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["orderlist"];

                if (cookie != null)
                {
                    string list = cookie["list"];
                    string amount = cookie["amount"];
                    List<int> listO = list.Split(',').Select(int.Parse).ToList();
                    List<int> listA = amount.Split(',').Select(int.Parse).ToList();

                    CookieOrder cookieOrder = new CookieOrder()
                    {
                        list = listO,
                        amount = listA,
                    };
                    return cookieOrder;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
    public class CookieOrder
    {
        public List<int> list { get; set; }
        public List<int> amount { get; set; }
    }
}