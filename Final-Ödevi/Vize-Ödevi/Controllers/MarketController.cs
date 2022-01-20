using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vize;

namespace Vize_Ödevi.Controllers
{
    public class MarketController : Controller  //Veri üzerinde yacapımız işlemler için ayrı Contoller'lar oluşturduk
    {

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Listele()  //Listeleme için Listele işlemi oluşturduk ve gerekli kodları yazdık.
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var Marketler = session.Query<Models.Market>().ToList();
                return View(Marketler);
            }

        }
        public IActionResult Yeni()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Yeni(Models.Market markt)   //Yeni kayıt eklemek için oluşturduğumuz Razor View için gerekli kodları ekledik.
        {

            using (var session = NhibernateHelper.OpenSession())
            {
                var market = new Models.Market();
                market.urunAd = markt.urunAd;
                market.tedarikciId = markt.tedarikciId;
                market.alisFiyat = markt.alisFiyat;
                market.satisFiyat = markt.satisFiyat;
                session.SaveOrUpdate(markt);
                session.Flush();
            }
            return RedirectToAction("Listele");
        }

        public IActionResult Detay(int id) //Listemizdeki verinin detayını görmek için detay adında işlem yaptırdık.
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var r = session.Query<Models.Market>().FirstOrDefault(x => x.Id == id);
                return View(r);

            }
        }


        public IActionResult Guncelle(int id)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var r = session.Query<Models.Market>().FirstOrDefault(x => x.Id == id);
                return View(r);
            }
        }

        [HttpPost]  //Listemizdeki herhangi bir veri üzerinde güncelleme yapabilmek için güncelle işlemi oluşturduktan sonra gerekli kodları ekledik.

        public IActionResult Guncelle(Models.Market Mrkt)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var r = session.Query<Models.Market>().FirstOrDefault(x => x.Id == Mrkt.Id);
                r.urunAd = Mrkt.urunAd;
                r.tedarikciId = Mrkt.tedarikciId;
                r.alisFiyat = Mrkt.alisFiyat;
                r.satisFiyat = Mrkt.satisFiyat;
                session.SaveOrUpdate(r);
                session.Flush();
            }

            return RedirectToAction("Listele");
        }


        public IActionResult Sil(int id) //Listeden Veri silebilmek için Sil işlemi oluşturduk.
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var r = session.Query<Models.Market>().FirstOrDefault(x => x.Id == id);
                return View(r);


            }

        }

        [HttpPost]

        public IActionResult Sil(Models.Market Mrkt)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var r = session.Query<Models.Market>().FirstOrDefault(x => x.Id == Mrkt.Id);
                session.Delete(r);
                session.Flush();


            }
            return RedirectToAction("Listele");


        }




    }
}
