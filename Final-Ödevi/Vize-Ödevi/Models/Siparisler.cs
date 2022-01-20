using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Vize_Ödevi.Models
{
    public class Siparisler  //SQl'den veriyi çekebilmek için class'ı oluşturduk.
    {
        public virtual int Id { get; set; }   //OLuşturduğumuz class'ı veri tabanındaki gerekli değişkenlerle atadık.
        public virtual int urunId { get; set; }
        public virtual int musteriId { get; set; }
        public virtual string tarih { get; set; }
    }


    public class SiparislerMap : ClassMapping<Siparisler>
    {
        public SiparislerMap()    //Veriyi çekebilmek için gerekli kodları yazdık.
        {
            Table("tbl_siparisler");
            Id(x => x.Id, m => m.Generator(Generators.Native));
            Property(x => x.urunId);
            Property(x => x.musteriId);
            Property(x => x.tarih);
        }
    }
}
