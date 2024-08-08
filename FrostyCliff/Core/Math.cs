using FrostyCliff.Graphics;
using static System.Math;

namespace FrostyCliff.Core
{
    public static class Math
    {

        public static float PI = 3.1415926535f;

        public static float DegToRad(float deg) => (deg * PI) / 180;

        public static float RadToDeg(float rad) => (180 * rad) / PI;

        public static float RadToTheFirstCircle(float rad)
        {
            while(rad < PI)
            {
                rad += 2 * PI;
            }
            while(rad > 2 * PI)
            {
                rad -= 2 * PI;
            }
            return rad;
        }

        public static float EuclideanDistance(Vector2D pointOne, Vector2D pointTwo) => (float)Sqrt(Pow((pointOne.X - pointTwo.X), 2) + Pow((pointOne.Y - pointTwo.Y), 2));

        public static float Clamp(float  value, float min, float max)
        {
            if (value <= min) return min;
            if (value >= max) return max;
            else return value;
        }

    }
}
