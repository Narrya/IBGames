using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IBGames.DataAccess;

namespace IBGames.Business
{
    /// <summary>
    /// 
    /// </summary>
    public class UserAuthentication
    {
        /// <summary>
        /// 
        /// </summary>
        public UserAuthentication()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Authenticate(string username, string password)
        {
            UsersDataAccess dataAccess = new UsersDataAccess(); 
            return dataAccess.TryAuthenticateUser(username, password);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool IsStudent(string username)
        {
            UsersDataAccess dataAccess = new UsersDataAccess();
            return dataAccess.IsStudent(username);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool IsAdmin(string username)
        {
            UsersDataAccess dataAccess = new UsersDataAccess();
            return dataAccess.IsAdmin(username);
        }
    }
}
