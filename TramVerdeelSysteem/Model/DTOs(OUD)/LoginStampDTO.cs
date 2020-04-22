using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DTOsOud
{
    public class LoginStampDTO
    {

        public LoginStampDTO()
        {

        }
        public LoginStampDTO(string _username, DateTime _dateTime)
        {
            username = _username;
            dateTime = _dateTime;
        }
        public string username { get; set; }
        public DateTime dateTime { get; set; }
    }
}
