using System;
using System.Collections.Generic;

namespace SocialNetwork.Entities
{
    public enum Sex
    {
        Male,
        Female,
    }

    public enum UserRoles
    {
        Admin,
        User,
    }

    public class User
    {
        public DateTime? DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public IEnumerable<User> Friends { get; set; }
        public string Hometown { get; set; }
        public int Id { get; set; }
        public string Image { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public Sex Sex { get; set; }
        public string Username { get; set; }
    }
}