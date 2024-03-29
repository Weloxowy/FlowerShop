using FluentMigrator;

namespace FlowerShop.Server.Persistence.UserEntity.Database.Migrations
{
    [Migration(20240329000000)] // Change the version number as per your requirement
    public class InitialCreate : Migration
    {
        public override void Up()
        {
            Create.Table("AspNetUsers")
                .WithColumn("Id").AsString().NotNullable().PrimaryKey()
                .WithColumn("UserName").AsString()
                .WithColumn("NormalizedUserName").AsString()
                .WithColumn("Email").AsString()
                .WithColumn("NormalizedEmail").AsString()
                .WithColumn("EmailConfirmed").AsBoolean()
                .WithColumn("PasswordHash").AsString()
                .WithColumn("SecurityStamp").AsString()
                .WithColumn("ConcurrencyStamp").AsString()
                .WithColumn("PhoneNumber").AsString()
                .WithColumn("PhoneNumberConfirmed").AsBoolean()
                .WithColumn("TwoFactorEnabled").AsBoolean()
                .WithColumn("LockoutEnd").AsDateTimeOffset().Nullable()
                .WithColumn("LockoutEnabled").AsBoolean()
                .WithColumn("AccessFailedCount").AsInt32()
                .WithColumn(nameof(Models.UserEntity.UserEntity.Name)).AsString().Nullable()
                .WithColumn(nameof(Models.UserEntity.UserEntity.Surname)).AsString().Nullable()
                .WithColumn(nameof(Models.UserEntity.UserEntity.TelephoneNumber)).AsString().Nullable()
                .WithColumn(nameof(Models.UserEntity.UserEntity.EmailAddress)).AsString().Nullable()
                .WithColumn(nameof(Models.UserEntity.UserEntity.Login)).AsString().Nullable()
                .WithColumn(nameof(Models.UserEntity.UserEntity.Password)).AsString().Nullable()
                .WithColumn(nameof(Models.UserEntity.UserEntity.IsUserProfileBlocked)).AsBoolean().Nullable()
                .WithColumn(nameof(Models.UserEntity.UserEntity.IsUserProfileConfirmed)).AsBoolean().Nullable()
                .WithColumn(nameof(Models.UserEntity.UserEntity.UserRank)).AsInt32().Nullable();

            // Add more CreateTable statements if necessary for other tables
        }

        public override void Down()
        {
            Delete.Table("AspNetUsers");

            // Add more DeleteTable statements if necessary for other tables
        }
    }
}