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
    public class PersonDAL : IDisposable
    {
        string connStr = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
        SqlConnection conn = null;

        public PersonDAL()
        {
            conn = new SqlConnection(connStr);
            conn.Open();
        }


        public Person GetPerson(int personID)
        {

            string strSql = "SELECT * FROM Employees WHERE EmployeeID = " + personID;

            Person p = null;
            try
            {
                SqlCommand cmd = new SqlCommand(strSql, conn);
                SqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read()){

                    p = new Person { FirstName = rdr.GetString(2), LastName = rdr.GetString(1), PersonID = personID };
                }
                rdr.Dispose();
            }
            catch (Exception)
            {
                
               // event log
            }
            return p;
        }


        public DataTable SearchByFirstName(Person person)
        {
            string strSql = "SELECT * FROM Employees WHERE FirstName LIKE '%"+ person.FirstName + "%' ORDER BY FirstName";
            SqlDataAdapter dAD = new SqlDataAdapter(strSql, conn);
            DataSet dSet = new DataSet();
            try
            {
                dAD.Fill(dSet, "SearchResult");
                return dSet.Tables["SearchResult"];
               
            }
            catch 
            {
                
               // loga yaz
                
            }
            finally
            {
                dSet.Dispose();
            }

            return null;

        }

        #region IDisposable Members
        public void Dispose()
        {
            conn.Close();
            conn.Dispose();
        }
        #endregion
    }
}
