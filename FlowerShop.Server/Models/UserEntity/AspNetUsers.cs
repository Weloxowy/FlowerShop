using Microsoft.AspNetCore.Identity;

namespace FlowerShop.Server.Models.UserEntity
{
    public class AspNetUsers : IdentityUser
    {
        public AspNetUsers() : base()
        {
        }

        public AspNetUsers(Guid id, string FirstName, string Surname,  string Password, bool IsConf, bool isBlocked, UserRank userRank, Guid address, Guid company)
        {
            this.FirstName = FirstName;
            this.Surname = Surname;
            this.Password = Password;
            this.IsUserProfileBlocked = isBlocked; //For not allowing certain users to make new orders
            this.IsUserProfileConfirmed = IsConf; //false if user not confirmed creating a new account, otherwise true
            this.UserRank = userRank;
        }

        public virtual string? FirstName { get; set; }
        public virtual string? Surname { get; set; }

        public virtual string? Password { get; set; }
        public virtual bool? IsUserProfileConfirmed { get; set; }
        public virtual bool? IsUserProfileBlocked { get; set; }
        public virtual UserRank? UserRank { get; set; }
        //TODO Payment 
    }
    
}
