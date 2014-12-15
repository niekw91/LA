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
            //Opgave2();

            Opgave3();

            Console.Read();
        }

        private static void Opgave3()
        {
            Vector a, b, c;
            Double p = 0, q = 0, r = 0, s = 0;

            Console.WriteLine("// Opgave 3b a");
            p = 6;
            q = -3;
            r = 7;
            s = 12;
            InproductToVector(p, q, r, s, out a, out b, out c);
            Console.WriteLine("({0})    ({1})    ({2})", a.GetValue(0), b.GetValue(0), c.GetValue(0));
            Console.WriteLine("({0}) + L({1}) + U({2})", a.GetValue(1), b.GetValue(1), c.GetValue(1));
            Console.WriteLine("({0})    ({1})    ({2})\n", a.GetValue(2), b.GetValue(2), c.GetValue(2));

            Console.WriteLine("// Opgave 3b b");
            p = 0;
            q = 8;
            r = 13;
            s = 4;
            InproductToVector(p, q, r, s, out a, out b, out c);
            Console.WriteLine("({0})    ({1})    ({2})", a.GetValue(0), b.GetValue(0), c.GetValue(0));
            Console.WriteLine("({0}) + L({1}) + U({2})", a.GetValue(1), b.GetValue(1), c.GetValue(1));
            Console.WriteLine("({0})    ({1})    ({2})\n", a.GetValue(2), b.GetValue(2), c.GetValue(2));

            Console.WriteLine("// Opgave 3b c");
            p = 0;
            q = 0;
            r = 3;
            s = 18;
            NotZeroR(p, q, r, s, out a, out b, out c);
            Console.WriteLine("({0})    ({1})    ({2})", a.GetValue(0), b.GetValue(0), c.GetValue(0));
            Console.WriteLine("({0}) + L({1}) + U({2})", a.GetValue(1), b.GetValue(1), c.GetValue(1));
            Console.WriteLine("({0})    ({1})    ({2})\n", a.GetValue(2), b.GetValue(2), c.GetValue(2));

            Console.WriteLine("// Opgave 3b d");
            p = 1;
            q = 0;
            r = 0;
            s = 22;
            InproductToVector(p, q, r, s, out a, out b, out c);
            Console.WriteLine("({0})    ({1})    ({2})", a.GetValue(0), b.GetValue(0), c.GetValue(0));
            Console.WriteLine("({0}) + L({1}) + U({2})", a.GetValue(1), b.GetValue(1), c.GetValue(1));
            Console.WriteLine("({0})    ({1})    ({2})\n", a.GetValue(2), b.GetValue(2), c.GetValue(2));

            Console.WriteLine("// Opgave 3b e");
            p = 0;
            q = 1;
            r = -1;
            s = 8;
            InproductToVector(p, q, r, s, out a, out b, out c);
            Console.WriteLine("({0})    ({1})    ({2})", a.GetValue(0), b.GetValue(0), c.GetValue(0));
            Console.WriteLine("({0}) + L({1}) + U({2})", a.GetValue(1), b.GetValue(1), c.GetValue(1));
            Console.WriteLine("({0})    ({1})    ({2})\n", a.GetValue(2), b.GetValue(2), c.GetValue(2));

            Console.WriteLine("// Opgave 3b f");
            p = 1;
            q = 1;
            r = 1;
            s = 3;
            InproductToVector(p, q, r, s, out a, out b, out c);
            Console.WriteLine("({0})    ({1})    ({2})", a.GetValue(0), b.GetValue(0), c.GetValue(0));
            Console.WriteLine("({0}) + L({1}) + U({2})", a.GetValue(1), b.GetValue(1), c.GetValue(1));
            Console.WriteLine("({0})    ({1})    ({2})\n", a.GetValue(2), b.GetValue(2), c.GetValue(2));
        }

        private static void Opgave2()
        {
            Vector a, b, c, uitproduct;
            Console.WriteLine("// Opgave 2a");
            a = new Vector(0, 1, 0);
            b = new Vector(1, 0, 0);
            c = new Vector(0, 1, 0);
            uitproduct = Uitproduct(b, c);
            Console.WriteLine("s : {0}x + {1}y + {2}z = {3}\n", uitproduct.GetValue(0), uitproduct.GetValue(1), uitproduct.GetValue(2), inproduct(a, uitproduct));

            Console.WriteLine("// Opgave 2b");
            a = new Vector(1, 1, 0);
            b = new Vector(1, 0, 0);
            c = new Vector(0, 1, 0);
            uitproduct = Uitproduct(b, c);
            Console.WriteLine("s : {0}x + {1}y + {2}z = {3}\n", uitproduct.GetValue(0), uitproduct.GetValue(1), uitproduct.GetValue(2), inproduct(a, uitproduct));

            Console.WriteLine("// Opgave 2c");
            a = new Vector(1, 2, 1);
            b = new Vector(1, 2, 3);
            c = new Vector(6, 1, 7);
            uitproduct = Uitproduct(b, c);
            Console.WriteLine("s : {0}x + {1}y + {2}z = {3}\n", uitproduct.GetValue(0), uitproduct.GetValue(1), uitproduct.GetValue(2), inproduct(a, uitproduct));

            Console.WriteLine("// Opgave 2d");
            a = new Vector(1, 1, 1);
            b = new Vector(6, 6, 0);
            c = new Vector(1, 1, 0);
            uitproduct = Uitproduct(b, c);
            Console.WriteLine("s : {0}x + {1}y + {2}z = {3}\n", uitproduct.GetValue(0), uitproduct.GetValue(1), uitproduct.GetValue(2), inproduct(a, uitproduct));
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
        static Vector Uitproduct(Vector a, Vector b)
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

        static public void NotZeroP(double p, double q, double r, double s, out Vector vecP, out Vector vecQ, out Vector vecR)
        {
            if (p == 0)
                throw new Exception(String.Format("Error: p cannot be {0}",p));

            vecP = new Vector(s/p, 0, 0);
            vecQ = new Vector(-q, p, 0);
            vecR = new Vector(-r, 0, p);
        }

        static public void NotZeroQ(double p, double q, double r, double s, out Vector vecP, out Vector vecQ, out Vector vecR)
        {
            if (p != 0)
                throw new Exception(String.Format("Error: p cannot be {0}", p));
            if (q == 0)
                throw new Exception(String.Format("Error: q cannot be {0}", q));

            vecP = new Vector(0, s/q, 0);
            vecQ = new Vector(q, 0, 0);
            vecR = new Vector(0, -r, q);
        }

        static public void NotZeroR(double p, double q, double r, double s, out Vector vecP, out Vector vecQ, out Vector vecR)
        {
            if (p != 0)
                throw new Exception(String.Format("Error: p cannot be {0}", p));
            if (q != 0)
                throw new Exception(String.Format("Error: q cannot be {0}", q));
            if (r == 0)
                throw new Exception(String.Format("Error: r cannot be {0}", r));

            vecP = new Vector(0, 0, s / r);
            vecQ = new Vector(1, 0, 0);
            vecR = new Vector(0, 1, 0);
        }

        static public void InproductToVector(double p, double q, double r, double s, out Vector vecP, out Vector vecQ, out Vector vecR)
        {
            vecP = new Vector(0, 0, 0);
            vecQ = new Vector(0, 0, 0);
            vecR = new Vector(0, 0, 0);
            if (p != 0)
                NotZeroP(p, q, r, s, out vecP, out vecQ, out vecR);
            else if (p == 0 && q != 0)
                NotZeroQ(p, q, r, s, out vecP, out vecQ, out vecR);
            else if (p == 0 && q == 0 && r != 0)
                NotZeroR(p, q, r, s, out vecP, out vecQ, out vecR);
            else
                throw new Exception(String.Format("Error: input cannot be {0} {1} {2}",p,q,r));
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

        //static public Vector MultiplyVectors(Vector a, Vector b)
        //{
        //    if (a.Rows != b.Rows)
        //        return null;

        //    Vector result = new Vector(a.Rows);

        //    for (int i = 0; i < a.Rows; i++)
        //        result.Data[i][0] = a.Data[i][0] * b.Data[i][0];

        //    return result;
        //}

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
    }
}
