using FluentMigrator;

namespace FlowerShop.Server.Persistence.UserEntity.Database.Migrations
{
    [Migration(202013030001)] // Change the version number as per your requirement
    public class CreateAspNetUsers : Migration
    {
        public override void Up()
        {
            Create.Table("AspNetUsers")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("UserName").AsString()
                .WithColumn("NormalizedUserName").AsString()
                .WithColumn("Email").AsString()
                .WithColumn("NormalizedEmail").AsString()
                .WithColumn("EmailConfirmed").AsBoolean()
                .WithColumn("PasswordHash").AsString()
                .WithColumn("SecurityStamp").AsString()
                .WithColumn("ConcurrencyStamp").AsString()
                .WithColumn("PhoneNumber").AsString().Nullable()
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
            if (Schema.Table("AspNetUsers").Exists())
            {
                Delete.Table("AspNetUsers");
            };
            

            // Add more DeleteTable statements if necessary for other tables
        }
    }
}