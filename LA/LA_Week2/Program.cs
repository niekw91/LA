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

            Console.Read();
        }
    }
}
