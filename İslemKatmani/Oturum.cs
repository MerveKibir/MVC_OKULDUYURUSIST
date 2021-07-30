using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace İslemKatmani
{
    public class Oturum
    {
        public static DataModel.Kullanici KullaniciSorgula(string KullaniciAdi, string Parola )
        {
            DataModel.VeriModel model = new DataModel.VeriModel();
            var kullanici = model.Kullanici.FirstOrDefault(k => k.KullaniciAdi == KullaniciAdi && k.Parola == Parola);
            return kullanici;
            }
    }
}
