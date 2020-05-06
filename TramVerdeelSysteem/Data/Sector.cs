using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Sector
    {
        private readonly ConnectionClass _connect;
        public Sector(ConnectionClass connect)
        {
            _connect = connect;
        }
    }
}
