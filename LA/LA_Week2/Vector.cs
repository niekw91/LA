using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_Week2
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
                Rows = 2;
                Columns = size;

                Data = new double[Rows][];
                for (int i = 0; i < Columns; i++)
                    Data[i] = new double[Columns];
            }
        }

        public Vector(int a1, int a2)
        {
            Rows = 2;
            Columns = 1;

            Data = new double[Rows][];
            for (int i = 0; i <= Columns; i++ )
                Data[i] = new double[Columns];

            Data[0][0] = a1;
            Data[1][0] = a2;
        }

        public Vector(int a1, int a2, int a3)
        {
            Rows = 3;
            Columns = 1;

            Data = new double[Rows][];
            for (int i = 0; i <= Columns; i++)
                Data[i] = new double[Columns];

            Data[0][0] = a1;
            Data[1][0] = a2;
            Data[2][0] = a3;
        }

        public void PutValue(int row, double value)
        {
            Data[row][0] = value;
        }

        //public void Show()
        //{
        //    for (int i = 0; i < Rows; i++)
        //        Console.WriteLine("[{0}]", Data[i][0]);
        //}
    }
}
