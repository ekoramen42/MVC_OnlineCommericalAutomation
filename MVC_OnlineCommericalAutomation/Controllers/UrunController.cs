using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_OnlineCommericalAutomation.Models.Sınıflar;

namespace MVC_OnlineCommericalAutomation.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index()
        {
            var urunler = c.Uruns.Where(x => x.Durum == true).ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAD,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun urun)
        {
            c.Uruns.Add(urun);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var deger = c.Uruns.Find(id);
            deger.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAD,
                                               Value = x.KategoriID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var urundeger = c.Uruns.Find(id);
            return View("UrunGetir",urundeger);
        }
        public ActionResult UrunGuncelle(Urun urun)
        {
            var urn = c.Uruns.Find(urun.UrunID);
            urn.AlisFiyat = urun.AlisFiyat;
            urn.Durum = urun.Durum;
            urn.Kategoriid = urun.Kategoriid;
            urn.Marka = urun.Marka;
            urn.SatisFiyat = urun.SatisFiyat;
            urn.Stok = urun.Stok;
            urn.UrunAD = urun.UrunAD;
            urn.UrunGorsel = urun.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunListesi()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }
    }
}