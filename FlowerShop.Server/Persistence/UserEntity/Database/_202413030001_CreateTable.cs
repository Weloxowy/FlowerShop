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
                    .WithColumn(nameof(AspNetUsers.FirstName)).AsString().NotNullable()
                    .WithColumn(nameof(AspNetUsers.Surname)).AsString().Nullable()
                    .WithColumn(nameof(AspNetUsers.Password)).AsString().Nullable()
                    .WithColumn(nameof(AspNetUsers.IsUserProfileBlocked)).AsBoolean().Nullable()
                    .WithColumn(nameof(AspNetUsers.IsUserProfileConfirmed)).AsBoolean().Nullable()
                    .WithColumn(nameof(AspNetUsers.UserRank)).AsInt32().Nullable()
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
