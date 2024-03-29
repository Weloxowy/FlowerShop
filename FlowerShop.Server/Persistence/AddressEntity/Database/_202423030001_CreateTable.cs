using FluentMigrator;

namespace FlowerShop.Server.Models.AddressEntity.Database;

[Migration(202423030001)]
public class _202423030001_CreateTable : Migration
{
    readonly string tableName = nameof(Models.AddressEntity);

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
                .WithColumn(nameof(AddressEntity.id)).AsGuid().NotNullable().PrimaryKey()
                .WithColumn(nameof(AddressEntity.FullStreet)).AsString().NotNullable()
                .WithColumn(nameof(AddressEntity.PostalCode)).AsString().NotNullable()
                .WithColumn(nameof(AddressEntity.City)).AsString().NotNullable()
                .WithColumn(nameof(AddressEntity.Voivodeship)).AsString().NotNullable()
                .WithColumn(nameof(AddressEntity.Country)).AsString().NotNullable()
                .WithColumn("UserAddress").AsGuid().NotNullable()
                ;
            Create.ForeignKey("FK_User_Address").FromTable("AddressEntity").ForeignColumn("UserAddress").ToTable("UserEntity").PrimaryColumn("id");
        }
    }
}
