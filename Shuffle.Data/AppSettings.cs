using System;
using System.Collections.Generic;
using System.Text;

namespace Shuffle.Data
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string ShuffleboardConnection { get; set; }
    }
}
