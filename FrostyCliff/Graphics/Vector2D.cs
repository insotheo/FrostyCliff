using FrostyCliff.Core;
using System.Numerics;

namespace FrostyCliff.Graphics
{
    public class Vector2D
    {

        public float X;
        public float Y;

        public Vector2D(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static Vector2D ZeroVector2D()
        {
            return new Vector2D(0, 0);
        }

        public static Vector2D operator+(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static Vector2D operator +(Vector2D v1, float v2)
        {
            return new Vector2D(v1.X + v2, v1.Y + v2);
        }

        public static Vector2D operator -(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.X - v2.X, v1.Y - v2.Y);
        }

        public static Vector2D operator -(Vector2D v1, float v2)
        {
            return new Vector2D(v1.X - v2, v1.Y - v2);
        }

        public static Vector2D operator *(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.X * v2.X, v1.Y * v2.Y);
        }

        public static Vector2D operator *(Vector2D v1, float v2)
        {
            return new Vector2D(v1.X * v2, v1.Y * v2);
        }

        public static Vector2D operator /(Vector2D v1, Vector2D v2)
        {
            if(v2.X == 0 || v2.Y == 0)
            {
                Log.Error("Zero devision");
                return ZeroVector2D();
            }
            return new Vector2D(v1.X / v2.X, v1.Y / v2.Y);
        }

        public static Vector2D operator /(Vector2D v1, float v2)
        {
            if(v2 == 0)
            {
                Log.Error("Zero devision");
                return ZeroVector2D();
            }
            return new Vector2D(v1.X / v2, v1.Y / v2);
        }

        public override string ToString()
        {
            return $"{{ x = {X} ; y = {Y}}}";
        }

        public void Normalize()
        {
            if (X == 0 && Y == 0)
            {
                return;
            }
            float m = (float)System.Math.Sqrt(X * X + Y * Y);
            X /= m;
            Y /= m;
        }

    }
}
