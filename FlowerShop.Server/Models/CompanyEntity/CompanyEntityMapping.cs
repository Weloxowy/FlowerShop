using FluentNHibernate.Mapping;

namespace FlowerShop.Server.Models.CompanyEntity
{
    public class CompanyEntityMapping : ClassMap<CompanyEntity>
    {
        readonly string tablename = nameof(AddressEntity);

        public CompanyEntityMapping() 
        {
            Id(x => x.id).GeneratedBy.Guid();
            Map(x => x.CompanyName);
            Map(x => x.NIP);
            Map(x => x.REGON);
            Map(x => x.CompanyAddress);
            Map(x => x.UserId);
            Table(tablename);
        }
    }
}
