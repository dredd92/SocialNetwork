using SocialNetwork.Dal.Interfaces;
using SocialNetwork.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SocialNetwork.Dal.Database
{
    public class FriendDao : IFriendsDao
    {
        private string conString;

        public FriendDao(string conString)
        {
            this.conString = conString;
        }

        public void AddFriendToUser(int userId, int friendId)
        {
            using (var con = new SqlConnection(this.conString))
            {
                var command = new SqlCommand("SP_Add_Friend_To_User", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@friendId", friendId);
                con.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<User> GetFriendsOfUser(int userId)
        {
            var friends = new List<User>();

            using (var con = new SqlConnection(this.conString))
            {
                var command = new SqlCommand("SP_Get_Friends_Of_User", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@userId", userId);
                con.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    friends.Add(new User
                    {
                        Id = (int)reader["FriendId"],
                        Username = (string)reader["Username"],
                        Password = (string)reader["Password"],
                        DateOfBirth = reader["DateOfBirth"] as DateTime?,
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Sex = (Sex)reader["Sex"],
                        Hometown = reader["Hometown"] as string,
                        Image = (string)reader["Image"],
                    });
                }

                return friends;
            }
        }

        public bool RemoveFriendFromUser(int userId, int friendId)
        {
            using (var con = new SqlConnection(this.conString))
            {
                var command = new SqlCommand("SP_Remove_Friend_From_User", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@friendId", friendId);
                con.Open();

                if (command.ExecuteNonQuery() == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}