namespace FrostyCliff.Graphics
{
    internal static class ShadersSource
    {

        internal static string FigureVertexShader = @" 
            #version 330 core
            layout (location = 0) in vec2 aPosition;
            uniform mat4 model;
            uniform mat4 cameraMatrix;
            void main()
            {
                gl_Position = cameraMatrix * model * vec4(aPosition, 0.0, 1.0);
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


        internal static string SpriteFragmentShader = @"
            #version 330 core
            out vec4 FragColor;

            in vec2 TexCoord;
            uniform sampler2D texture1;
            uniform vec4 colorMask;            

            void main()
            {
                FragColor = texture(texture1, TexCoord) * colorMask;
            }
            ";

        internal static string SpriteVertexShader = @"
            #version 330 core
            layout(location = 0) in vec2 aPos;
            layout(location = 1) in vec2 aTexCoord;

            uniform mat4 model;
            uniform mat4 cameraMatrix;            

            out vec2 TexCoord;
            
            void main()
            {
                gl_Position = cameraMatrix * model * vec4(aPos, 0.0, 1.0);
                TexCoord = aTexCoord;
            }
            ";


    }
}
