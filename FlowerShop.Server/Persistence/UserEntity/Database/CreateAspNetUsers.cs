using FluentMigrator;

namespace FlowerShop.Server.Persistence.UserEntity.Database.Migrations
{
    [Migration(202013030001)] // Change the version number as per your requirement
    public class CreateAspNetUsers : Migration
    {
        public override void Up()
        {
            Create.Table("AspNetUsers")
                .WithColumn("Id").AsString().NotNullable().PrimaryKey()
                .WithColumn("UserName").AsString().Nullable()
                .WithColumn("NormalizedUserName").AsString().Nullable()
                .WithColumn("Email").AsString().Nullable()
                .WithColumn("NormalizedEmail").AsString().Nullable()
                .WithColumn("EmailConfirmed").AsBoolean().Nullable()
                .WithColumn("PasswordHash").AsString().Nullable()
                .WithColumn("SecurityStamp").AsString().Nullable()
                .WithColumn("ConcurrencyStamp").AsString().Nullable()
                .WithColumn("PhoneNumber").AsString().Nullable().Nullable()
                .WithColumn("PhoneNumberConfirmed").AsBoolean().Nullable()
                .WithColumn("TwoFactorEnabled").AsBoolean().Nullable()
                .WithColumn("LockoutEnd").AsDateTimeOffset().Nullable()
                .WithColumn("LockoutEnabled").AsBoolean().Nullable()
                .WithColumn("AccessFailedCount").AsInt32().Nullable()
                .WithColumn(nameof(Models.UserEntity.AspNetUsers.FirstName)).AsString().Nullable()
                .WithColumn(nameof(Models.UserEntity.AspNetUsers.Surname)).AsString().Nullable()
                .WithColumn(nameof(Models.UserEntity.AspNetUsers.Password)).AsString().Nullable()
                .WithColumn(nameof(Models.UserEntity.AspNetUsers.IsUserProfileBlocked)).AsBoolean().Nullable()
                .WithColumn(nameof(Models.UserEntity.AspNetUsers.IsUserProfileConfirmed)).AsBoolean().Nullable()
                .WithColumn(nameof(Models.UserEntity.AspNetUsers.UserRank)).AsInt32().Nullable();

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