using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Entities
{
    public class Dialog
    {
        public User FirstPerson { get; set; }
        public User SecondPerson { get; set; }
        public IEnumerable<Message> Messages { get; set; }
    }
}
