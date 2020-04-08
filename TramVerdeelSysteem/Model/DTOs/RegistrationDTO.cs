using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTOs
{
    public class RegistrationDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }
    }
}
