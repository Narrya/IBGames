using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace proba_1.Dbutiluty
{
    class DBoperation
    {
        private static SqlConnection cn;
        public static string connection ;
        
            
        public static bool ConnectToDatabase()
        {
            try
            {
                cn = new SqlConnection(connection);
                cn.Open();
                return true;
            }
            catch (SqlException sql)
            {
                MessageBox.Show(sql.Message);
            }

            return false;
        }

        public static SqlConnection  GetConnection
        {
            get
            {
                return cn;
            }
        }

        public static void CloseConnection()
        {
            cn.Close();
        }

        private DBoperation()
        {

        }

    }
}
