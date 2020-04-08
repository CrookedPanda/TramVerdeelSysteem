using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTOs
{
    public class AuthDTO
    {
        public string Name { get; set; }
        public string Key { get; set; }
        public List<string> Roles { get; set; }
    }
}
