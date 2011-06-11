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
    public class ScoreBusinessLogic
    {
        /// <summary>
        /// 
        /// </summary>
        private string _username = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        public ScoreBusinessLogic(string username)
        {
            _username = username;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool AddNewScore(string username, int result)
        {
            ScoresDataAccess dataSource = new ScoresDataAccess();
            return dataSource.AddNewScore(result, username);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public List<int> GetScoresForUser(string username)
        {
            ScoresDataAccess dataSource = new ScoresDataAccess();
            return dataSource.GetScoresForUser(username);
        }
    }
}