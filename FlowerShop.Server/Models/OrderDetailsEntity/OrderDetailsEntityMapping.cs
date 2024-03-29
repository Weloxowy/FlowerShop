using FluentNHibernate.Mapping;

namespace FlowerShop.Server.Models.OrderDetailsEntity
{
    public class OrderDetailsEntityMapping: ClassMap<OrderDetailsEntity>
    {
        readonly string tablename = nameof(OrderDetailsEntity);

        public OrderDetailsEntityMapping()
        {
            Id(x => x.id).GeneratedBy.Guid();
            Map(x => x.UnitPrice);
            Map(x => x.Product);
            Map(x => x.Order);
            Map(x => x.Qty);
            Table(tablename);
        }
    }
}
