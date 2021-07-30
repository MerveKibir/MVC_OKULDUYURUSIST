using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using İslemKatmani;
using DataModel;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Web.Security;
using MerveKibir.Attribute;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace MerveKibir.Controllers
{
    public class AnaController : Controller
    {
        // GET: Ana
        [OturumKontrol]
        public ActionResult Index()
        {
            return View();
        }
        //Wiewden Duyuru Getirme
        public ActionResult DuyuruGetir()
        {
            var liste = İslemKatmani.duyuru.DuyuruGetir();
            return View("DuyuruGetir", liste);
        }

        //Apiden Duyuru Getirme
        public ActionResult ServistenGetir()
        {
            List<Duyuru> liste = new List<Duyuru>();
            string apiUrl = "https://localhost:44341";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);
            var serviceSonuc = client.GetAsync("/api/duyuru/DuyuruyuGetir").Result;

            if (serviceSonuc.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var stringIcerik = serviceSonuc.Content.ReadAsStringAsync().Result;

                JavaScriptSerializer ser = new JavaScriptSerializer();
                liste = ser.Deserialize<List<Duyuru>>(stringIcerik);
            }
            return View("ServistenGetir", liste);
        }

        //Bannerdaki Kutuların İçlerindeki Duyuru Sayılarını Getirme 
        public List<int> ServistenSayiGetir()
        {
            List<Duyuru> liste = new List<Duyuru>();
            string apiUrl = "https://localhost:44341";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);
            var serviceSonuc = client.GetAsync("/api/duyuru/DuyuruyuGetir").Result;
            List<int> sayilar = new List<int>();
            if (serviceSonuc.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var stringIcerik = serviceSonuc.Content.ReadAsStringAsync().Result;
                JavaScriptSerializer ser = new JavaScriptSerializer();
                liste = ser.Deserialize<List<Duyuru>>(stringIcerik);
                VeriModel model = new VeriModel();
                Duyuru duyurusay = new Duyuru();
                sayilar.Add(liste.Count());
                int i = 0;
                foreach (var sayi in liste)
                {
                    if (duyurusay.GonderildiMi == null || duyurusay.GonderildiMi==false)
                    {
                        i++;
                    }
                }
                sayilar.Add(i);
                int toplam=0, sayis = 0;
                foreach (var eleman in liste)
                {
                    if (duyurusay.OlusturmaTarihi > DateTime.Now.AddYears(-1))
                    {
                        sayis++;
                    }
                    toplam = sayis;
                }
                sayilar.Add(toplam);
            }
            return sayilar;
        }

        //Oturum Açma Ekranı
        [HttpGet]
        [Route("Login")]
        public ActionResult Login()
        {
            var oturumCerez = Request.Cookies["Oturum"];
            if (oturumCerez != null)
            {
                oturumCerez.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(oturumCerez);
            }

            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(Models.Kullanici_VM oturumBilgi)
        {
            var kullanici = İslemKatmani.Oturum.KullaniciSorgula(oturumBilgi.KullaniciAdi, oturumBilgi.Parola);
            if (kullanici == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                Models.Kullanici_VM oturumVeri = new Models.Kullanici_VM();
                oturumBilgi.KullaniciAdi = kullanici.KullaniciAdi;
                oturumBilgi.Ad = kullanici.Ad;
                oturumBilgi.Soyad = kullanici.Soyad;
                oturumBilgi.Parola = kullanici.Parola;
                JavaScriptSerializer ser = new JavaScriptSerializer();
                string kullaniciVeri = ser.Serialize(oturumBilgi);
                FormsAuthenticationTicket bilet = new FormsAuthenticationTicket(
                    1,
                    oturumBilgi.KullaniciAdi,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(20), false, kullaniciVeri);
                string sifreBilet = FormsAuthentication.Encrypt(bilet);
                HttpCookie cerez = new HttpCookie("Oturum", sifreBilet);
                cerez.Expires = DateTime.Now.AddMinutes(25);
                Response.Cookies.Add(cerez);
                return RedirectToAction("Index");
            }

        }

        //Kullanıcı Ekleme 
        [HttpGet]
        [OturumKontrol]
        [Log]
        [Route("kullaniciekle")]
        public ActionResult KullaniciEkle()
        {
            return View("KullaniciEkle");
        }
        [HttpPost]
        public ActionResult KullaniciEkle(DataModel.Kullanici yeniKullanici)
        {
            DataModel.VeriModel model = new VeriModel();
            model.Kullanici.Add(yeniKullanici);
            model.SaveChanges();
            return View("KullaniciEkle");
        }

        //Apiden Duyuru Ekleme
        [OturumKontrol]
        [Log]
        public ActionResult DuyuruyuEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DuyuruyuEkle(DataModel.Duyuru yeniDuyuru)
        {


            DataModel.VeriModel model = new DataModel.VeriModel();
            List<Duyuru> liste = new List<Duyuru>();
            string apiUrl = "https://localhost:44341";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);

            JavaScriptSerializer ser = new JavaScriptSerializer();
            var veri = ser.Serialize(yeniDuyuru);
            HttpContent content = new StringContent(veri, Encoding.UTF8, "application/json");
            var sonuc = client.PostAsync("/api/duyuru/DuyuruEkle", content).Result;
            string result = sonuc.Content.ReadAsStringAsync().Result;

            return RedirectToAction("Index");

        }
    }
}