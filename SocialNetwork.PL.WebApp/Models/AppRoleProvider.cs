using System;
using SocialNetwork.PL.WebApp;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SocialNetwork.PL.WebApp.Models
{
    public class AppRoleProvider : RoleProvider
    {
        public override bool IsUserInRole(string username, string roleName)
        {
            if (username == "admin")
            {
                return roleName == "admin";
            }
            else
            {
                return roleName == "user";
            }
        }

        public override string[] GetRolesForUser(string username)
        {
            if (username == "admin")
            {
                return new string[] { "admin"};
            }
            else
            {
                return new string[] { "user" };
            }
        }

        #region notImplemented
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }



        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }



        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}