using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuaHangBanSach.DAO
{
    public class DataProvider
    {
        private static string cnnString =
                "Data Source = localhost; Initial Catalog = BANSACH; User ID =sa; Password=123";

        public static string TestConnection()
        {
            using (SqlConnection cnn = new SqlConnection(cnnString))
            {
                try
                {
                    cnn.Open();
                    return "Connect successfully";
                }
                catch(SqlException ex)
                {
                    return ex.ToString();
                }
            }
        }

        public static DataTable ExecuteQuery(string query)
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection cnn = new SqlConnection(cnnString))
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(table);
                    cnn.Close();
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return null;
            }       
            return table;
        }

        public static int ExecuteNonQuery(string query)
        {
            int row = 0;
            try
            {
                using (SqlConnection cnn = new SqlConnection(cnnString))
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    row = cmd.ExecuteNonQuery();
                    cnn.Close();
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }          
            return row;
        }

        public static object ExecuteScalar(string query)
        {
            object row = null;
            try
            {
                using (SqlConnection cnn = new SqlConnection(cnnString))
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(query, cnn);
                    row = cmd.ExecuteScalar();
                    cnn.Close();
                }
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            return row;
        }
    }
}
