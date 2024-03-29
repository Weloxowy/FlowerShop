using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Mapping;

namespace FlowerShop.Server.Models.OrderEntity
{
    public class OrderEntityMapping : ClassMap<OrderEntity>
    {
        readonly string tablename = nameof(OrderEntity);

        public OrderEntityMapping()
        {
            Id(x => x.id).GeneratedBy.Guid();
            Map(x => x.OrderDate);
            Map(x => x.AdditionalComment);
            Map(x => x.TotalAmount);
            Map(x => x.User);
            Table(tablename);
        }
    }
}
