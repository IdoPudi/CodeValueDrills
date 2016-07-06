using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowMulBoard();
        }

        private static void ShowMulBoard()
        {
            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                    Console.Write("{0,4}", i * j);
                Console.WriteLine();
            }
        }
    }
}
