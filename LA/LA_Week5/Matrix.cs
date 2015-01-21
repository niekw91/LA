using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_Week5
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

        public Matrix(params double[] a)
        {
            int val = 0;
            switch (a.Length)
            {
                case 9: // Matrix 3x3
                    Rows = 3;
                    Columns = 3;
                    Data = new double[Rows][];
                    for (int i = 0; i < Rows; i++)
                        Data[i] = new double[Columns];
                    val = 0;
                    for (int y = 0; y < Rows; y++)
                        for (int x = 0; x < Columns; x++)
                            Data[y][x] = a[val++];
                    break;
                case 16: // Matrix 4x4 
                    Rows = 4;
                    Columns = 4;
                    Data = new double[Rows][];
                    for (int i = 0; i < Rows; i++)
                        Data[i] = new double[Columns];
                    val = 0;
                    for (int y = 0; y < Rows; y++)
                        for (int x = 0; x < Columns; x++)
                            Data[y][x] = a[val++];
                    break;
                default:
                    throw new Exception("Invalid number of values, found '" + a.Length + "', must be '9' or '16'.");
            }
        }

        public void PutValue(int row, int col, double value)
        {
            this.Data[row][col] = value;
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
            string output = "";
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    output += String.Format("[{0}]", Data[i][j]);
                }
                output += "\n";
            }
            output += "\n";
            Console.WriteLine(output);
        }

        public Matrix inverse(out bool inverseExists)
        {
            inverseExists = this.Rows == this.Columns ? true : false;

            if (!inverseExists)
                throw new Exception("Inverse does not exist!");

            Matrix inverse = new Matrix(this.Rows, this.Columns);
            inverse.Data = InvertMatrix(this.Data);

            return inverse;
        }

        public double[][] InvertMatrix(double[][] A)
        {
            int n = A.Length;
            //e will represent each column in the identity matrix
            double[] e;
            //x will hold the inverse matrix to be returned
            double[][] x = new double[n][];
            for (int i = 0; i < n; i++)
            {
                x[i] = new double[A[i].Length];
            }
            /*
            * solve will contain the vector solution for the LUP decomposition as we solve
            * for each vector of x.  We will combine the solutions into the double[][] array x.
            * */
            double[] solve;

            //Get the LU matrix and P matrix (as an array)
            Tuple<double[][], int[]> results = LUPDecomposition(A);

            double[][] LU = results.Item1;
            int[] P = results.Item2;

            /*
            * Solve AX = e for each column ei of the identity matrix using LUP decomposition
            * */
            for (int i = 0; i < n; i++)
            {
                e = new double[A[i].Length];
                e[i] = 1;
                solve = LUPSolve(LU, P, e);
                for (int j = 0; j < solve.Length; j++)
                {
                    x[j][i] = solve[j];
                }
            }
            return x;
        }

        public double[] LUPSolve(double[][] LU, int[] pi, double[] b)
        {
            int n = LU.Length - 1;
            double[] x = new double[n + 1];
            double[] y = new double[n + 1];
            double suml = 0;
            double sumu = 0;
            double lij = 0;

            /*
            * Solve for y using formward substitution
            * */
            for (int i = 0; i <= n; i++)
            {
                suml = 0;
                for (int j = 0; j <= i - 1; j++)
                {
                    /*
                    * Since we've taken L and U as a singular matrix as an input
                    * the value for L at index i and j will be 1 when i equals j, not LU[i][j], since
                    * the diagonal values are all 1 for L.
                    * */
                    if (i == j)
                    {
                        lij = 1;
                    }
                    else
                    {
                        lij = LU[i][j];
                    }
                    suml = suml + (lij * y[j]);
                }
                y[i] = b[pi[i]] - suml;
            }
            //Solve for x by using back substitution
            for (int i = n; i >= 0; i--)
            {
                sumu = 0;
                for (int j = i + 1; j <= n; j++)
                {
                    sumu = sumu + (LU[i][j] * x[j]);
                }
                x[i] = (y[i] - sumu) / LU[i][i];
            }
            return x;
        }
        public Tuple<double[][], int[]> LUPDecomposition(double[][] A)
        {
            int n = A.Length - 1;
            /*
            * pi represents the permutation matrix.  We implement it as an array
            * whose value indicates which column the 1 would appear.  We use it to avoid 
            * dividing by zero or small numbers.
            * */
            int[] pi = new int[n + 1];
            double p = 0;
            int kp = 0;
            int pik = 0;
            int pikp = 0;
            double aki = 0;
            double akpi = 0;

            //Initialize the permutation matrix, will be the identity matrix
            for (int j = 0; j <= n; j++)
            {
                pi[j] = j;
            }

            for (int k = 0; k <= n; k++)
            {
                /*
                * In finding the permutation matrix p that avoids dividing by zero
                * we take a slightly different approach.  For numerical stability
                * We find the element with the largest 
                * absolute value of those in the current first column (column k).  If all elements in
                * the current first column are zero then the matrix is singluar and throw an
                * error.
                * */
                p = 0;
                for (int i = k; i <= n; i++)
                {
                    if (Math.Abs(A[i][k]) > p)
                    {
                        p = Math.Abs(A[i][k]);
                        kp = i;
                    }
                }
                if (p == 0)
                {
                    throw new Exception("singular matrix");
                }
                /*
                * These lines update the pivot array (which represents the pivot matrix)
                * by exchanging pi[k] and pi[kp].
                * */
                pik = pi[k];
                pikp = pi[kp];
                pi[k] = pikp;
                pi[kp] = pik;

                /*
                * Exchange rows k and kpi as determined by the pivot
                * */
                for (int i = 0; i <= n; i++)
                {
                    aki = A[k][i];
                    akpi = A[kp][i];
                    A[k][i] = akpi;
                    A[kp][i] = aki;
                }

                /*
                    * Compute the Schur complement
                    * */
                for (int i = k + 1; i <= n; i++)
                {
                    A[i][k] = A[i][k] / A[k][k];
                    for (int j = k + 1; j <= n; j++)
                    {
                        A[i][j] = A[i][j] - (A[i][k] * A[k][j]);
                    }
                }
            }
            return Tuple.Create(A, pi);
        }


    }
}
