using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSystem
{
    class Program
    {
        private static Timer timer;
        static void Main(string[] args)
        {
            MailManager manager = new MailManager();
            manager.MailArrived += manager_MailArrived;
            timer = new Timer(_ => manager.SimulateMailArrived(), null, 0, 1000);
            Console.ReadLine();
        }

        static void manager_MailArrived(object sender, MailArrivedEventArgs e)
        {
            Console.WriteLine($"{e.Title} : {e.Body}");
        }
    }
}
