using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace İslemKatmani
{
    public class duyuru
    {
        public static List<Models.DuyuruView> DuyuruGetir()
        {
            VeriModel duyuru = new VeriModel();
            var duyuruListe = (from d in duyuru.Duyuru
                               select new Models.DuyuruView
                               {
                                   No=d.No,
                                   Baslik=d.Baslik,
                                   Metin=d.Metin,
                               }).ToList();
            return duyuruListe;
        }


    }
}
