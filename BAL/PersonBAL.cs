using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAL;
using System.Data;

namespace BAL
{
    public class PersonBAL
    {

        public Person GetPerson(int personID)
        {

            using(PersonDAL pDAL = new PersonDAL())
            {
                return pDAL.GetPerson(personID);
            }
        }

        public DataTable SearchByFirstName(Person person)
        {
            PersonDAL pDAL = new PersonDAL();
            try
            {
                return pDAL.SearchByFirstName(person);
            }
            catch (Exception)
            {
                
                // Event loglara yaz
                throw;
            }
            finally
            {
                pDAL.Dispose();
            }
        }
    }
}
