using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SyncDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Mutex mutex = new Mutex(false,"SyncMutex"))
            {
                string path = @"c:\temp";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                for (int i = 0; i < 10000; i++)
                {
                    mutex.WaitOne();

                    try
                    {
                        using (var streamWriter = new StreamWriter(@"c:\temp\data.txt", true))
                        {
                            streamWriter.WriteLine($"Writing from process{Process.GetCurrentProcess().Id}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    finally
                    {
                        mutex.ReleaseMutex();
                    }
                }
            }
        }
    }
}
