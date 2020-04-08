using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModels
{
    public class RegistrationView
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; }
    }
}
