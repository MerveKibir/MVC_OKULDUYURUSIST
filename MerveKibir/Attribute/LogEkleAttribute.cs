using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MerveKibir.Attribute
{
    public class LogEkleAttribute :ActionFilterAttribute
    {
        //LogAttribute olarak yeniden yazıldı.
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
        //    DataModel.VeriModel model = new DataModel.VeriModel();
        //    DataModel.Log yeniLog = new DataModel.Log();
        //    yeniLog.Metot = filterContext.ActionDescriptor.ActionName;
        //    yeniLog.Ip = filterContext.HttpContext.Request.UserHostAddress;
        //    yeniLog.Tarayıcı = filterContext.HttpContext.Request.Browser.Browser;
        //    yeniLog.Tarih = DateTime.Now;

        //    model.Log.Add(yeniLog);
        //    //model.SaveChanges();
        }
    }
}