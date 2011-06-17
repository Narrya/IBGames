using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

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
        /// Gets the users.
        /// </summary>
        /// <returns>Users data table.</returns>
        public DataTable GetUsers()
        {
            // Creating adapter and filling data table - remember about invariant culture.
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Users ORDER BY Username ASC", connectionString);

            DataTable table = new DataTable();
            table.Locale = CultureInfo.InvariantCulture;

            adapter.Fill(table);

            return table;
        }

        /// <summary>
        /// Gets all disconnected students.
        /// </summary>
        /// <returns>Users data table.</returns>
        public DataTable GetAllDisconectedStudents(string username)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sqlQuery = "SELECT * FROM Users WHERE ParentID IS NULL AND IsAdmin = 0 AND IsStudent = 1 ORDER BY Username ASC";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    DataTable table = new DataTable();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    table.Locale = CultureInfo.InvariantCulture;

                    adapter.Fill(table);

                    return table;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool AssociateStudent(int student, string username)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                int parentID = 0;
                string sqlSearchParentID = "SELECT ID FROM Users WHERE Users.Username = @username";
                using (SqlCommand cmd = new SqlCommand(sqlSearchParentID, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@username", username));

                    parentID = (int)cmd.ExecuteScalar();
                }

                string sqlQuery = "UPDATE Users SET Users.ParentID = @parentID WHERE Users.ID = @id";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@parentID", parentID));
                    cmd.Parameters.Add(new SqlParameter("@id", student));

                    return (int)cmd.ExecuteNonQuery() > 0;
                }
            }
        }


        /// <summary>
        /// Gets the users which are my subordinate.
        /// </summary>
        /// <returns>Users data table.</returns>
        public DataTable GetMyUsers(string username)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                int parentID = 0;
                string sqlSearchParentID = "SELECT ID FROM Users WHERE Users.Username = @username";
                using (SqlCommand cmd = new SqlCommand(sqlSearchParentID, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@username", username));

                    parentID = (int)cmd.ExecuteScalar();
                }

                string sqlQuery = "SELECT * FROM Users U1 WHERE U1.ParentID = @parentID AND U1.IsAdmin = 0 AND U1.IsStudent = 1 ORDER BY Username ASC";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@parentID", parentID));

                    DataTable table = new DataTable();

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    table.Locale = CultureInfo.InvariantCulture;

                    adapter.Fill(table);

                    return table;
                }
            }
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