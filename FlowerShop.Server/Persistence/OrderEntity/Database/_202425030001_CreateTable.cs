using FluentMigrator;

namespace FlowerShop.Server.Models.OrderEntity.Database
{
    public class _202425030001_CreateTable : Migration
    {
        readonly string tableName = nameof(Models.OrderEntity);

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
                    .WithColumn(nameof(OrderEntity.id)).AsGuid().NotNullable().PrimaryKey()
                    .WithColumn(nameof(OrderEntity.AdditionalComment)).AsString().NotNullable()
                    .WithColumn(nameof(OrderEntity.OrderDate)).AsDateTime().Nullable()
                    .WithColumn(nameof(OrderEntity.TotalAmount)).AsDouble().Nullable()
                    .WithColumn("UserId").AsGuid().NotNullable()
                ;
                Create.ForeignKey("FK_User_Order").FromTable("OrderEntity").ForeignColumn("UserId").ToTable("AspNetUsers").PrimaryColumn("id");

            }
        }
    }
}
