using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_Week2
{
    public class Vector
    {
        public int Size { get; set; }
        public double[] Data { get; set; }

        public Vector(int size)
        {
            if (size > 3 || size < 2)
                Console.WriteLine("Invalid sizes for vector, use 2 or 3");
            else
            {
                Size = size;

                Data = new double[Size];
            }
        }

        public void PutValue(int row, double value)
        {
            Data[row] = value;
        }

        public void Show()
        {
            for (int i = 0; i < Size; i++)
            {
                Console.WriteLine("[{0}]", Data[i]);
            }
        }
    }
}
