using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using FlowerShop.Server.Models;
using FlowerShop.Server.Models.UserEntity;
using FlowerShop.Server.Models.AddressEntity;
using FlowerShop.Server.Models.ProductEntity;
using FlowerShop.Server.Models.OrderEntity;
using FlowerShop.Server.Models.CategoryEntity;
using FlowerShop.Server.Models.OrderDetailsEntity;
using FlowerShop.Server.Models.CompanyEntity;

namespace FlowerShop.Server;

public class NHibernateHelper
{
     private static ISessionFactory _sessionFactory;

        public static NHibernate.ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = Fluently.Configure()
                        .Database(
                            MsSqlConfiguration.MsSql2012.ConnectionString("Server=localhost\\SQLEXPRESS;Database=Kwiaciarnia;Integrated Security=SSPI;Application Name=Kwiaciarnia;TrustServerCertificate=true;")
                        )//TODO NAZWA DLA BAZY DANYCH NA TEN MOMENT TO Kwiaciarnia 
                       /* .Mappings(m =>
                            m.FluentMappings.AddFromAssemblyOf<KlientEntity>()
                        ) Przykład mapowania TODO NIE ZAPOMINAĆ O MAPOWANIACH KOLEDZY*/ 
                        .Mappings(m =>
                            m.FluentMappings.AddFromAssemblyOf<TestEntity>())
                        .Mappings(m =>
                            m.FluentMappings.AddFromAssemblyOf<UserEntity>().AddFromAssemblyOf<UserRank>())
                         .Mappings(m =>
                            m.FluentMappings.AddFromAssemblyOf<AddressEntity>())
                         .Mappings(m =>
                            m.FluentMappings.AddFromAssemblyOf<CompanyEntity>())
                         .Mappings(m =>
                            m.FluentMappings.AddFromAssemblyOf<CategoryEntity>())
                         .Mappings(m =>
                            m.FluentMappings.AddFromAssemblyOf<ProductEntity>().AddFromAssemblyOf<Unit>())
                         .Mappings(m =>
                            m.FluentMappings.AddFromAssemblyOf<OrderEntity>())
                         .Mappings(m =>
                            m.FluentMappings.AddFromAssemblyOf<OrderDetailsEntity>())
                        .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                        .BuildSessionFactory();


                }
                return _sessionFactory;
            }
        }
}