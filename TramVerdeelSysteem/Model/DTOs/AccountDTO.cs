using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTOs
{
    public class AccountDTO
    {
        public AccountDTO()
        {

        }
        public AccountDTO(string _username, string _hashedPassword, int _roleID)
        {
            username = _username;
            hashedPassword = _hashedPassword;
            roleId = _roleID;
        }
        public string username { get; set; }
        public string hashedPassword { get; set; }
        public int roleId { get; set; }
    }
}
