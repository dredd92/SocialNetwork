using System;

namespace SocialNetwork.Entities
{
    public class Message
    {
        public string Contents { get; set; }
        public DateTime DateSent { get; set; }
        public int RecieverId { get; set; }
        public int SenderId { get; set; }
        public bool IsRead { get; set; }
    }
}