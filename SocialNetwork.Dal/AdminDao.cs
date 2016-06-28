using SocialNetwork.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Entities;
using System.Data.SqlClient;

namespace SocialNetwork.Dal
{
    public class AdminDao : IAdminDao
    {
        private readonly string conString;

        public AdminDao(string conString)
        {
            this.conString = conString;
        }

        public Admin GetAdminByUsername(string username)
        {
            using (var con = new SqlConnection(this.conString))
            {
                var cmd = new SqlCommand("SP_Get_Admin_By_Username", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", username);
                con.Open();
                var reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    return new Admin
                    {
                        Id = (int)reader["Id"],
                        Username = (string)reader["Username"],
                        Password = (string)reader["Password"],
                    };
                }

                return null;
            }
        }
    }
}
