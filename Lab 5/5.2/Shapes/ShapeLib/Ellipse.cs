using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLib
{
    public class Ellipse : Shape , IPersist , IComparable
    {
        public readonly int _smallRadius;
        public readonly int _bigRadius;

        public Ellipse(int smallR, int bigR) : base()
        {
            _smallRadius = smallR;
            _bigRadius = bigR;
        }

        public Ellipse(int smallR, int bigR, ConsoleColor c) : base(c)
        {
            _smallRadius = smallR;
            _bigRadius = bigR;
        }

        public override double Area
        {
            get { return Math.Pow((double)(_smallRadius + _bigRadius) / 2, 2) * Math.PI; }
        }

        public override void Display()
        {
            Console.BackgroundColor = Color;
            Console.WriteLine($"small radius is : {_smallRadius}, big radius is : {_bigRadius}");
        }

        public void Write(StringBuilder sb)
        {
            sb.AppendLine($"small radius is : {_smallRadius}, big radius is : {_bigRadius}");
        }

        public int CompareTo(object obj)
        {
            dynamic shape = obj;
            if (this.Area > shape.Area)
                return 1;
            else if (this.Area == shape.Area)
                return 0;
            return -1;
        }
    }
}
