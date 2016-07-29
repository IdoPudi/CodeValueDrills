using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Rectangle : Shape
    {
        private readonly int _width;
        private readonly int _height;

        public Rectangle(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public Rectangle(int width, int height, ConsoleColor color) : base(color)
        {
            _width = width;
            _height = height;
        }

        public int Width
        {
            get { return _width; }
        }

        public int Height
        {
            get { return _height; }
        }

        public override double Area => Width * Height;

        public override void Display()
        {
            Console.BackgroundColor = Color;//This line should be 'base.Display()'
            Console.WriteLine($"width is : {Width}, height is : {Height}");
        }
    }
}
