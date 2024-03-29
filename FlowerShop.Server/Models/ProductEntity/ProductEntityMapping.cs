using FlowerShop.Server.Models.UserEntity;
using FluentNHibernate.Mapping;

namespace FlowerShop.Server.Models.ProductEntity
{
    public class ProductEntityMapping : ClassMap<ProductEntity>
    {
        readonly string tablename = nameof(UserEntity);
        public ProductEntityMapping() 
        {
            Id(x => x.id).GeneratedBy.Guid();
            Map(x => x.Name);
            Map(x => x.Description);
            Map(x => x.Price);
            Map(x => x.Unit).CustomType<Unit>();
            Map(x => x.IsAvaible);
            Map(x => x.StockQuantity);
            Map(x => x.ImageUrl);
            Map(x => x.Category);
            
            Table(tablename);
        }
    }
}
