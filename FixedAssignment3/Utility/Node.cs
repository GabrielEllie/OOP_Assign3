using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
    [DataContract]
    public class Node
    {
        [DataMember]
        public User Data { get; set; }
        [DataMember]
        public Node Next { get; set; }

        public Node(User data)
        {
            Data = data;
        }
    }
}
