using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace İslemKatmani.Models
{
    public class DuyuruView
    {
        public int No { get; set; }
        public string Baslik { get; set; }
        public string Metin { get; set; }
        public DateTime GondermeTarihi { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
    }
}
