using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTOs
{
    public class RegistrationDTO
    {
        public RegistrationDTO(string cUsername, string cPassword, List<int> cRoles)
        {
            Username = cUsername;
            Password = cPassword;
            Roles = cRoles;
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<int> Roles { get; set; }
    }
}
