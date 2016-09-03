using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateXML();
        }

        private static void CreateXML()
        {
            var types = from type in typeof(string).Assembly.GetExportedTypes()
                        where type.IsClass
                        select new XElement("Type",
                        new XAttribute("FullName", type.FullName),
                        new XElement("Properties",
                        from prop in type.GetProperties()
                        select new XElement("Property",
                        new XAttribute("Name", prop.Name),
                        new XAttribute("Type", prop.PropertyType.FullName ?? "T"))),
                        new XElement("Methods",
                        from method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                        where !method.IsSpecialName
                        select new XElement("Method",
                        new XAttribute("Name", method.Name),
                        new XAttribute("ReturnType", method.ReturnType.FullName ?? "T"),
                        new XElement("Parameters",
                                            from parameters in method.GetParameters()
                                            select new XElement("Parameter",
                                                new XAttribute("Name", parameters.Name),
                                                new XAttribute("Type", parameters.ParameterType))))));

            var xmltypes = new XElement("Types", types);

            #region 3 a
            var noProperties = from type in types
                               where type.Element("Properties").Descendants().Count() == 0
                               let propertyName = (string)type.Attribute("FullName")
                               orderby propertyName
                               select propertyName;

            Console.WriteLine($"No Properties :{noProperties.Count()}");
            foreach (var property in noProperties)
                Console.WriteLine(property);
            #endregion

            #region 3 b
            Console.WriteLine($"Total number of methods :{types.Sum(m => m.Descendants("Method").Count())}");
            #endregion

            #region 3 c
            Console.WriteLine($"Total number of Properties :{types.Sum(m => m.Descendants("Property").Count())}");
            var parameter = from p in types.Descendants("Parameter")
                            group p
                            by (string)p.Attribute("Type")
                            into list
                            orderby list.Count() descending
                            select new
                            {
                                Name = list.Key,
                                Count = list.Count()
                            };

            Console.WriteLine($"the parameter most common is :{parameter.First().Name}");
            #endregion

            #region 3 d
            var typeByMethods = from t in types
                                orderby t.Descendants("Method").Count() descending
                                select new XElement("Type", new XAttribute("Name", t.FirstAttribute.Value),
                                new XAttribute("properties", t.Descendants("Property").Count()),
                                new XAttribute("Methods", t.Descendants("Method").Count()));
            var xmlMethods = new XElement("Types", typeByMethods); 
            #endregion

            #region 3 e
            var groupAllTypes = types.Descendants("Type")
                                .GroupBy(m => m.Descendants("Method").Count())
                                .OrderByDescending(m => m.Key)
                                .Select(m => m.OrderBy(v => v.Attribute("FullName").Value));
            #endregion

        }
    }
}
