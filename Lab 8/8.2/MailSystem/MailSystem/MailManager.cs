using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSystem
{
    class MailManager
    {
        public event EventHandler<MailArrivedEventArgs> MailArrived;

        protected virtual void OnMailArrived(MailArrivedEventArgs e)
        {
            //You are missing a step.
            //var handler = MailArrived;
            //if (null != handler)
            //{
            //    handler(this, args);
            //}
            //Or use C# 6 feature: MailArrived?.Invoke(this, args);
            if (MailArrived != null)
                MailArrived(this, e);
        }

        public void SimulateMailArrived()
        {
            MailArrivedEventArgs args = new MailArrivedEventArgs("Mail title", "content of mail");
            OnMailArrived(args);
        }
    }
}
