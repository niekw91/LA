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
            // Variable declaration
            double a, b, x1, x2, y1, y2, e, f, g, h;

            Console.WriteLine("// Table Row 1");
            From1To2(6, 3, 2, 8, out a, out b);
            Console.WriteLine("y = {0} + {1}x\n", a, b);

            From1To3(6, 3, 2, 8, out e, out f, out g, out h);
            Console.WriteLine("(x)   ({0})    ({1})", e, g);
            Console.WriteLine("(y) = ({0}) + L({1})\n", f, h);

            Console.WriteLine("// Table Row 2");
            From2To1(6.34, 6.34, out x1, out y1, out x2, out y2);
            Console.WriteLine("A({0} {1}) B({2} {3})\n", x1, y1, x2, y2);

            From2To3(6.34, 6.34, out e, out f, out g, out h);
            Console.WriteLine("(x)   ({0})    ({1})", e, g);
            Console.WriteLine("(y) = ({0}) + L({1})\n", f, h);

            Console.WriteLine("// Table Row 3");
            From3To1(3, 3, 1, 1, out x1, out y1, out x2, out y2);
            Console.WriteLine("A({0} {1}) B({2} {3})\n", x1, y1, x2, y2);

            From3To2(3, 3, 1, 1, out a, out b);
            Console.WriteLine("y = {0} + {1}x\n", a, b);

            Console.WriteLine("// Table Row 4");
            From1To2(0.34, 0.62, 0.34, 1.62, out a, out b);
            Console.WriteLine("y = {0} + {1}x\n", a, b);

            From1To3(0.34, 0.62, 0.34, 1.62, out e, out f, out g, out h);
            Console.WriteLine("(x)   ({0})    ({1})", e, g);
            Console.WriteLine("(y) = ({0}) + L({1})\n", f, h);

            Console.WriteLine("// Table Row 5");
            From2To1(32, 64, out x1, out y1, out x2, out y2);
            Console.WriteLine("A({0} {1}) B({2} {3})\n", x1, y1, x2, y2);

            From2To3(32, 64, out e, out f, out g, out h);
            Console.WriteLine("(x)   ({0})    ({1})", e, g);
            Console.WriteLine("(y) = ({0}) + L({1})\n", f, h);

            Console.WriteLine("// Table Row 6");
            From3To1(0.04, 3.34, 0, 1.21, out x1, out y1, out x2, out y2);
            Console.WriteLine("A({0} {1}) B({2} {3})\n", x1, y1, x2, y2);

            From3To2(0.04, 3.34, 0, 1.21, out a, out b);
            Console.WriteLine("y = {0} + {1}x\n", a, b);

            Console.WriteLine("// Table Row 7");
            From1To2(234, 445, 612, 823, out a, out b);
            Console.WriteLine("y = {0} + {1}x\n", a, b);

            From1To3(234, 445, 612, 823, out e, out f, out g, out h);
            Console.WriteLine("(x)   ({0})    ({1})", e, g);
            Console.WriteLine("(y) = ({0}) + L({1})\n", f, h);

            Console.WriteLine("// Table Row 8");
            From3To1(4, 2, 0, 0, out x1, out y1, out x2, out y2);
            Console.WriteLine("A({0} {1}) B({2} {3})\n", x1, y1, x2, y2);

            From3To2(4, 2, 0, 0, out a, out b);
            Console.WriteLine("y = {0} + {1}x\n", a, b);

            // Pause
            Console.Read();
        }
        static void From1To2(double x1, double y1, double x2, double y2, out double a, out double b)
        {
            a = 0;
            b = 0;
            try
            {
                if (x2 - x1 == 0)
                    throw new Exception(String.Format("Exception: x2 minus x1 cannot be {0}", (x2 - x1)));

                b = (y2 - y1) / (x2 - x1);
                a = y1 - (b * x1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void From2To1(double a, double b, out double x1, out double y1, out double x2, out double y2)
        {
            x1 = 0;
            y1 = a + b * x1;
            x2 = 1;
            y2 = a + b * x2;
        }
        static void From1To3(double x1, double y1, double x2, double y2, out double e, out double f, out double g, out double h)
        {
            double lambda = 2;
            e = x1;
            f = y1;
            g = (x2 - x1) / lambda;
            h = (y2 - y1) / lambda;
        }
        static void From3To1(double e, double f, double g, double h, out double x1, out double y1, out double x2, out double y2)
        {
            double lambda = 0;
            x1 = e + lambda * g;
            y1 = f + lambda * h;
            lambda = 1;
            x2 = e + lambda * g;
            y2 = f + lambda * h;
        }
        static void From2To3(double a, double b, out double e, out double f, out double g, out double h)
        {
            e = 0;
            f = a;
            g = 1;
            h = b;
        }
        static void From3To2(double e, double f, double g, double h, out double a, out double b) 
        {
            a = 0;
            b = 0;
            try
            {
                if (g == 0)
                    throw new Exception(String.Format("Exception: g cannot be {0}", g));
                b = h / g;
                a = f - (b * e);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
