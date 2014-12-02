using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_Week2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Opdracht 1
            Console.WriteLine("Opdracht 1:");
            //Opdracht1();
            Console.WriteLine("");

            // Opdracht 2e
            Console.WriteLine("Opdracht 2e:");
            Opdracht2();
            Console.WriteLine("");

            // Opdracht 3b
            Console.WriteLine("Opdracht 3b:");
            Matrix velocityMatrix;
            double velocity;
            Console.WriteLine("Enter velocity:");
            if (Double.TryParse(Console.ReadLine(), out velocity))
            {
                velocityMatrix = Scale(velocity);
                velocityMatrix.Show();
            }
            Console.WriteLine("");

            Console.Read();
        }

        private static Matrix Scale(double velocity)
        {
            double sx = 1 + velocity / 200;
            double sy = 1 - velocity / 400;
            Matrix m = new Matrix(2, 2);
            m.PutValue(0, 0, sx);
            m.PutValue(1, 0, 0);
            m.PutValue(0, 1, 0);
            m.PutValue(1, 1, sy);

            return m;
        }

        private static void Opdracht2()
        {
            Console.WriteLine("Translatiematrix 1");
            Matrix t1 = new Matrix(3, 3);
            t1.PutValue(0, 0, 1);
            t1.PutValue(1, 0, 0);
            t1.PutValue(2, 0, 0);
            t1.PutValue(0, 1, 0);
            t1.PutValue(1, 1, 1);
            t1.PutValue(2, 1, 0);
            t1.PutValue(0, 2, 25);
            t1.PutValue(1, 2, 50);
            t1.PutValue(2, 2, 1);
            t1.Show();

            Console.WriteLine("Rotatiematrix");
            Matrix r = new Matrix(3, 3);
            r.PutValue(0, 0, 0.8);
            r.PutValue(1, 0, 0.6);
            r.PutValue(2, 0, 0);
            r.PutValue(0, 1, -0.6);
            r.PutValue(1, 1, 0.8);
            r.PutValue(2, 1, 0);
            r.PutValue(0, 2, 0);
            r.PutValue(1, 2, 0);
            r.PutValue(2, 2, 1);
            r.Show();

            Console.WriteLine("Translatiematrix 2");
            Matrix t2 = new Matrix(3, 3);
            t2.PutValue(0, 0, 1);
            t2.PutValue(1, 0, 0);
            t2.PutValue(2, 0, 0);
            t2.PutValue(0, 1, 0);
            t2.PutValue(1, 1, 1);
            t2.PutValue(2, 1, 0);
            t2.PutValue(0, 2, -25);
            t2.PutValue(1, 2, -50);
            t2.PutValue(2, 2, 1);
            t2.Show();

            Console.WriteLine("Result");
            Matrix result = t2.Multiply(r).Multiply(t1);
            result.Show();
        }

        private static void Opdracht1()
        {
            Matrix m = new Matrix(3, 3);

            int value = 1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    m.PutValue(i, j, value++);
                }
            }

            Matrix m2 = new Matrix(2, 3);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    m2.PutValue(i, j, i + 1);
                }
            }

            m.Show();
            m2.Show();

            Matrix result = m.Multiply(m2);

            result.Show();
        }
    }
}
