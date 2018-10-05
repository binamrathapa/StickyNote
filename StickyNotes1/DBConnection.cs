using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace StickyNotes1
{
    public class DBConnection
    {
        SqlConnection conn;
        public DBConnection()
        {
            conn = new SqlConnection("Data Source=DESKTOP-MKF6Q8C; Initial Catalog=StickyMGMT; Integrated Security=True");
        }
        public int executyQuery(string query)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Connection.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
        }
        public DataTable GetData(string query)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0)
                    return ds.Tables[0];
                else
                    return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
