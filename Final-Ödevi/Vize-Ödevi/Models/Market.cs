using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vize_Ödevi.Models
{
    public class Market  //SQl'den veriyi çekebilmek için class'ı oluşturduk.
    {
        public virtual int Id { get; set; }
        public virtual string urunAd { get; set; }
        public virtual int tedarikciId { get; set; } //OLuşturduğumuz class'ı veri tabanındaki gerekli değişkenlerle atadık.
        public virtual int alisFiyat { get; set; }
        public virtual int satisFiyat { get; set; }


    }

    public class MarketMap : ClassMapping<Market>
    {
        public MarketMap() //Veriyi çekebilmek için gerekli kodları yazdık.
        {
            Table("tbl_urunler");
            Id(x => x.Id, m => m.Generator(Generators.Native));
            Property(x => x.urunAd, c => c.Length(50));
            Property(x => x.tedarikciId, c => c.Length(50));
            Property(x => x.alisFiyat);
            Property(x => x.satisFiyat);

        }
    }
}
