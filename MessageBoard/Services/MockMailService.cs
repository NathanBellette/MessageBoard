using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace MessageBoard.Services
{
    public class MockMailService : IMailService
    {
        public bool SendMail(string to, string from, string subject, string body)
        {
            Debug.WriteLine(string.Concat("Send Mail:", subject));
            return true;
        }
    }
}