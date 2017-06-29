using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using System.Data;

namespace DAL
{
    public class UserDAL : IDisposable
    {
        string connStr = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
        SqlConnection conn = null;

        public UserDAL()
        {
            conn = new SqlConnection(connStr);
            conn.Open();
        }

        public int ValidateUser(User user )
        {
            string strSql = "SELECT * FROM tblUser WHERE UserName='"+user.UserName + "' AND Password = '" + user.Password + "'";
            SqlDataAdapter dAD = new SqlDataAdapter(strSql, conn);
            DataSet dSet = new DataSet();
            try
            {
                dAD.Fill(dSet, "Result");
                if (dSet.Tables["Result"].Rows.Count > 0)
                {
                    return (int)dSet.Tables["Result"].Rows[0]["UserID"];

                }
                else
                {
                    return -1;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            finally
            {
                dSet.Dispose();
                dAD.Dispose();

            }

        }


        public void Dispose()
        {
            conn.Close();
            conn.Dispose();

        }
    }
}
