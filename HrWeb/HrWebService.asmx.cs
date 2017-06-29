using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BAL;
using BO;
using DAL;
using System.Data;

namespace HrWeb
{
    /// <summary>
    /// Summary description for HrWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class HrWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public Person GetPerson(int PersonID)
        {
            PersonBAL pBAL = new PersonBAL();
            return pBAL.GetPerson(PersonID);
        }

         [WebMethod(EnableSession = true)]
        public DataSet SearchByFirstName(string firstName)
        {

            if (Session["UserID"] != null)
            {                            
                PersonBAL pBAL = new PersonBAL();
                Person person = new Person();
                person.FirstName = firstName;
                return pBAL.SearchByFirstName(person).DataSet;
            }

            return null;
        }

        [WebMethod(EnableSession=true)]
        public bool LoginByUserNamePassword(string userName, string password)
        {

            UserBAL uBal = new UserBAL();
            int result = uBal.Validate(userName,password);
            if (result > 0)
            {
                Session.Add("UserID", result);
                return true;
            }

            return false;
        }

       [WebMethod(EnableSession = true)]
        public bool Login(User user) 
        {
            UserBAL uBal = new UserBAL();
            int result = uBal.Validate(user);
            if(result > 0){
                Session.Add("UserID", result);
                return true;
            }

            return false;
        }
        [WebMethod(EnableSession = true)]
        public bool LogOut()
        {
            try
            {
                Session.Remove("UserID");
                return true;
            }
            catch (Exception)
            {
                
                return false;
            }
        }


        [WebMethod(EnableSession = true)]
        public bool LoginStatus()
        {
            if (Session["UserID"] != null)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        [WebMethod]
        public Person GetPersonDetail()
        {
            Person p = new Person();
            p.FirstName = "Mehmet";
            p.PersonID = 1;
            p.LastName = "Çalışkan";

            return p;
        }
    }
}
