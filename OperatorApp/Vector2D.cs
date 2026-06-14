using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorApp
{
    public class Vector2D
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Vector2D() : this(0, 0) { }
        public Vector2D(double x, double y) { X = x; Y = y; }

        // Do dai vector (Euclidean norm)
        public double DoDai => Math.Sqrt(X * X + Y * Y);

        public static Vector2D operator +(Vector2D a, Vector2D b)
            => new Vector2D(a.X + b.X, a.Y + b.Y);

        public static Vector2D operator -(Vector2D a, Vector2D b)
            => new Vector2D(a.X - b.X, a.Y - b.Y);

        // Nhan scalar: Vector2D * double
        public static Vector2D operator *(Vector2D v, double k)
            => new Vector2D(v.X * k, v.Y * k);

        // Nhan scalar theo chieu nguoc: double * Vector2D (tinh giao hoan)
        public static Vector2D operator *(double k, Vector2D v)
            => v * k;

        // Unary minus: doi chieu vector
        public static Vector2D operator -(Vector2D v)
            => new Vector2D(-v.X, -v.Y);

        public override string ToString()
            => $"({X:F2}, {Y:F2})";
        // Yêu cầu nâng cao 
        //1: cài đặt operator == và != để so sánh 2 vector có bằng nhau hay không (cùng tọa độ x và y)
        public static bool operator ==(Vector2D a, Vector2D b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;

            return a.X == b.X && a.Y == b.Y;
        }

        public static bool operator !=(Vector2D a, Vector2D b)
        {
            return !(a == b);
        }
        public override bool Equals(object obj)
        {
            if (obj is Vector2D other)
                return this == other;

            return false;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
        //2. tích vô hướng (dot product)
        public static double operator *(Vector2D a, Vector2D b)
            => a.X * b.X + a.Y * b.Y;
        //3.Cài đặt toán tử chuyển đổi implicit từ (double x, double y) tuple sang Vector2D.
        //Để dùng: Vector2D v = (3.0, 4.0);
        public static implicit operator Vector2D((double x, double y) tuple)
            => new Vector2D(tuple.x, tuple.y);

    }

}
