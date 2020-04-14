using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTOsOud
{
    public class AccountDTO
    {
        public AccountDTO()
        {

        }
        public AccountDTO(string _username, string _hashedPassword, int _roleID)
        {
            Username = _username;
            HashedPassword = _hashedPassword;
            RoleId = _roleID;
        }
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public int RoleId { get; set; }
        public string UserRole { get; set; }
        public int UserId { get; set; }
    }
}
