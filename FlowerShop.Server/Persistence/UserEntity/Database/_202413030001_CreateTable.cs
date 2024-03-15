using FluentMigrator;

namespace FlowerShop.Server.Models.UserEntity.Database
{
    [Migration(202413030001)]
    public class _202413030001_CreateTable : Migration
    {
        readonly string tableName = nameof(Models.UserEntity);
        public override void Up()
        {
            if (!Schema.Table(tableName).Exists())
            {
                Create.Table(tableName)
                    .WithColumn(nameof(UserEntity.id)).AsGuid().NotNullable().PrimaryKey()
                    .WithColumn(nameof(UserEntity.Name)).AsString().NotNullable()
                    .WithColumn(nameof(UserEntity.Surname)).AsString().NotNullable()
                    .WithColumn(nameof(UserEntity.TelephoneNumber)).AsString().NotNullable()
                    .WithColumn(nameof(UserEntity.EmailAddress)).AsString().NotNullable()
                    .WithColumn(nameof(UserEntity.Login)).AsString().NotNullable()
                    .WithColumn(nameof(UserEntity.Password)).AsString().Nullable()
                    .WithColumn(nameof(UserEntity.IsUserProfileBlocked)).AsBoolean().NotNullable()
                    .WithColumn(nameof(UserEntity.IsUserProfileConfirmed)).AsBoolean().NotNullable()
                    .WithColumn(nameof(UserEntity.UserRank)).AsInt32().NotNullable()
                    /*
                    .WithColumn(nameof(UserEntity.Address)).AsGuid()
                    .WithColumn(nameof(UserEntity.Payment)).AsGuid()
                    .WithColumn(nameof(UserEntity.Company)).AsGuid()
                    Create.ForeignKey("FK_Address").FromTable(tableName).ForeignColumn("Address").ToTable("AddressEntity").PrimaryColumn("id");
                    Create.ForeignKey("FK_Payment").FromTable(tableName).ForeignColumn("Payment").ToTable("PaymentEntity").PrimaryColumn("id");
                    Create.ForeignKey("FK_Company").FromTable(tableName).ForeignColumn("Company").ToTable("CompanyEntity").PrimaryColumn("id");
                    */
                    ;

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
}
