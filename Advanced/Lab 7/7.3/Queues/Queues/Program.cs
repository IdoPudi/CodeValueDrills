using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            LimitedQueue<int> queue = new LimitedQueue<int>(30);

            for (int i = 0; i < 40; i++)
            {
                var threadNumber = i;
                ThreadPool.QueueUserWorkItem(t =>
                {
                    Console.WriteLine($"Enque thread: {threadNumber}");
                    queue.Enque(threadNumber);
                    Thread.Sleep(500);
                    Console.WriteLine($"Deque thread: {queue.Deque()}");
                });
            }
        }
    }
}
