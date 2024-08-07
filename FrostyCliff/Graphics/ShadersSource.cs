namespace FrostyCliff.Graphics
{
    internal static class ShadersSource
    {

        internal static string FigureVertexShader = @" 
            #version 330 core
            layout (location = 0) in vec2 aPosition;
            uniform mat4 model;
            void main()
            {
                gl_Position = model * vec4(aPosition, 0.0, 1.0);
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
