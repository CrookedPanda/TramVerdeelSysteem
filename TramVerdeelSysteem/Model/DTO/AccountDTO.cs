using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTO
{
    public class AccountDTO
    {
        public string UserName { get; set; }
        public string HashedPassword { get; set; }
        public string UserRole { get; set; }
        public int UserId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
