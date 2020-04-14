using System;
using System.Collections.Generic;
using System.Text;
using Logic.Interfaces;
using Model.DTOs;

namespace UnitTestLogic
{
    public class DBcontext : IDatabaseAccount
    {
        public List<AccountDTO> accounts = new List<AccountDTO>();
        public List<LoginStampDTO> loginstamps = new List<LoginStampDTO>();
        public void AddAccount(AccountDTO account)
        {
            accounts.Add(account);
        }

        public void AddAccount(int roleID, string name, string hashedPassword)
        {
            throw new NotImplementedException();
        }

        public AccountDTO GetUser(string username)
        {
            foreach (AccountDTO account in accounts)
            {
                if (account.username == username)
                {
                    return account;
                } 
            }
            return null;
        }

        public void Login(string username, DateTime dateTime)
        {
            LoginStampDTO loginStamp = new LoginStampDTO();
            loginStamp.username = username;
            loginStamp.dateTime = dateTime;
            loginstamps.Add(loginStamp);
        }

        public void Logout(int id, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public void RemoveAccount(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
