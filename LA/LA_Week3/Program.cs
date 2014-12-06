using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_Week3
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix m2 = new Matrix(3, 3);

            m2.PutValue(0, 0, 3);
            m2.PutValue(0, 1, 0);
            m2.PutValue(0, 2, 0);
            m2.PutValue(1, 0, 0);
            m2.PutValue(1, 1, 3);
            m2.PutValue(1, 2, 0);
            m2.PutValue(2, 0, 0);
            m2.PutValue(2, 1, 0);
            m2.PutValue(2, 2, 3);

            Matrix m = new Matrix(1, 3);

            m.PutValue(0, 0, 1);
            m.PutValue(1, 0, 0);
            m.PutValue(2, 0, 4);

            m2.Show();
            m.Show();

            Matrix result = m2.Multiply(m);

            result.Show();

            Console.Read();
        }
    }
}
