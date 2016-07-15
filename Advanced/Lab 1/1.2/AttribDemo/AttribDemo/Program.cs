using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AnalayzeAssembly(Assembly.GetExecutingAssembly()));
            Console.ReadLine();
        }

        public static bool AnalayzeAssembly(Assembly assemblyObject)
        {
            var types = assemblyObject.GetTypes();
            bool flag = false;
            foreach (var item in types)
            {
                var attributes = item.GetCustomAttributes(typeof(CodeReviewAttribute), false);
                foreach (CodeReviewAttribute customAttributes in attributes)
                {
                    Console.WriteLine($"name : {customAttributes.ReviewerName} date: {customAttributes.ReviewDate} approved: {customAttributes.IsApproved}");
                    if (customAttributes.IsApproved)
                        flag = true;
                }
            }
            return flag;
        }
    }
}
