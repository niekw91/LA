using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_Week4
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector a, b, c;
            Console.WriteLine("// Opgave 2a");
            a = new Vector(0, 1, 0);
            b = new Vector(1, 0, 0);
            c = new Vector(0, 1, 0);
            Console.WriteLine("(");
            MultiplyVectors(b, c).Show();
            Console.WriteLine(",");
            a.Show();
            Console.WriteLine(")");

            Console.WriteLine("// Opgave 2b");
            a = new Vector(1, 1, 0);
            b = new Vector(1, 0, 0);
            c = new Vector(0, 1, 0);
            Console.WriteLine("(");
            MultiplyVectors(b, c).Show();
            Console.WriteLine(",");
            a.Show();
            Console.WriteLine(")");

            Console.WriteLine("// Opgave 2c");
            a = new Vector(1, 2, 1);
            b = new Vector(1, 2, 3);
            c = new Vector(6, 1, 7);
            Console.WriteLine("(");
            MultiplyVectors(b, c).Show();
            Console.WriteLine(",");
            a.Show();
            Console.WriteLine(")");

            Console.WriteLine("// Opgave 2d");
            a = new Vector(1, 1, 1);
            b = new Vector(6, 6, 0);
            c = new Vector(1, 1, 0);
            Console.WriteLine("(");
            MultiplyVectors(b, c).Show();
            Console.WriteLine(",");
            a.Show();
            Console.WriteLine(")");

            Console.WriteLine("\n");

            Console.WriteLine("// Opgave 3b a");
            NotZeroP(6, 3, 7, out a, out b, out c);
            a.Show();
            b.Show();
            c.Show();

            Console.Read();
        }

        // Opgave 1a
        static double inproduct(Vector a, Vector b)
        {
            double inproduct = 0;

            // Check if vectors have same dimension
            if (a.Rows != b.Rows)
                return inproduct;

            // Calculate inproduct
            for (int i = 0; i < a.Rows; i++)
                inproduct += a.Data[i][0] * b.Data[i][0];

            return inproduct;
        }

        // Opgave 1b
        static Vector uitproduct(Vector a, Vector b)
        {
            Vector uitproduct = null;

            // Check if vectors dimension is 3 and equal
            if (a.Rows != 3 && b.Rows != 3 && a.Rows != b.Rows)
                return uitproduct;

            // Calculate uitproduct
            uitproduct = new Vector(0,0,0);
            uitproduct.PutValue(0, a.Data[1][0] * b.Data[2][0] - a.Data[2][0] * b.Data[1][0]);
            uitproduct.PutValue(1, a.Data[2][0] * b.Data[0][0] - a.Data[0][0] * b.Data[2][0]);
            uitproduct.PutValue(2, a.Data[0][0] * b.Data[1][0] - a.Data[1][0] * b.Data[0][0]);

            return uitproduct;
        }

        //static public Vector Lambda(double lambda, Vector a)
        //{
        //    for (int i = 0; i < a.Rows; i++)
        //        a.Data[i][0] = lambda * a.Data[i][0];
        //    return a;
        //}

        //static public Vector Add(Vector a, Vector b)
        //{
        //    if (a.Rows != b.Rows)
        //        return null;

        //    Vector result = new Vector(a.Rows);

        //    for (int i = 0; i < a.Rows; i++)
        //        result.Data[i][0] = a.Data[i][0] + b.Data[i][0];

        //    return result;
        //}

        static public Vector MultiplyVectors(Vector a, Vector b)
        {
            if (a.Rows != b.Rows)
                return null;

            Vector result = new Vector(a.Rows);

            for (int i = 0; i < a.Rows; i++)
                result.Data[i][0] = a.Data[i][0] * b.Data[i][0];

            return result;
        }

        //static double hoek(Vector a, Vector b) 
        //{
        //    double vecA = 0;
        //    double vecB = 0;

        //    for (int i = 0; i < a.Rows; i++)
        //    {
        //        vecA += Math.Pow(a.Data[i][0], 2);
        //        vecB += Math.Pow(b.Data[i][0], 2);
        //    }

        //    // Calculate norm of vectors
        //    double normA = Math.Sqrt(vecA);
        //    double normB = Math.Sqrt(vecB);

        //    // Determine angle
        //    double angle = inproduct(a, b) / (normA * normB);

        //    return Math.Cos(angle);
        //}

        static public void NotZeroP(double p, double q, double r, out Vector vecP, out Vector vecQ, out Vector vecR)
        {
            if (p == 0)
                throw new Exception(String.Format("Error: p cannot be {0}",p));

            double s = p + q + r;
            vecP = new Vector(s/p, 0, 0);
            vecQ = new Vector(q * -1, p, 0);
            vecR = new Vector(r * -1, 0, p);
        }

        static public void NotZeroQ(double q, double r, out Vector vecP, out Vector vecQ, out Vector vecR)
        {
            double p = 0;
            if (q == 0)
                throw new Exception(String.Format("Error: q cannot be {0}", q));

            double s = p + q + r;
            vecP = new Vector(0, s/q, 0);
            vecQ = new Vector(q, 0, 0);
            vecR = new Vector(0, r * -1, q);
        }

        static public void NotZeroR(double r, out Vector vecP, out Vector vecQ, out Vector vecR)
        {
            double p = 0, q = 0;
            if (r == 0)
                throw new Exception(String.Format("Error: r cannot be {0}", r));

            double s = p + q + r;
            vecP = new Vector(0, 0, s / r);
            vecQ = new Vector(1, 0, 0);
            vecR = new Vector(0, 1, 0);
        }
    }
}
