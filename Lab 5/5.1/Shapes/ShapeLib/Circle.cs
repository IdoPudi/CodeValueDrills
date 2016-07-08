using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Circle : Ellipse
    {
        public Circle(int radius) : base(radius, radius) { }
        public Circle(int radius, ConsoleColor c) : base(radius, radius, c) { }

        public override void Display()
        {
            Console.BackgroundColor = Color;
            Console.WriteLine("the radius is " + _smallRadius);
        }
    }
}
