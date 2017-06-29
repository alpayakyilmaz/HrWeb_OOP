using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace HrWeb
{
    public class SessionHeader: SoapHeader
    {
        public string SessionID;
        public SessionHeader(string sessionID)
        {
            SessionID = sessionID;
        }
        public SessionHeader()
        {
            
        }
    }
}