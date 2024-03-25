namespace FlowerShop.Server.Models.UserEntity
{
    public interface IUserEntityService 
    {
        public string HashPassword(string password, int length);
        public bool VerifyPassword(string tryPassword, string password);
        public string VerifyPhoneNumber(string TelephoneNumber);
        public bool VerifyEmail(string EmailAddress);
        public bool VerifyPassword(string Password);
    }
}
