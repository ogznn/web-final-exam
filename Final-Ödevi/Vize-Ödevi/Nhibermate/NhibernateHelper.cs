using System.Data;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
//using Core.Models;

namespace Vize
{
    public class NhibernateHelper
    {
        protected static Configuration NhConfiguration;
        protected static ISessionFactory LocalSessionFactory;

        private static ISessionFactory _sessionFactory;

     
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var configuration = ConfigureNhibernate();
                    var mapping = GetMappings();
                    configuration.AddDeserializedMapping(mapping, "VT_Market");
                    SchemaMetadataUpdater.QuoteTableAndColumns(configuration);
                    _sessionFactory = configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }               

        public static Configuration ConfigureNhibernate()
        {

            var configure = new Configuration();
            configure.SessionFactoryName("BuildIt");

            configure.DataBaseIntegration(db =>
            {
                //*** SQL 2012 Express
                db.Dialect<MsSql2012Dialect>();
                db.Driver<SqlClientDriver>();
                db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                db.IsolationLevel = IsolationLevel.ReadCommitted;
                db.ConnectionString = "Server=FURKAN\\FURKAN;Database=VT_Market;User Id=sa;Password=123456";

                db.Timeout = 10;

                //*** Testing Settings
                db.LogFormattedSql = true;
                db.LogSqlInConsole = true;
                db.AutoCommentSql = true;
            });
            return configure;
        }

        protected static HbmMapping GetMappings()
        {
            var mapper = new ModelMapper();
            mapper.AddMapping<Vize_Ödevi.Models.MarketMap>();
            mapper.AddMapping<Vize_Ödevi.Models.MusterilerMap>();
            mapper.AddMapping<Vize_Ödevi.Models.SiparislerMap>();
            mapper.AddMapping<Vize_Ödevi.Models.TedarikciMap>();


            //mapper.AddMapping<Vize_Ödevi.Models.MarketMüdürMap>();
            //mapper.AddMapping<PackageMap>();

            //mapper.CompileMappingForEachExplicitlyAddedEntity().WriteAllXmlMapping();
            var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            return mapping;
        }        
    }
}
