using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Model.DTOs;

namespace Logic.Interfaces
{
    public interface IDatabaseAccount
    {
        bool Login(string username, DateTime dateTime, string AuthKey);

        void Logout(int id);

        void AddAccount(RegistrationDTO account);
        void AddAccount(int roleID, string name, string hashedPassword);


        void RemoveAccount(int ID);


        LoginDTO GetUser(string username);

    }
}
