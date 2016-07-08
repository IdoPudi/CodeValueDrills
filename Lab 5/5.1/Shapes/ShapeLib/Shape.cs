using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public abstract class Shape
    {
        public ConsoleColor Color { get; set; }
        public abstract double Area { get; }

        public Shape(ConsoleColor color)
        {
            Color = color;
        }

        public Shape()
        {
            Color = ConsoleColor.White;
        }

        public virtual void Display()
        {
            Console.BackgroundColor = Color;
        }
    }
}
