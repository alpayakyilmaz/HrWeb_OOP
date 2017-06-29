using BAL;
using BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace HrWeb
{
    /// <summary>
    /// Summary description for SessionHeaderService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SessionHeaderService : System.Web.Services.WebService
    {
        public SessionHeader currentSessionHeader;
        public SessionHeaderService()
        {

        }


        [WebMethod]
        [SoapHeader("currentSessionHeader",Direction=SoapHeaderDirection.Out)]
        public bool CreateSession(string username, string pass)
        {
            UserBAL uBal = new UserBAL();
            int result = uBal.Validate(username, pass);
            if (result > 0)
            {
                currentSessionHeader = new SessionHeader(Guid.NewGuid().ToString());
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        [SoapHeader("currentSessionHeader", Direction = SoapHeaderDirection.In)]
        public DataSet SearchByFirstName(string firstName)
        {
            PersonBAL pBAL = new PersonBAL();
            Person person = new Person();
            person.FirstName = firstName;
            return pBAL.SearchByFirstName(person).DataSet;
        }
    }
}
