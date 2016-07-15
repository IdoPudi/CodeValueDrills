using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DynamicXml
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic planets = DynamicXElement.Create(XElement.Load(@"C:\Courses\asp .net\Course\Advanced Labs\Lab 1\1.3\planets.xml"));
            var mercury = planets.Planet;       // first planet
            Console.WriteLine(mercury);
            var venus = planets["Planet", 1];   // second planet 
            Console.WriteLine(venus);
            var ourMoon = planets["Planet", 2].Moons.Moon;
            Console.WriteLine(ourMoon);
            var marsMoon = planets["Planet", 3]["Moons", 0].Moon; // mars second moon
            Console.WriteLine(marsMoon);
        }
    }
}
