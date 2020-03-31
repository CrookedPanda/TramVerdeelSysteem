using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    class ConnectionClass
    {
        internal MySqlConnection Con { get; }

        public ConnectionClass(string connectionstring)
        {
            Con = new MySqlConnection(connectionstring);
        }
    }
}
