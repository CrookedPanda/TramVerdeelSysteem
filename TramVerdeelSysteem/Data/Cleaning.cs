using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Interfaces;
using Model.DTOs;
using MySql.Data.MySqlClient;

namespace Data
{
    public class Cleaning
    {
        private readonly ConnectionClass _connect;
        public Cleaning(ConnectionClass connect)
        {
            _connect = connect;
        }

        public Cleaning()
        {
            _connect = new ConnectionClass();
        }
    }
}
