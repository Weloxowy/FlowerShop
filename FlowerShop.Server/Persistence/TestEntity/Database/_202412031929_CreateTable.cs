using FluentMigrator;

namespace FlowerShop.Server.Persistence.TestEntity.Database;
[Migration(202412031929)]
public class _202412031929_CreateTable : Migration
{
    readonly string tableName = nameof(Models.TestEntity);
    public override void Up()
    {
        if (!Schema.Table(tableName).Exists())
        {
            Create.Table(tableName)
                .WithColumn(nameof(Models.TestEntity.id)).AsGuid().NotNullable().PrimaryKey()
                .WithColumn(nameof(Models.TestEntity.Name)).AsString().NotNullable();
            
        }
    }

    public override void Down()
    {
        if (Schema.Table(tableName).Exists())
        {
            Delete.Table(tableName);
        };
    }
}