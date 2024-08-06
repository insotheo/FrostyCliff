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


    }
}
