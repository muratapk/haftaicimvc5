using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class LoginController : Controller
    {
        bakkalEntities baglan = new bakkalEntities();
        // GET: Login
        public ActionResult Index()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Index(musteri gelen)
        {
            var bul = baglan.musteri.Where(x => x.musteri_kul==gelen.musteri_kul && x.musteri_sifre==gelen.musteri_sifre).FirstOrDefault();
            if (bul != null)
            {
                TempData["Success"] = "Kayıt Başarılı";
                return RedirectToAction("Index","Bakkal");
                
            }
            TempData["Error"] = "Kullanıcı Adı veya Şifre Hatalı";
            return View();
        }
    }
}