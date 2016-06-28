using SocialNetwork.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Entities;
using SocialNetwork.Dal.Database;
using System.Data.SqlClient;

namespace SocialNetwork.Dal
{
    public class UserMessagesDao : IUserMessagesDao
    {
        private string conString;

        public UserMessagesDao(string conString)
        {
            this.conString = conString;
        }

        public IEnumerable<Dialog> GetUserDialogs(int userId)
        {
            var dialogs = new List<Dialog>();
            using (var con = new SqlConnection(this.conString))
            {
                var cmd = new SqlCommand("SP_Get_User_Dialog", con);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int firstPerson = userId;
                    int secondPerson = (int)reader["SecondPerson"];

                    dialogs.Add(new Dialog
                    {
                        FirstPerson = DaoKeeper.UserDao.GetUserById(firstPerson),
                        SecondPerson = DaoKeeper.UserDao.GetUserById(secondPerson),
                        Messages = this.GetDialogMessages(firstPerson, secondPerson),
                    });
                }

                return dialogs;
            }
        }

        public IEnumerable<Dialog> GetUserDialogsUnread(int id)
        {
            var dialogs = new List<Dialog>();
            using (var con = new SqlConnection(this.conString))
            {
                var cmd = new SqlCommand("SP_Get_User_Dialog", con);
                cmd.Parameters.AddWithValue("@userId", id);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int firstPerson = id;
                    int secondPerson = (int)reader["SecondPerson"];

                    dialogs.Add(new Dialog
                    {
                        FirstPerson = DaoKeeper.UserDao.GetUserById(firstPerson),
                        SecondPerson = DaoKeeper.UserDao.GetUserById(secondPerson),
                        Messages = this.GetUnreadDialogMessages(firstPerson, secondPerson),
                    });
                }

                return dialogs;
            }
        }

        public IEnumerable<Message> GetUnreadDialogMessages(int firstPersonId, int secondPersonId)
        {
            var messages = new List<Message>();
            using (var con = new SqlConnection(this.conString))
            {
                var cmd = new SqlCommand("SP_Get_Unread_Dialog_Messages", con);
                cmd.Parameters.AddWithValue("@firstPersonId", firstPersonId);
                cmd.Parameters.AddWithValue("@secondPersonId", secondPersonId);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    messages.Add(new Message
                    {
                        SenderId = (int)reader["SenderId"],
                        RecieverId = (int)reader["RecieverId"],
                        Contents = (string)reader["Contents"],
                        DateSent = (DateTime)reader["DateSent"],
                    });
                }
            }

            return messages;
        }

        private IEnumerable<Message> GetDialogMessages(int firstPersonId, int secondPersonId)
        {
            var messages = new List<Message>();
            using (var con = new SqlConnection(this.conString))
            {
                var cmd = new SqlCommand("SP_Get_Dialog_Messages", con);
                cmd.Parameters.AddWithValue("@firstPersonId", firstPersonId);
                cmd.Parameters.AddWithValue("@secondPersonId", secondPersonId);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    messages.Add(new Message
                    {
                        SenderId = (int)reader["SenderId"],
                        RecieverId = (int)reader["RecieverId"],
                        Contents = (string)reader["Contents"],
                        DateSent = (DateTime)reader["DateSent"],
                    });
                }
            }

            return messages;
        }

    }
}
