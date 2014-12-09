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
            // Opgave 2

            // Opgave 2a
            Vector a = new Vector(1, 1, 1);
            Vector b = new Vector(6, 6, 0);
            Vector c = new Vector(1, 1, 0);
            Console.WriteLine("(");
            MultiplyVectors(b,c).Show();
            Console.WriteLine(",");
            a.Show();
            Console.WriteLine(")");

            //Add(a, Add(Lambda(lambda, b), Lambda(mu, c))).Show();
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

        static public Vector Lambda(double lambda, Vector a)
        {
            for (int i = 0; i < a.Rows; i++)
                a.Data[i][0] = lambda * a.Data[i][0];
            return a;
        }

        static public Vector Add(Vector a, Vector b)
        {
            if (a.Rows != b.Rows)
                return null;

            Vector result = new Vector(a.Rows);

            for (int i = 0; i < a.Rows; i++)
                result.Data[i][0] = a.Data[i][0] + b.Data[i][0];

            return result;
        }

        static public Vector MultiplyVectors(Vector a, Vector b)
        {
            if (a.Rows != b.Rows)
                return null;

            Vector result = new Vector(a.Rows);

            for (int i = 0; i < a.Rows; i++)
                result.Data[i][0] = a.Data[i][0] * b.Data[i][0];

            return result;
        }

        static double hoek(Vector a, Vector b) 
        {
            double vecA = 0;
            double vecB = 0;

            for (int i = 0; i < a.Rows; i++)
            {
                vecA += Math.Pow(a.Data[i][0], 2);
                vecB += Math.Pow(b.Data[i][0], 2);
            }

            // Calculate norm of vectors
            double normA = Math.Sqrt(vecA);
            double normB = Math.Sqrt(vecB);

            // Determine angle
            double angle = inproduct(a, b) / (normA * normB);

            return Math.Cos(angle);
        }
    }
}
