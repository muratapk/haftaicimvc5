using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class BakkalController : Controller
    {
        bakkalEntities baglan = new bakkalEntities();

        // GET: Bakkal
        public ActionResult Index()
        {
            var listem = baglan.musteri.ToList();
            return View(listem);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(musteri gelen)
        {
            baglan.musteri.Add(gelen);
            baglan.SaveChanges();
            TempData["Success"] = "Yeni Kayıt Yapıldı";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var bul = baglan.musteri.Find(id);
            return View(bul);
        }
        [HttpPost]
        public ActionResult Edit(musteri gelen)
        {
            var bul = baglan.musteri.Find(gelen.musteri_Id);
            bul.musteri_adi = gelen.musteri_adi;
            bul.musteri_adres=gelen.musteri_adres;
            bul.musteri_kul = gelen.musteri_kul;
            bul.musteri_sifre = gelen.musteri_sifre;
            baglan.SaveChanges();
            TempData["Success"] = "Kayıt Güncellendi";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var bul = baglan.musteri.Find(id);
            return View(bul);
        }
        [HttpPost]
        public ActionResult Delete(musteri gelen)
        {
            var bul = baglan.musteri.Find(gelen.musteri_Id);
            baglan.musteri.Remove(bul);
            baglan.SaveChanges();
            TempData["Success"] = "Kayıt Silindi";
            return RedirectToAction("Index");
        }
    }
}