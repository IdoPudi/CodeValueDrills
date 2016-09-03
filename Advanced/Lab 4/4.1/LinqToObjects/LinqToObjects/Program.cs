using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            LinqAssembly();
        }

        private static void LinqAssembly()
        {
            #region 1 a
            var publicInterfaces = from type in typeof(string).Assembly.GetTypes()
                                   where type.IsInterface && type.IsPublic
                                   orderby type.Name
                                   select new InterfacesItem
                                   {
                                       Name = type.Name,
                                       NumberOfMethods = type.GetMethods().Length
                                   };

            foreach (var item in publicInterfaces)
            {
                Console.WriteLine($"Interface name:{item.Name}, number:{item.NumberOfMethods}");
            }
            #endregion

            #region 1 b
            var processes = from process in Process.GetProcesses()
                            where process.Threads.Count < 5
                            orderby process.Id
                            select new ProcessItem
                            {
                                Id = process.Id,
                                Name = process.ProcessName,
                                Start = process.StartTime
                            };
            Console.WriteLine($"processes running on system: ");
            foreach (var item in processes)
            {
                Console.WriteLine($"process name:{item.Name}, Id:{item.Id}, start time:{item.Start}");
            }
            #endregion

            #region 1 c
            var processesPriority = from process in Process.GetProcesses()
                                    where process.Threads.Count < 5
                                    orderby process.Id
                                    group new ProcessItem
                                    {
                                        Id = process.Id,
                                        Name = process.ProcessName,
                                        Start = process.StartTime
                                    }
                                    by process.BasePriority;
            Console.WriteLine($"Processes Priority: ");
            foreach (var item in processesPriority)
            {
                Console.WriteLine($"Priority key:{item.Key}, number:{item.Count()}");
            }
            #endregion

            #region 1 d
            var numberOfThreads = Process.GetProcesses().Sum(t => t.Threads.Count);
            Console.WriteLine($"Total number of Threads");
            Console.WriteLine($"Number:{numberOfThreads}");
            #endregion

            #region 2
            ProcessItem pItem = new ProcessItem { Id = 1, Name = "test" };
            InterfacesItem iItem = new InterfacesItem { Name = "copy", NumberOfMethods = 5 };

            pItem.CopyTo(iItem);
            Console.WriteLine(iItem.Name); 
            #endregion

        }
    }

    public static class Extensions
    {
        public static void CopyTo(this object obj1, object obj2)
        {
            var obj1Properties = from property in obj1.GetType().GetProperties()
                                 where property.CanRead
                                 select property;

            var obj2Properties = from property in obj2.GetType().GetProperties()
                                 where property.CanWrite
                                 select property;

            var joinedProperties = from p1 in obj1Properties
                                   join p2 in obj2Properties on p1.Name equals p2.Name
                                   select new { obj1Property = p1, obj2Property = p2 };

            foreach (var item in joinedProperties)
            {
                item.obj2Property.SetValue(obj2, item.obj1Property.GetValue(obj1, null), null);
            }
        }
    }
}
