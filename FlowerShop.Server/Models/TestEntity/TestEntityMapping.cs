using FluentNHibernate.Mapping;

namespace FlowerShop.Server.Models;

public class TestEntityMapping : ClassMap<TestEntity> //Tworzenie mapowania danych dla NHibernate
{
    private readonly string tablename = nameof(TestEntity);

    public TestEntityMapping()
    {
        Id(x => x.id).GeneratedBy.Guid();
        Map(x => x.Name);
        Table(tablename);
    }
}