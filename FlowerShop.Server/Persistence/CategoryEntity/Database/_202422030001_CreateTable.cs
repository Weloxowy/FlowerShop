using FluentMigrator;

namespace FlowerShop.Server.Models.CategoryEntity.Database
{
    [Migration(202422030001)]
    public class _202422030001_CreateTable : Migration
    {
        readonly string tableName = nameof(Models.CategoryEntity);

        public override void Down()
        {
            if (Schema.Table(tableName).Exists())
            {
                Delete.Table(tableName);
            };
        }

        public override void Up()
        {
            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                    .WithColumn(nameof(CategoryEntity.id)).AsGuid().NotNullable().PrimaryKey()
                    .WithColumn(nameof(CategoryEntity.Name)).AsString().NotNullable()
                    .WithColumn(nameof(CategoryEntity.URLName)).AsString().NotNullable()
                    .WithColumn(nameof(CategoryEntity.Description)).AsString().NotNullable()
                    .WithColumn(nameof(CategoryEntity.ImageLink)).AsString().NotNullable()
                    ;

            }
        }
    }
}
