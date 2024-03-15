namespace FlowerShop.Server.Models.UserEntity
{
    public class UserEntity
    {
        public UserEntity() : base()
        { }

        public UserEntity(Guid id, string Name, string Surname, string TelephoneNumber, string EmailAddress, string Login, string Password, bool IsConf, bool isBlocked, UserRank userRank)
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
            /*
            this.Address = Address;
            this.Payment = Payment;
            this.Company = Company;
             */
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
        //public virtual Guid Address { get; set; } //other classes will add later
        //public virtual Guid Payment { get; set; }
        //public virtual Guid Company { get; set; }

    }
}
