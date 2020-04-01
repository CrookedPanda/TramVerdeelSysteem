using System;
using System.Collections.Generic;
using System.Text;
using Logic.Interfaces;
using System.Security.Cryptography;
using Logic.Interfaces.Front_end;
using Model.DTOs;

namespace Logic
{
    public class Authentication
    {
        IDatabaseAccount iDatabaseAccount;
        IFrontendAccount iFrontendAccount;

        public Authentication(IDatabaseAccount iDatabase)
        {
            iDatabaseAccount = iDatabase;
        }

        public Authentication(IDatabaseAccount iDatabase, IFrontendAccount iFrontend)
        {
            iDatabaseAccount = iDatabase;
            iFrontendAccount = iFrontend;
        }


        public void Login()
        {
            string username = iFrontendAccount.AddAccount().username;
            string password = iFrontendAccount.AddAccount().password;

            bool verified = VerifyHashedPassword(password, username);

            DateTime dateTime = DateTime.Now;

            if (verified)
            {
                iDatabaseAccount.Login(username, dateTime);
            }
            
        }
        public void Login(string username, string password) 
        {
            bool verified = VerifyHashedPassword(password, username);

            DateTime dateTime = DateTime.Now;

            if (verified)
            {
                iDatabaseAccount.Login(username, dateTime);
            }
        }
        public void Logout()
        {

        }

        public void AddAccount(string username, string password, int roleID)
        {

            string hashedPassword = HashPassword(password);
            AccountDTO account = new AccountDTO(username, hashedPassword, roleID);
            iDatabaseAccount.AddAccount(account);
        }

        private string HashPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            return savedPasswordHash;
        }



        private bool VerifyHashedPassword(string password, string username)
        {
            /* Fetch the stored value */
            string savedPasswordHash = iDatabaseAccount.GetUser(username).HashedPassword;
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            /* Compare the results */
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;   
                }
            }
            return true;

        }

    }
}
