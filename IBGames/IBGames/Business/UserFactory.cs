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
    public class UserFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public UserFactory()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="isStudent"></param>
        /// <returns></returns>
        public bool RegisterUser(string login, string password, bool isStudent)
        {
            UsersDataAccess dataAccess = new UsersDataAccess();
            return dataAccess.CreateUser(login, password, isStudent);
        }
    }
}
