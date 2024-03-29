using FluentMigrator;

namespace FlowerShop.Server.Models.ProductEntity.Database
{
    [Migration(202424030001)]
    public class _202424030001_CreateTable : Migration
    {
        readonly string tableName = nameof(Models.ProductEntity);

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
                    .WithColumn(nameof(ProductEntity.id)).AsGuid().NotNullable().PrimaryKey()
                    .WithColumn(nameof(ProductEntity.Name)).AsString().NotNullable()
                    .WithColumn(nameof(ProductEntity.Price)).AsDouble().NotNullable()
                    .WithColumn(nameof(ProductEntity.Description)).AsString().NotNullable()
                    .WithColumn(nameof(ProductEntity.StockQuantity)).AsInt32().NotNullable()
                    .WithColumn(nameof(ProductEntity.IsAvaible)).AsBoolean().NotNullable()
                    .WithColumn(nameof(ProductEntity.Unit)).AsInt32().NotNullable()
                    .WithColumn(nameof(ProductEntity.ImageUrl)).AsString(int.MaxValue).NotNullable()
                    .WithColumn("Category").AsGuid().NotNullable()
                ;
                Create.ForeignKey("FK_Category_Product").FromTable("ProductEntity").ForeignColumn("Category").ToTable("CategoryEntity").PrimaryColumn("id");
                
            }
        }
    }
}
