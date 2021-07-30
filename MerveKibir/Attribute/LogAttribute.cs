using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MerveKibir.Attribute
{
    public class LogAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
            DataModel.VeriModel1 model = new DataModel.VeriModel1();
            Log  logBilgi= new Log();
            logBilgi.Tarih = DateTime.Now;
            logBilgi.Metot = filterContext.ActionDescriptor.ActionName;
            logBilgi.Ip = filterContext.HttpContext.Request.UserHostAddress;
            logBilgi.Tarayıcı = filterContext.HttpContext.Request.Browser.Browser;
            model.Log.Add(logBilgi);
            model.SaveChanges();

        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            DataModel.VeriModel1 model = new DataModel.VeriModel1();
            Log logBilgi = new Log();
            logBilgi.Tarih = DateTime.Now;
            logBilgi.Metot = filterContext.ActionDescriptor.ActionName;
            logBilgi.Ip = filterContext.HttpContext.Request.UserHostAddress;
            logBilgi.Tarayıcı = filterContext.HttpContext.Request.Browser.Browser;
            model.Log.Add(logBilgi);
            model.SaveChanges();
        }
    }
}