using SocialNetwork.Dal.Interfaces;
using SocialNetwork.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SocialNetwork.Dal.Database
{
    public class UserDao : IUserDao
    {
        private string conString;

        public UserDao(string conString)
        {
            this.conString = conString;
        }

        public void AddUser(User user)
        {
            using (var con = new SqlConnection(this.conString))
            {
                var cmd = new SqlCommand("SP_Add_User", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", user.Username);

                if (user.DateOfBirth != null)
                {
                    cmd.Parameters.AddWithValue("@dateOfBirth", user.DateOfBirth);
                }

                cmd.Parameters.AddWithValue("@firstName", user.FirstName);
                cmd.Parameters.AddWithValue("@lastName", user.LastName);
                cmd.Parameters.AddWithValue("@sex", user.Sex);

                if (user.Hometown != null)
                {
                    cmd.Parameters.AddWithValue("@hometown", user.Hometown);
                }

                if (user.Image != null)
                {
                    cmd.Parameters.AddWithValue("@image", user.Image);
                }

                cmd.Parameters.AddWithValue("@password", user.Password);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            var users = new List<User>();
            using (var con = new SqlConnection(this.conString))
            {
                var cmd = new SqlCommand("SP_Get_All_Users", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                var reader = cmd.ExecuteReader();
                while (!reader.Read())
                {
                    int id = (int)reader["Id"];
                    users.Add(new User
                    {
                        Id = id,
                        Username = (string)reader["Username"],
                        Password = (string)reader["Password"],
                        DateOfBirth = reader["DateOfBirth"] as DateTime?,
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Sex = (Sex)reader["Sex"],
                        Hometown = reader["Hometown"] as string,
                        Image = reader["Image"] as string,
                        Friends = DaoKeeper.FriendsDao.GetFriendsOfUser(id),
                    });
                }
            }

            return users;
        }

        public User GetUserById(int userId)
        {
            using (var con = new SqlConnection(this.conString))
            {
                var cmd = new SqlCommand("SP_Get_User_By_Id", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", userId);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return new User
                    {
                        Id = (int)reader["Id"],
                        Username = (string)reader["Username"],
                        Password = (string)reader["Password"],
                        DateOfBirth = reader["DateOfBirth"] as DateTime?,
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Sex = (Sex)reader["Sex"],
                        Hometown = reader["Hometown"] as string,
                        Image = reader["Image"] as string,
                    };
                }

                return null;
            }
        }

        public User GetUserByName(string username)
        {
            using (var con = new SqlConnection(this.conString))
            {
                var cmd = new SqlCommand("SP_Get_User_By_Name", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", username);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return new User
                    {
                        Id = (int)reader["Id"],
                        Username = (string)reader["Username"],
                        Password = (string)reader["Password"],
                        DateOfBirth = reader["DateOfBirth"] as DateTime?,
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Sex = (Sex)reader["Sex"],
                        Hometown = reader["Hometown"] as string,
                        Image = reader["Image"] as string,
                    };
                }

                return null;
            }
        }

        public IEnumerable<User> GetUserFriends(int userId)
        {
            var friends = new List<User>();
            using (var con = new SqlConnection(this.conString))
            {
                var cmd = new SqlCommand("SP_Get_User_Friends", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", userId);
                con.Open();
                var reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    friends.Add(this.GetUserById((int)reader["FriendId"]));
                }
            }

            return friends;
        }

        public bool RemoveFriendFromUser(int userId, int friendId)
        {
            using (var con = new SqlConnection(this.conString))
            {
                var cmd = new SqlCommand("SP_Remove_Friend_From_User", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@friendId", friendId);
                con.Open();
                cmd.ExecuteNonQuery();
                
                if (cmd.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void AddFriendToUser(int userId, int friendId)
        {
            using (var con = new SqlConnection(this.conString))
            {
                var cmd = new SqlCommand("SP_Add_Friend_To_User", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@friendId", friendId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public bool RemoveUser(int userId)
        {
            using (var con = new SqlConnection(this.conString))
            {
                var cmd = new SqlCommand("SP_Remove_User", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userId", userId);
                con.Open();

                if (cmd.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool UpdateUser(int userId, User newUser)
        {
            using (var con = new SqlConnection(this.conString))
            {
                var cmd = new SqlCommand("SP_Update_User", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@oldUserId", userId);
                cmd.Parameters.AddWithValue("@newUsername", newUser.Username);
                cmd.Parameters.AddWithValue("@newDateOfBirth", newUser.DateOfBirth);
                cmd.Parameters.AddWithValue("@newFirstName", newUser.FirstName);
                cmd.Parameters.AddWithValue("@newPassword", newUser.Password);
                cmd.Parameters.AddWithValue("@newLastName", newUser.LastName);
                cmd.Parameters.AddWithValue("@newSex", newUser.Sex);
                cmd.Parameters.AddWithValue("@newHometown", newUser.Hometown);
                cmd.Parameters.AddWithValue("@newImage", newUser.Image);
                con.Open();

                if (cmd.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public IEnumerable<User> GetUserBySearchData(SearchData data)
        {
            List<User> result = new List<User>();
            using (var con = new SqlConnection(this.conString))
            {
                var cmd = new SqlCommand("SP_Get_User_By_Search_Data", con);
                cmd.CommandType = CommandType.StoredProcedure;

                if (data.Name != null)
                {
                    cmd.Parameters.AddWithValue("@name", data.Name);
                }

                if (data.Sex != null)
                {
                    cmd.Parameters.AddWithValue("@sex", data.Sex);
                }

                if (data.AgeFrom != null)
                {
                    cmd.Parameters.AddWithValue("@ageFrom", data.AgeFrom);
                }

                if (data.AgeTo != null)
                {
                    cmd.Parameters.AddWithValue("@ageTo", data.AgeTo);
                }

                if (data.Hometown != null)
                {
                    cmd.Parameters.AddWithValue("@hometown", data.Hometown);
                }

                con.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new User
                    {
                        Id = (int)reader["Id"],
                        Username = (string)reader["Username"],
                        Password = (string)reader["Password"],
                        DateOfBirth = reader["DateOfBirth"] as DateTime?,
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Sex = (Sex)reader["Sex"],
                        Hometown = reader["Hometown"] as string,
                        Image = reader["Image"] as string,
                        Friends = DaoKeeper.FriendsDao.GetFriendsOfUser((int)reader["Id"]),
                    });
                }

                return result;
            }
        }
    }
}