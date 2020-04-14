using System;
using System.Collections.Generic;
using System.Text;
using Logic.Interfaces;
using System.Security.Cryptography;
using Model.DTOs;
using Model.ViewModels;
using Data;

namespace Logic
{
    public class Authentication
    {
        IDatabaseAccount iDatabaseAccount;

        public Authentication(IDatabaseAccount iDatabase)
        {
            iDatabaseAccount = iDatabase;
        }

        public Authentication()
        {

            Authorisation authorisation = new Authorisation();
            iDatabaseAccount = authorisation;
        }

        public AuthView Login(string username, string password) 
        {
            bool verified = VerifyHashedPassword(password, username);

            DateTime dateTime = DateTime.Now;

            try
            {
                if (verified)
                {
                    Guid g = Guid.NewGuid();
                    string AuthKey = Convert.ToBase64String(g.ToByteArray());
                    AuthKey = AuthKey.Replace("=", "");
                    AuthKey = AuthKey.Replace("+", "");
                    AuthKey = AuthKey.Replace("/", "");

                    AuthView view = new AuthView();
                    if (iDatabaseAccount.Login(username, dateTime, AuthKey))
                    {
                        view.Name = username;
                        view.Key = AuthKey;
                        //view.Roles = iDatabaseAccount.GetRoles(username);
                        return view;
                    }
                    else
                    {
                        throw new OperationCanceledException("Username or Password is invalid");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            throw new OperationCanceledException("Username or Password is invalid");
        }
        public void Logout()
        {

        }

        public void AddAccount(string username, string password, List<int> roles)
        {

            string hashedPassword = HashPassword(password);
            RegistrationDTO account = new RegistrationDTO(username, hashedPassword, roles);
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
            string savedPasswordHash = iDatabaseAccount.GetUser(username).Password;
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
