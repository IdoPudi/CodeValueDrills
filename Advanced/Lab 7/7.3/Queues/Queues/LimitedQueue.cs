using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Queues
{
    public class LimitedQueue<T>
    {
        private Semaphore _semaphore;
        private Queue<T> _queue;
        private object _lock;

        public LimitedQueue(int maximumSize)
        {
            _semaphore = new Semaphore(maximumSize, maximumSize);
            _queue = new Queue<T>();
            _lock = new object();
        }

        public void Enque(T value)
        {
            _semaphore.WaitOne();
            lock(_lock)
            _queue.Enqueue(value);
        }

        public T Deque()
        {
            _semaphore.Release();
            lock (_lock)
                return _queue.Dequeue();

        }
    }
}
