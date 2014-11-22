using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_Week1
{
    class Program
    {
        static double a, b, x1, x2, y1, y2, defaultx1, defaulty1, defaultx2, defaulty2, defaulta, defaultb, lambda, e, f, g, h, px, py, qx, qy;
        static string input;

        static void Main(string[] args)
        {
            defaultx1 = 1;
            defaulty1 = 3;
            defaultx2 = 3;
            defaulty2 = 7;
            defaulta = 1;
            defaultb = 2;

            while (true)
            {
                Console.Clear();
                Console.Write("Conversion: ");
                string conversion = Console.ReadLine();

                switch (conversion)
                {
                    case "1":
                        // Handle input
                        InputHandler(conversion);

                        // Conversion from 1 to 2
                        Console.WriteLine("\nConversion from 1 to 2");
                        From1To2(x1, x2, y1, y2, out a, out b);
                        Console.WriteLine(string.Format("y = {0}x + {1}", b, a));

                        // Conversion from 2 to 1
                        Console.WriteLine("\nConversion from 2 to 1");
                        From2To1(a, b, out x1, out x2, out y1, out y2);
                        Console.WriteLine(string.Format("x1 = {0}", x1));
                        Console.WriteLine(string.Format("y1 = {0}", y1));
                        Console.WriteLine(string.Format("x2 = {0}", x2));
                        Console.WriteLine(string.Format("y2 = {0}", y2));

                        Console.Read();
                        break;
                    case "2":
                        // Handle input
                        InputHandler(conversion);

                        // Conversion from 1 to 3
                        Console.WriteLine("\nConversion from 1 to 3");
                        From1To3(x1, y1, x2, y2, out e, out f, out g, out h, 2, out lambda);
                        Console.WriteLine(string.Format("(x) = ({0}) + {1} * ({2}) = ({3})", e, lambda, g, e + lambda * g));
                        Console.WriteLine(string.Format("(y) = ({0}) + {1} * ({2}) = ({3})", f, lambda, h, f + lambda * h));

                        // Conversion from 3 to 1
                        Console.WriteLine("\nConversion from 3 to 1");
                        From3To1(e, f, g, h, out px, out py, out qx, out qy);
                        Console.WriteLine(string.Format("px = ({0})", px));
                        Console.WriteLine(string.Format("py = ({0})", py));
                        Console.WriteLine(string.Format("qx = ({0})", qx));
                        Console.WriteLine(string.Format("qy = ({0})", qy));

                        Console.Read();
                        break;
                    case "3":
                        // Handle input
                        InputHandler(conversion);

                        // Conversion  from 2 to 3 
                        Console.WriteLine("\nConversion from 2 to 3");
                        From2To3(a, b, out e, out f, out g, out h, 2, out lambda);
                        Console.WriteLine(string.Format("(x) = ({0}) + {1} * ({2}) = ({3})", e, lambda, g, e + lambda * g));
                        Console.WriteLine(string.Format("(y) = ({0}) + {1} * ({2}) = ({3})", f, lambda, h, f + lambda * h));

                        // Conversion from 3 to 2
                        Console.WriteLine("\nConversion from 3 to 2");
                        From3To2(e, f, g, h, out a, out b);
                        Console.WriteLine(string.Format("y = {0}x + {1}", b, a));

                        Console.Read();
                        break;
                    default:
                        break;
                }
            }
        }

        static void InputHandler(string input)
        {
            switch (input)
            {
                case "1":
                case "2":
                    Console.Write(string.Format("x1 = default({0}) = ", defaultx1));
                    input = Console.ReadLine();
                    x1 = string.IsNullOrEmpty(input) ? defaultx1 : Convert.ToDouble(input);

                    Console.Write(string.Format("y1 = default({0}) = ", defaulty1));
                    input = Console.ReadLine();
                    y1 = string.IsNullOrEmpty(input) ? defaulty1 : Convert.ToDouble(input);

                    Console.Write(string.Format("x2 = default({0}) = ", defaultx2));
                    input = Console.ReadLine();
                    x2 = string.IsNullOrEmpty(input) ? defaultx2 : Convert.ToDouble(input);

                    Console.Write(string.Format("y2 = default({0}) = ", defaulty2));
                    input = Console.ReadLine();
                    y2 = string.IsNullOrEmpty(input) ? defaulty2 : Convert.ToDouble(input);
                    break;
                case "3":
                    Console.Write(string.Format("a = default({0}) = ", defaulta));
                    input = Console.ReadLine();
                    a = string.IsNullOrEmpty(input) ? defaulta : Convert.ToDouble(input);

                    Console.Write(string.Format("b = default({0}) = ", defaultb));
                    input = Console.ReadLine();
                    b = string.IsNullOrEmpty(input) ? defaultb : Convert.ToDouble(input);
                    break;
                default:
                    break;
            }
        }
        static void From1To2(double x1, double y1, double x2, double y2, out double a, out double b)
        {
            b = x2 - x1 != 0 ? (y2 - y1) / (x2 - x1) : 0;
            a = y1 - (b * x1);
        }
        static void From2To1(double a, double b, out double x1, out double y1, out double x2, out double y2)
        {
            x1 = 0 * b + 1;
            y1 = a * b + 1;
            x2 = 1 * b + 1;
            y2 = (a + b) * b + 1;
        }
        static void From1To3(double x1, double y1, double x2, double y2, out double e, out double f, out double g, out double h, double lambdain, out double lambda)
        {
            lambda = lambdain;
            e = x1;
            f = y1;
            g = (x2 - x1) / lambda;
            h = (y2 - y1) / lambda;
        }
        static void From3To1(double e, double f, double g, double h, out double px, out double py, out double qx, out double qy)
        {
            px = e;
            py = f;
            qx = e + 2 * g;
            qy = f + 2 * h;
        }
        static void From2To3(double a, double b, out double e, out double f, out double g, out double h, double lambdain, out double lambda)
        {
            lambda = lambdain;
            e = 0;
            f = a;
            g = 1;
            h = b;
        }
        static void From3To2(double e, double f, double g, double h, out double a, out double b)
        {
            b = g != 0 ? h / g : 0;
            a = f - (b * e);
        }
    }
}
