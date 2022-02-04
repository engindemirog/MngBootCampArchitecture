using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mailing
{
    public class Mail
    {
        public string Subject { get; set; }
        public string TextBody { get; set; }
        public string HtmlBody { get; set; }
        public AttachmentCollection Attachments { get; set; }
        public string ToFullName { get; set; }
        public string ToEmail { get; set; }
    }
}
