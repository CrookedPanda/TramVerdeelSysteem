using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Model.DTOs;

namespace Logic.Interfaces
{
    public interface IDatabaseAccount
    {
        void Login(string username, DateTime dateTime);

        void Logout(int id, DateTime dateTime);

        void AddAccount(int roleID, string name, string hashedPassword);


        void RemoveAccount(int ID);


        AccountDTO GetUser(string username);

    }
}
