using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Vize_Ödevi.Models
{
    public class Musteriler  //SQl'den veriyi çekebilmek için class'ı oluşturduk.
    {
        public virtual int Id { get; set; }
        public virtual string musteriAd { get; set; }  //OLuşturduğumuz class'ı veri tabanındaki gerekli değişkenlerle atadık.
        public virtual string musteriSoyad { get; set; }
        public virtual string musteriAdres { get; set; }
        public virtual string musteriTel { get; set; }
        public virtual int musteriUrunId { get; set; }

    }

    public class MusterilerMap : ClassMapping<Musteriler>
    {
        public MusterilerMap() //Veriyi çekebilmek için gerekli kodları yazdık.
        {
            Table("tbl_musteriler");
            Id(x => x.Id, m => m.Generator(Generators.Native));
            Property(x => x.musteriAd, c => c.Length(50));
            Property(x => x.musteriSoyad, c => c.Length(20));
            Property(x => x.musteriAdres, c => c.Length(100));
            Property(x => x.musteriTel, c => c.Length(12));
            Property(x => x.musteriUrunId);
        }
    }
}
