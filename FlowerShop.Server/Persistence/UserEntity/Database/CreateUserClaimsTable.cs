using FluentMigrator;

namespace FlowerShop.Server.Persistence.UserEntity.Database;

[Migration(20200329150000)] // Unique identifier for the migration
public class CreateUserClaimsTable : Migration
{
    public override void Up()
    {
        Create.Table("AspNetUserClaims")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("UserId").AsString(128).NotNullable()
            .WithColumn("ClaimType").AsString(256).NotNullable()
            .WithColumn("ClaimValue").AsString(256).NotNullable();

        // Add any additional columns here if needed
    }

    public override void Down()
    {
        Delete.Table("AspNetUserClaims");
    }
}