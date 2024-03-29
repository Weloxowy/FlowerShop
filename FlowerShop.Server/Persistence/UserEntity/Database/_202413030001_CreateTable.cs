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
                    .WithColumn(nameof(UserEntity.Surname)).AsString().Nullable()
                    .WithColumn(nameof(UserEntity.TelephoneNumber)).AsString().Nullable()
                    .WithColumn(nameof(UserEntity.EmailAddress)).AsString().NotNullable()
                    .WithColumn(nameof(UserEntity.Login)).AsString().Nullable()
                    .WithColumn(nameof(UserEntity.Password)).AsString().Nullable()
                    .WithColumn(nameof(UserEntity.IsUserProfileBlocked)).AsBoolean().Nullable()
                    .WithColumn(nameof(UserEntity.IsUserProfileConfirmed)).AsBoolean().Nullable()
                    .WithColumn(nameof(UserEntity.UserRank)).AsInt32().Nullable()
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
