using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_Week3
{
    public class Matrix3D : Matrix
    {
        public Matrix3D(int col, int row)
            : base(col, row)
        {

        }
        public Matrix Scale(double x, double y, double z)
        {
            Matrix3D scale = new Matrix3D(1, 3);
            scale.PutValue(0, 0, x);
            scale.PutValue(1, 0, y);
            scale.PutValue(2, 0, z);

            Matrix result = this.Multiply(scale);

            return result;
        }

        public Matrix Translate(double x, double y, double z)
        {
            Matrix3D translationMatrix = new Matrix3D(1, 4);
            translationMatrix.PutValue(0, 0, x);
            translationMatrix.PutValue(1, 0, y);
            translationMatrix.PutValue(2, 0, z);
            translationMatrix.PutValue(3, 0, 1);

            Matrix result = this.Multiply(translationMatrix);

            return result;
        }

        protected Matrix RotateOverX(double alpha)
        {
            double sin = Math.Sin(alpha);
            double cos = Math.Cos(alpha);

            Matrix rotated = this;

            rotated.PutValue(1, 1, cos);
            rotated.PutValue(1, 2, -sin);
            rotated.PutValue(2, 1, sin);
            rotated.PutValue(2, 2, cos);

            return rotated;
        }

        protected Matrix RotateOverY(double alpha)
        {
            double sin = Math.Sin(alpha);
            double cos = Math.Cos(alpha);

            Matrix rotated = this;

            rotated.PutValue(0, 0, cos);
            rotated.PutValue(0, 2, sin);
            rotated.PutValue(2, 0, -sin);
            rotated.PutValue(2, 2, cos);

            return rotated;
        }

        protected Matrix RotateOverZ(double alpha)
        {
            double sin = Math.Sin(alpha);
            double cos = Math.Cos(alpha);

            Matrix rotated = this;

            rotated.PutValue(0, 0, cos);
            rotated.PutValue(0, 1, -sin);
            rotated.PutValue(1, 0, sin);
            rotated.PutValue(1, 1, cos);

            return rotated;
        }

        public Matrix Rotate(double alpha, double x, double y, double z)
        {
            return this;
        }

        public Matrix Rotate(double alpha, double x, double y, double z, double Mx, double My, double Mz)
        {
            if (alpha == 0.0)
            {
                //return identity matrix
            }

            double sin = Math.Sin(alpha);
            double cos = Math.Cos(alpha);

            Matrix rotate = this;

            rotate.PutValue(0, 0, Mx + (1 - Mx) * cos);
            rotate.PutValue(0, 1, My * (1 - cos) + z * sin);
            rotate.PutValue(0, 2, Mz * (1 - cos) - y * sin);

            rotate.PutValue(2, 0, Mz * (1 - cos) - y * sin);
            rotate.PutValue(2, 0, Mz * (1 - cos) - y * sin);
            rotate.PutValue(2, 0, Mz * (1 - cos) - y * sin);
            matrix[0, 1] = xy * (1 - cos) - z * sin;
            matrix[1, 1] = yy + (1 - yy) * cos;
            matrix[2, 1] = yz * (1 - cos) + x * sin;

            matrix[0, 2] = xz * (1 - cos) + y * sin;
            matrix[1, 2] = yz * (1 - cos) - x * sin;
            matrix[2, 2] = zz + (1 - zz) * cos;


            return new Matrix4(matrix);
        }
    }
}
