using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class Track
    {
        private readonly ConnectionClass _connect;
        public Track(ConnectionClass connect)
        {
            _connect = connect;
        }
    }
}
