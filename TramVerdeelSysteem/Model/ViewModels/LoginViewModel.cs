using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Model.ViewModels
{
    public class LoginViewModel
    {
        //[Required]
        public String name { get; set; }
        [DataType(DataType.Password)]
        //[Required]
        public String password { get; set; }
        public int key { get; set; }
    }
}
