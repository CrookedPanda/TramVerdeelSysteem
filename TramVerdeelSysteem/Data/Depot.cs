using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Depot
    {
        private readonly ConnectionClass _connect;
        public Depot(ConnectionClass connect)
        {
            _connect = connect;
        }
    }
}
