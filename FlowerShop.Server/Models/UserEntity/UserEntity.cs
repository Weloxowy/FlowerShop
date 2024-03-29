namespace FlowerShop.Server.Models.UserEntity
{
    public class UserEntity
    {
        public UserEntity() : base()
        { }

        public UserEntity(Guid id, string Name, string Surname, string TelephoneNumber, string EmailAddress, string Login, string Password, bool IsConf, bool isBlocked, UserRank userRank, Guid address, Guid company)
        {
            this.id = id;
            this.Name = Name;
            this.Surname = Surname;
            this.TelephoneNumber = TelephoneNumber;
            this.EmailAddress = EmailAddress;
            this.Login = Login;
            this.Password = Password;
            this.IsUserProfileBlocked = isBlocked; //For not allowing certain users to make new orders
            this.IsUserProfileConfirmed = IsConf; //false if user not confirmed creating a new account, otherwise true
            this.UserRank = userRank;        
        }
        public virtual Guid id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string TelephoneNumber { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string Login { get; set; }
        public virtual string Password { get; set; }
        public virtual bool IsUserProfileConfirmed { get; set; }
        public virtual bool IsUserProfileBlocked { get; set; }
        public virtual UserRank UserRank { get; set; }
        //TODO Payment 
    }
}
