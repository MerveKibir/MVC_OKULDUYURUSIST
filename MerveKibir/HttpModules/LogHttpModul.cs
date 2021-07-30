using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MerveKibir.HttpModules
{
    public class LogHttpModul : IHttpModule
    {
        public void Dispose()
        {
            // throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }
        void context_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication context = (HttpApplication)sender;
            DataModel.VeriModel1 model = new DataModel.VeriModel1();
            Log yenilog = new Log();
            yenilog.Metot = context.Request.HttpMethod;
            yenilog.Ip = context.Request.UserHostAddress;
            yenilog.Tarayıcı = context.Request.UserAgent;
            yenilog.Tarih = DateTime.Now;

            model.Log.Add(yenilog);
            //model.SaveChanges();
        }
    }
}