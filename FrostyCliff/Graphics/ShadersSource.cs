namespace FrostyCliff.Graphics
{
    internal static class ShadersSource
    {

        internal static string VertexShader = @" 
            #version 330 core
            layout (location = 0) in vec2 aPosition;
            void main()
            {
                gl_Position = vec4(aPosition, 0.0, 1.0);
            }
            ";

        internal static string FigureFragmentShader = @"
            #version 330 core
            out vec4 out_color;
            uniform vec4 uColor;
            void main()
            {
                out_color = uColor;
            }
            ";

    }
}
