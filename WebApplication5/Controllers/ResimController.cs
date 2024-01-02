using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class ResimController : Controller
    {
        bakkalEntities baglan = new bakkalEntities();
        // GET: Resim
        public ActionResult Index()
        {
            var liste = baglan.Resimler.ToList();
            return View(liste);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Resimler gelen,HttpPostedFileBase Resim)
        {
            Random rastgele = new Random();
            int yeni_isim = rastgele.Next(10000, 100000);
            if (Resim != null && Resim.ContentLength > 0)
            {
                string uzanti = Path.GetExtension(Resim.FileName);
                if (uzanti.ToLower().Equals(".jpg") || uzanti.ToLower().Equals(".png") || uzanti.ToLower().Equals(".gif") || uzanti.ToLower().Equals(".jpeg"))
                {
              string yol = Path.Combine(Server.MapPath("/Musteri_Resim/" + yeni_isim + uzanti));
                    Resim.SaveAs(yol);
                    gelen.Resim_Ad =yeni_isim+uzanti;
                    gelen.Musteri_Id = 1;
                    baglan.Resimler.Add(gelen);
                    baglan.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }

            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var bul = baglan.Resimler.Find(id);
            return View(bul);
        }
    }
}