using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BL.Util
{

    public class Message
    {

        public string Type { get; set; }

        public string MessageContent { get; set; }

        public string ReturnData { get; set; }
        public string Subject { get; set; }
        public string Destination { get; set; }
    }
}
