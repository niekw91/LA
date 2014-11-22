using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_Week2
{
    public class Matrix
    {
        public int Columns { get; set; }
        public int Rows { get; set; }
        public double[][] Data { get; set; }

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

            int vectorColumn = 0;
            while (n.Columns > vectorColumn)
            {
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        matrix.Data[i][vectorColumn] += (Data[i][j] * n.Data[j][vectorColumn]);
                    }
                }
                vectorColumn++;
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
