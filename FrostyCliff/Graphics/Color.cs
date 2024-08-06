namespace FrostyCliff.Graphics
{
    public sealed class Color
    {
        public float R, G, B, Alpha;

        public Color(float r, float g, float b, float a = 1.0f)
        {
            R = r;
            G = g;
            B = b;
            Alpha = a;
        }

        public override string ToString()
        {
            return $"{{ R = {R} ; G = {G} ; B = {B} ; alpha = {Alpha}}}";
        }

    }
}
