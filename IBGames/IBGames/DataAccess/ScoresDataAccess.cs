using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Data;

namespace IBGames.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    public class ScoresDataAccess
    {
        /// <summary>
        /// 
        /// </summary>
        private string connectionString = string.Empty;
   
        /// <summary>
        /// 
        /// </summary>
        public ScoresDataAccess()
        {
            connectionString = ConfigurationManager.ConnectionStrings["IBGames.Properties.Settings.IBDatabaseConnectionString"].ConnectionString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool AddNewScore(int result, string username)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sqlQuery = "INSERT INTO Scores (UserID, Score) VALUES ((SELECT ID FROM Users WHERE Username = @username), @result)";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@username", username));
                    cmd.Parameters.Add(new SqlParameter("@result", result));

                    try
                    {
                        int count = (int)cmd.ExecuteNonQuery();
                        return count == 1;
                    }
                    catch (SqlException)
                    {
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public List<int> GetScoresForUser(string username)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sqlQuery = "SELECT Score FROM Scores INNER JOIN Users ON Scores.UserID = Users.ID WHERE Username = @username ORDER BY Score DESC";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@username", username));

                    List<int> result = new List<int>();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (!reader.NextResult())
                    {
                        result.Add((int)reader["Score"]);
                    }

                    return result;
                }
            }
        }
    }
}