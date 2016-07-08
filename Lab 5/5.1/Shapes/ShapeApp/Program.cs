using ShapeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ShapeManager shapeManager = new ShapeManager();

            Ellipse ellipse = new Ellipse(6, 4, ConsoleColor.Green);
            Rectangle rectangle = new Rectangle(4, 2);
            Circle circle = new Circle(5, ConsoleColor.Red);
            Ellipse ellipse1 = new Ellipse(3, 1, ConsoleColor.Blue);
            Rectangle rectangle1 = new Rectangle(7, 5);
            Circle circle1 = new Circle(2, ConsoleColor.DarkCyan);

            shapeManager.AddShape(ellipse);
            shapeManager.AddShape(rectangle);
            shapeManager.AddShape(circle);
            shapeManager.AddShape(ellipse1);
            shapeManager.AddShape(rectangle1);
            shapeManager.AddShape(circle1);

            shapeManager.DisplayAll();
        }
    }
}
