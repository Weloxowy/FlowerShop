using FlowerShop.Server.Models;
using FlowerShop.Server.Models.UserEntity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;

namespace FlowerShop.Server.Persistence.UserEntity
{
    public class UserEntityService : IUserEntityService
    {
        public string GenerateSalt(int length)
        {
            return "sup";
        }

        public string HashPassword(string password, int length)
        {
            byte[] salt = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(salt);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            return savedPasswordHash;
        }


        public bool VerifyPassword(string tryPassword, string storedPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(storedPassword);
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(tryPassword, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            /* Compare the results */
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                    return false;
            }
            return true;
        }

        public bool VerifyEmail(string EmailAddress)
        {
            string emailPattern = @"^\S+@\S+$";
            return Regex.IsMatch(EmailAddress, emailPattern);
        }

        public string VerifyPhoneNumber(string TelephoneNumber)
        {
            throw new NotImplementedException();
        }

        public bool VerifyPassword(string Password)
        {
            if (Password.Length <  8) return false;
            return true;
        }
    }
}
