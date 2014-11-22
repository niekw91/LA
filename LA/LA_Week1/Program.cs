using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_Week1
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b;
            From2To3(6, 3, 2, 8, out a, out b);
            Console.Write(a + "  B:" + b);
            Console.Read();
        }

        static void From1To2(double x1, double y1, double x2, double y2, out double a, out double b)
        {
            b = x2 - x1 != 0 ? (y2 - y1) / (x2 - x1) : 0;
            a = y1 - (b * x1);
        }

        static void From1To3(double x1, double y1, double x2, double y2)
        {

        }

        static void From2To3(double e, double f, double g, double h, out double a, out double b)
        {
            b = g != 0 ? h / g : 0;
            a = f - (b * e);
        }

    }
}
