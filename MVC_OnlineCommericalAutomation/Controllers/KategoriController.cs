﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_OnlineCommericalAutomation.Models.Sınıflar;

namespace MVC_OnlineCommericalAutomation.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Kategoris.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori k)
        {
            c.Kategoris.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var ktg = c.Kategoris.Find(id);
            c.Kategoris.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir (int id)
        {
            var kategori = c.Kategoris.Find(id);
            return View("KategoriGetir",kategori);
        }
        public ActionResult KategoriGuncelle(Kategori kategori)
        {
            var updatedKategori = c.Kategoris.Find(kategori.KategoriID);
            updatedKategori.KategoriAD = kategori.KategoriAD;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
    
}