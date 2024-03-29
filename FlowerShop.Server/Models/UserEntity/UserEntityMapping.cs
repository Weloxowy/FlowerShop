using FluentNHibernate.Mapping;

namespace FlowerShop.Server.Models.UserEntity
{
    public class UserEntityMapping : ClassMap<AspNetUsers>
    {
        readonly string tablename = nameof(AspNetUsers);
        public UserEntityMapping()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Surname);
            Map(x => x.TelephoneNumber);
            Map(x => x.EmailAddress);
            Map(x => x.Login).Unique();
            Map(x => x.Password);
            Map(x => x.IsUserProfileConfirmed);
            Map(x => x.IsUserProfileBlocked);
            Map(x => x.UserRank).CustomType<UserRank>();
            Map(x => x.UserName);
            Map(x => x.NormalizedUserName);
            Map(x => x.Email);
            Map(x => x.NormalizedEmail);
            Map(x => x.EmailConfirmed);
            Map(x => x.PasswordHash);
            Map(x => x.SecurityStamp);
            Map(x => x.ConcurrencyStamp);
            Map(x => x.PhoneNumber);
            Map(x => x.PhoneNumberConfirmed);
            Map(x => x.TwoFactorEnabled);
            Map(x => x.LockoutEnd);
            Map(x => x.LockoutEnabled);
            Map(x => x.AccessFailedCount);
            Table(tablename);
        }
    }
}
