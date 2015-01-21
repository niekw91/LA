using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_Week5
{
    public class Vector : Matrix
    {
        public Vector()
        {
            Rows = 2;
            Columns = 1;

            Data = new double[Rows][];
            Data[0] = new double[Columns];
        }

        public Vector(int size)
        {
            if (size > 3 || size < 2)
                Console.WriteLine("Invalid sizes for vector, use 2 or 3");
            else
            {
                Rows = size;
                Columns = 1;

                Data = new double[Rows][];
                for (int i = 0; i < Rows; i++)
                    Data[i] = new double[Columns];
            }
        }

        public Vector(params double[] a)
        {
            Rows = a.Length;
            Columns = 1;

            Data = new double[Rows][];
            for (int i = 0; i < Rows; i++)
                Data[i] = new double[Columns];

            for (int i = 0; i < Rows; i++)
                Data[i][0] = a[i];
        }

        public void PutValue(int row, double value)
        {
            Data[row][0] = value;
        }

        public double Value(int row)
        {
            return Data[row][0];
        }
    }
}
