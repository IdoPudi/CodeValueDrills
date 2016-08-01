using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
    public class MailArrivedEventArgs : EventArgs
    {
        //There are not properties...
        public readonly string Title;
        public readonly string Body;

        public MailArrivedEventArgs(string title, string body)
        {
            Title = title;
            Body = body;
        }
    }
}
