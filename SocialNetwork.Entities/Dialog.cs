using System.Collections.Generic;

namespace SocialNetwork.Entities
{
    public class Dialog
    {
        public User FirstPerson { get; set; }
        public User SecondPerson { get; set; }
        public IEnumerable<Message> Messages { get; set; }
    }
}