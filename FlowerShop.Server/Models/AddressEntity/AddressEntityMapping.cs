using FluentNHibernate.Mapping;

namespace FlowerShop.Server.Models.AddressEntity
{
public class AddressEntityMapping : ClassMap<AddressEntity>
{
    readonly string tablename = nameof(AddressEntity);
    
    public AddressEntityMapping() 
    {
        Id(x => x.id).GeneratedBy.Guid();
        Map(x => x.FullStreet);
        Map(x => x.PostalCode);
        Map(x => x.City);
        Map(x => x.Voivodeship);
        Map(x => x.Country);
        Map(x => x.UserAddress);
        Table(tablename);
    }
}
}