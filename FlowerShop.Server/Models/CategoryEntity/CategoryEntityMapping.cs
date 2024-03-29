using FluentNHibernate.Mapping;

namespace FlowerShop.Server.Models.CategoryEntity
{
    public class CategoryEntityMapping : ClassMap<CategoryEntity>
    {
        readonly string tablename = nameof(CategoryEntity);

        public CategoryEntityMapping()
        {
            Id(x => x.id).GeneratedBy.Guid();
            Map(x => x.Name);
            Map(x => x.URLName);
            Map(x => x.Desc);
            Map(x => x.ImageLink);
            Table(tablename);
        }
    }
}
