using ShapeLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeApp
{
    class ShapeManager
    {
        private ArrayList shapeList;

        public ShapeManager()
        {
            shapeList = new ArrayList();
        }

        public void AddShape(Shape newShape)
        {
            shapeList.Add(newShape);
        }

        public void DisplayAll()
        {
            foreach (Shape shape in shapeList)
            {
                shape.Display();
                Console.WriteLine($"shape area : {shape.Area}");
            }
        }

        public Shape this[int index] { get { return (Shape)shapeList[index]; } }

        public int Count => shapeList.Count;

        public void Save(StringBuilder sb)
        {
            foreach (var shape in shapeList)
            {
                if (shape.GetType() == typeof(Ellipse))
                    ((Ellipse)shape).Write(sb);
                if (shape.GetType() == typeof(Rectangle))
                    ((Rectangle)shape).Write(sb);
                if (shape.GetType() == typeof(Circle))
                    ((Circle)shape).Write(sb);
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
