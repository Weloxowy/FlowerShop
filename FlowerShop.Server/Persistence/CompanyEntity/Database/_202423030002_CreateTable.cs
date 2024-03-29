using FluentMigrator;
namespace FlowerShop.Server.Models.CompanyEntity.Database;

[Migration(202423030002)]
public class _202423030002_CreateTable : Migration
{
    readonly string tableName = nameof(Models.CompanyEntity);

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
                .WithColumn(nameof(Models.CompanyEntity.CompanyEntity.id)).AsGuid().NotNullable().PrimaryKey()
                .WithColumn(nameof(Models.CompanyEntity.CompanyEntity.REGON)).AsString().NotNullable()
                .WithColumn(nameof(Models.CompanyEntity.CompanyEntity.NIP)).AsString().NotNullable()
                .WithColumn(nameof(Models.CompanyEntity.CompanyEntity.CompanyName)).AsString().NotNullable()
                .WithColumn(nameof(Models.CompanyEntity.CompanyEntity.CompanyAddress)).AsGuid().NotNullable()
                .WithColumn(nameof(Models.CompanyEntity.CompanyEntity.User)).AsGuid().NotNullable()
                ;
                Create.ForeignKey("FK_Company_Address").FromTable("CompanyEntity").ForeignColumn("CompanyAddress").ToTable("AddressEntity").PrimaryColumn("id");
                Create.ForeignKey("FK_Company_User").FromTable("CompanyEntity").ForeignColumn("User").ToTable("AspNetUsers").PrimaryColumn("Id");


        }
    }
}