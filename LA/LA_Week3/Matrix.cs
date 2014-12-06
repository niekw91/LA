using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_Week3
{
    public class Matrix
    {
        public int Columns { get; set; }
        public int Rows { get; set; }
        public double[][] Data { get; set; }

        public Matrix()
        {
            Rows = 2;
            Columns = 2;

            Data = new double[Rows][];
            Data[0] = new double[Columns];
        }

        public Matrix(int col, int row)
        {
            Columns = col;
            Rows = row;

            Data = new double[Rows][];
            for (int i = 0; i < Rows; i++)
                Data[i] = new double[Columns];
        }

        public void PutValue(int row, int col, double value)
        {
            Data[row][col] = value;
        }

        public Matrix Multiply(Matrix n)
        {
            if (Columns != n.Rows)
                return null;

            Matrix matrix = new Matrix(n.Columns, n.Rows);

            for (int i = 0; i < Rows; i++)
            {
                for (int c = 0; c < n.Columns; c++)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        matrix.Data[i][c] += (Data[i][j] * n.Data[j][c]);
                    }
                }
            }
            return matrix;
        }

        public void Show()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write("[{0}]", Data[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
