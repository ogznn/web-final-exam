using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vize;

namespace Vize_Ödevi.Controllers
{
    public class siparislerController : Controller  //Veri üzerinde yacapımız işlemler için ayrı Contoller'lar oluşturduk
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listele()  //Listeleme için Listele işlemi oluşturduk ve gerekli kodları yazdık.
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var Siparisler = session.Query<Models.Siparisler>().ToList();
                return View(Siparisler);
            }

        }
        public IActionResult Yeni()
        {
            return View();
        }

        [HttpPost]         //Yeni kayıt eklemek için oluşturduğumuz Razor View için gerekli kodları ekledik.


        public IActionResult Yeni(Models.Siparisler Siparis)
        {

            using (var session = NhibernateHelper.OpenSession())
            {
                var siparis = new Models.Siparisler();
                siparis.urunId = Siparis.urunId;
                siparis.musteriId = Siparis.musteriId;
                siparis.tarih = Siparis.tarih;
                session.SaveOrUpdate(Siparis);
                session.Flush();

            }
            return RedirectToAction("Listele");
        }

        public IActionResult Detay(int id)   //Listemizdeki verinin detayını görmek için detay adında işlem yaptırdık.
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var r = session.Query<Models.Siparisler>().FirstOrDefault(x => x.Id == id);
                return View(r);

            }
        }
        public IActionResult Guncelle(int id)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var r = session.Query<Models.Siparisler>().FirstOrDefault(x => x.Id == id);
                return View(r);
            }
        }

        [HttpPost]        //Listemizdeki herhangi bir veri üzerinde güncelleme yapabilmek için güncelle işlemi oluşturduktan sonra gerekli kodları ekledik.
        public IActionResult Guncelle(Models.Siparisler Siparis)
        {

            using (var session = NhibernateHelper.OpenSession())
            {
                var siparis = new Models.Siparisler();
                siparis.urunId = Siparis.urunId;
                siparis.musteriId = Siparis.musteriId;
                siparis.tarih = Siparis.tarih;
                session.SaveOrUpdate(Siparis);
                session.Flush();

            }
            return RedirectToAction("Listele");
        }

        public IActionResult Sil(int id)    //Listeden Veri silebilmek için Sil işlemi oluşturduk.
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var r = session.Query<Models.Siparisler>().FirstOrDefault(x => x.Id == id);
                return View(r);
            }
        }

        [HttpPost]

        public IActionResult Sil(Models.Siparisler siparis)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var r = session.Query<Models.Siparisler>().FirstOrDefault(x => x.Id == siparis.Id);
                session.Delete(r);
                session.Flush();
            }
            return RedirectToAction("Listele");
        }


    }
}
