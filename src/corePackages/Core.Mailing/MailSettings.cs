using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mailing
{
    public class MailSettings
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string SenderFullName { get; set; }
        public string SenderEmail { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
