using System;
using System.Collections.Generic;
using System.Text;
using Model.DTOs;

namespace Model.ViewModels
{
    public class AuthView
    {
        public AuthView()
        {

        }
        public AuthView(AuthDTO cAuthDTO)
        {
            Name = cAuthDTO.Name;
            Key = cAuthDTO.Key;
            Roles = cAuthDTO.Roles;
        }
        public string Name { get; set; }
        public string Key { get; set; }
        public List<string> Roles { get; set; }
    }
}
