using System;

namespace FlowerShop.Server.Models;

public class TestEntity
{
    public TestEntity() : base()
    {
        
    }

    public TestEntity(Guid id, string Name)
    {
        this.id = id;
        this.Name = Name;
    }
    public virtual Guid id { get; set; }
    public virtual string Name { get; set; }
}