using FluentMigrator;

namespace FlowerShop.Server.Models.OrderDetailsEntity.Database
{
    public class _202425030001_CreateTable : Migration
    {
        readonly string tableName = nameof(Models.OrderDetailsEntity);

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
                    .WithColumn(nameof(OrderDetailsEntity.id)).AsGuid().NotNullable().PrimaryKey()
                    .WithColumn(nameof(OrderDetailsEntity.UnitPrice)).AsDouble().NotNullable()
                    .WithColumn(nameof(OrderDetailsEntity.Qty)).AsInt32().Nullable()
                    .WithColumn("OrderId").AsGuid().NotNullable()
                    .WithColumn("ProductId").AsGuid().NotNullable()
                ;
                Create.ForeignKey("FK_OrderDetails_Order").FromTable("OrderDetailsEntity").ForeignColumn("OrderId").ToTable("OrderEntity").PrimaryColumn("id");
                Create.ForeignKey("FK_OrderDetails_Product").FromTable("OrderDetailsEntity").ForeignColumn("ProductId").ToTable("ProductEntity").PrimaryColumn("id");

            }
        }
    }
}
