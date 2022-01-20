using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Vize_Ödevi.Models
{
    public class Tedarikci  //SQl'den veriyi çekebilmek için class'ı oluşturduk.
    {
            public virtual int Id { get; set; }
            public virtual string tedarikciFirma { get; set; }
            public virtual string tedarikciAdres { get; set; }
            public virtual string tedarikciTel { get; set; } //OLuşturduğumuz class'ı veri tabanındaki gerekli değişkenlerle atadık.
        public virtual string tedarikciMail { get; set; }

 }


        public class TedarikciMap : ClassMapping<Tedarikci>
        {
            public TedarikciMap()    //Veriyi çekebilmek için gerekli kodları yazdık.
        {
                Table("tbl_tedarikci");
                Id(x => x.Id, m => m.Generator(Generators.Native));
                Property(x => x.tedarikciFirma, c => c.Length(50));
                Property(x => x.tedarikciAdres, c => c.Length(100));
                Property(x => x.tedarikciTel, c => c.Length(12));
                Property(x => x.tedarikciMail, c => c.Length(50));

            }
        }
   
}
