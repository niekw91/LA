using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_Week5
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isInvertable;

            // Opgave 2a
            Console.WriteLine("# Opgave 2a");
            Matrix a = new Matrix(
                1, 0, 0, 0, 
                2, 1, 0, 0, 
                3, 2, 1, 0,
                4, 3, 2, 1);
            a.Show();

            Matrix inverseA = a.inverse(out isInvertable);
            if(isInvertable)
                inverseA.Show();

            // Opgave 2b
            Console.WriteLine("# Opgave 2b");
            Matrix b = new Matrix(
                 1,  2,  3,  4,
                 5,  6,  7,  8,
                 9, 10, 11, 12,
                13, 14, 15, 16);
            b.Show();

            Matrix inverseB = b.inverse(out isInvertable);
            if (isInvertable)
                inverseB.Show();

            // Opgave 2c
            Console.WriteLine("# Opgave 2c");
            Matrix c = new Matrix(
                0, 3, 2, 1,
                1, 0, 3, 2,
                2, 1, 0, 3,
                3, 2, 1, 0);
            c.Show();

            Matrix inverseC = c.inverse(out isInvertable);
            if (isInvertable)
                inverseC.Show();

            Console.ReadLine();
        }
    }
}
