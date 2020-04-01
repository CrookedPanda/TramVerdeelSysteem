using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTOs
{
    class LoginDTO
    {
        public class AccountDTO
        {
            public string username { get; set; }
            public string hashedPassword { get; set; }
            public int id { get; set; }
            public DateTime datetime { get; set; }
        }
    }
}
