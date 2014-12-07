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
            Vector a = new Vector(1, 2, 3);
            Vector b = new Vector(3, 4, 5);
            Console.WriteLine("Inproduct: {0}",inproduct(a,a));
            uitproduct(a, b).Show();
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
            uitproduct.PutValue(0,a.Data[1][0] * b.Data[2][0] - a.Data[2][0] * b.Data[1][0]);
            uitproduct.PutValue(1, a.Data[2][0] * b.Data[0][0] - a.Data[0][0] * b.Data[2][0]);
            uitproduct.PutValue(2, a.Data[0][0] * b.Data[1][0] - a.Data[1][0] * b.Data[0][0]);

            return uitproduct;
        }
    }
}
