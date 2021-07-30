using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace İslemKatmani
{
    public class duyurusayaci
    {
        public static int DuyuruSayisiGetir()
        {
            VeriModel duyuru = new VeriModel();
            var duyuruListe = (from d in duyuru.Duyuru
                               select  new Models.DuyuruView
                               {
                                   No = d.No,
                                   
                               }).Count();
            return duyuruListe;
        }
    }
}
