using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class ConnectionClass
    {
        internal MySqlConnection Con { get; }

        public ConnectionClass(string connectionstring)
        {
            Con = new MySqlConnection(connectionstring);
        }

        public ConnectionClass()
        {
            Con = new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi405544;Database=dbi405544;Pwd=SirBotler;");
        }
    }
}
