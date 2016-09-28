using System.Configuration;
using System.Data;
using System.Data.Common;

namespace SocialNetwork.MsSqlDal
{
    internal static class DaoHelper
    {
        private static readonly DbProviderFactory factory;
        private static string conString;

        static DaoHelper()
        {
            string provider = ConfigurationManager.ConnectionStrings["default"].ProviderName;
            DaoHelper.factory = DbProviderFactories.GetFactory(provider);
            DaoHelper.conString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        }

        internal static IDbCommand CreateCommand(IDbConnection con, string text, CommandType type)
        {
            var cmd = con.CreateCommand();
            cmd.CommandType = type;
            cmd.CommandText = text;
            return cmd;
        }

        internal static IDbDataParameter CreateParameter<T>(IDbCommand cmd, string name, T value, DbType type)
        {
            var parameter = cmd.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value;
            parameter.DbType = type;
            return parameter;
        }

        internal static IDbConnection CreateConnection()
        {
            var con = factory.CreateConnection();
            con.ConnectionString = DaoHelper.conString;
            return con;
        }

        internal static void AddParametersRange(IDbCommand cmd, params IDbDataParameter[] prms)
        {
            foreach (var prm in prms)
            {
                cmd.Parameters.Add(prm);
            }
        }
    }
}