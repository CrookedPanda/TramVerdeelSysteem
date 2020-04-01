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
    }
}
