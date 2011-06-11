using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace IBGames.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    public class UsersDataAccess
    {
        /// <summary>
        /// 
        /// </summary>
        private string connectionString = string.Empty;
   
        /// <summary>
        /// 
        /// </summary>
        public UsersDataAccess()
        {
            connectionString = ConfigurationManager.ConnectionStrings["IBGames.Properties.Settings.IBDatabaseConnectionString"].ConnectionString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool IsAdmin(string username)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sqlQuery = "SELECT COUNT(ID) FROM Users WHERE Username = @username AND IsAdmin = 1";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@username", username));

                    int count = (int)cmd.ExecuteScalar();
                    return count == 1;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool IsStudent(string username)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sqlQuery = "SELECT COUNT(ID) FROM Users WHERE Username = @username AND IsStudent = 1";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@username", username));

                    int count = (int)cmd.ExecuteScalar();
                    return count == 1;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool TryAuthenticateUser(string username, string password)
        {            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sqlQuery = "SELECT COUNT(ID) FROM Users WHERE Username = @username AND Password = @encodedPassword";
                string encodedPassword = EncodePassword(password);

                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@username", username));
                    cmd.Parameters.Add(new SqlParameter("@encodedPassword", encodedPassword));

                    int count = (int)cmd.ExecuteScalar();
                    return count == 1;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="isStudent"></param>
        /// <returns></returns>
        public bool CreateUser(string login, string password, bool isStudent)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sqlQuery = "INSERT INTO Users (Username, Password, IsStudent) VALUES (@username, @encodedPassword, @isStudent)";
                string encodedPassword = EncodePassword(password);

                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@username", login));
                    cmd.Parameters.Add(new SqlParameter("@encodedPassword", encodedPassword));
                    cmd.Parameters.Add(new SqlParameter("@isStudent", isStudent));

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
        /// <param name="originalPassword"></param>
        /// <returns></returns>
        public static string EncodePassword(string originalPassword)
        {
            // Deklaracja zmiennych.
            Byte[] originalBytes = null;
            Byte[] encodedBytes = null;
            MD5 md5;
            
            // Obliczenie skrótu MD5 za pomocą MD5CryptoServiceProvider.
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword);
            encodedBytes = md5.ComputeHash(originalBytes);

            // Konwersja bitów do łańcucha znaków.
            return BitConverter.ToString(encodedBytes).Replace("-", "").ToLowerInvariant();
        }
    }
}