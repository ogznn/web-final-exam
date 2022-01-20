using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vize;


namespace Vize_Ödevi.Controllers
{
    public class musterilerController : Controller //Veri üzerinde yacapımız işlemler için ayrı Contoller'lar oluşturduk
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Listele() //Listeleme için Listele işlemi oluşturduk ve gerekli kodları yazdık.
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var Musteriler = session.Query<Models.Musteriler>().ToList();
                return View(Musteriler);

            }

        }

        public IActionResult Yeni()  //Yeni kayıt eklemek için oluşturduğumuz Razor View için gerekli kodları ekledik.
        {
            return View();
        }

        [HttpPost]

        public IActionResult Yeni(Models.Musteriler musteri)
        {

            using (var session = NhibernateHelper.OpenSession())
            {
                var Musteri = new Models.Musteriler();
                Musteri.musteriAd = musteri.musteriAd;
                Musteri.musteriSoyad = musteri.musteriSoyad;
                Musteri.musteriAdres = musteri.musteriAdres;
                Musteri.musteriTel = musteri.musteriTel;
                Musteri.musteriUrunId = musteri.musteriUrunId;
                session.SaveOrUpdate(musteri);
                session.Flush();

            }

            return RedirectToAction("Listele");

        }

        public IActionResult Detay(int id)   //Listemizdeki verinin detayını görmek için detay adında işlem yaptırdık.
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var r = session.Query<Models.Musteriler>().FirstOrDefault(x => x.Id == id);
                return View(r);

            }
        }
        public IActionResult Guncelle(int id)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var r = session.Query<Models.Musteriler>().FirstOrDefault(x => x.Id == id);
                return View(r);
            }
        }

        [HttpPost]  //Listemizdeki herhangi bir veri üzerinde güncelleme yapabilmek için güncelle işlemi oluşturduktan sonra gerekli kodları ekledik.

        public IActionResult Guncelle(Models.Musteriler musteri)
        {

            using (var session = NhibernateHelper.OpenSession())
            {
                var Musteri = new Models.Musteriler();
                Musteri.musteriAd = musteri.musteriAd;
                Musteri.musteriSoyad = musteri.musteriSoyad;
                Musteri.musteriAdres = musteri.musteriAdres;
                Musteri.musteriTel = musteri.musteriTel;
                Musteri.musteriUrunId = musteri.musteriUrunId;
                session.SaveOrUpdate(musteri);
                session.Flush();

            }

            return RedirectToAction("Listele");

        }
        public IActionResult Sil(int id)     //Listeden Veri silebilmek için Sil işlemi oluşturduk.
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var r = session.Query<Models.Musteriler>().FirstOrDefault(x => x.Id == id);
                return View(r);


            }

        }

        [HttpPost]

        public IActionResult Sil(Models.Musteriler Mrkt)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var r = session.Query<Models.Musteriler>().FirstOrDefault(x => x.Id == Mrkt.Id);
                session.Delete(r);
                session.Flush();


            }
            return RedirectToAction("Listele");


        }



    }
}
