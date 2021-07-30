using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace MerveKibir.Attribute
{
    public class OturumKontrolAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var cerez = filterContext.HttpContext.Request.Cookies["Oturum"];
            if (cerez != null)
            {
                FormsAuthenticationTicket oturumBilet = FormsAuthentication.Decrypt(cerez.Value);
                if (oturumBilet.Expired == true)
                {
                    JavaScriptSerializer ser = new JavaScriptSerializer();
                    var oturumBilgi = ser.Deserialize<Models.Kullanici_VM>(oturumBilet.UserData);
                }

            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Controller = "ana", Action = "Login" }));

            }
        }
    }
}