using SocialNetwork.Dal.Interfaces;
using SocialNetwork.Entities;
using System.Data;
using System.Data.SqlClient;

namespace SocialNetwork.Dal
{
    public class MessageDao : IMessagesDao
    {
        private string conString;

        public MessageDao(string conString)
        {
            this.conString = conString;
        }

        public void AddMessage(Message message)
        {
            using (var con = new SqlConnection(this.conString))
            {
                var command = new SqlCommand("SP_Add_Message", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@senderId", message.SenderId);
                command.Parameters.AddWithValue("@recieverId", message.RecieverId);
                command.Parameters.AddWithValue("@contents", message.Contents);
                command.Parameters.AddWithValue("@dateSent", message.DateSent);
                con.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}