using FrostyCliff.Core;
using Silk.NET.OpenGL;

namespace FrostyCliff.Graphics
{
    internal static class ShaderWorker
    {
        internal static uint MakeShaderProgram(ref GL gl, string fragmentShaderSource)
        {
            uint vertex = gl.CreateShader(ShaderType.VertexShader);
            gl.ShaderSource(vertex, ShadersSource.VertexShader);
            gl.CompileShader(vertex);
            CheckShaderCompileStatus(gl, vertex);

            uint fragment = gl.CreateShader(ShaderType.FragmentShader);
            gl.ShaderSource(fragment, fragmentShaderSource);
            gl.CompileShader(fragment);
            CheckShaderCompileStatus(gl, fragment);

            uint shaderProgram = gl.CreateProgram();
            gl.AttachShader(shaderProgram, vertex);
            gl.AttachShader(shaderProgram, fragment);
            gl.LinkProgram(shaderProgram);
            CheckProgramLinkStatus(gl, shaderProgram);

            gl.DeleteShader(vertex);
            gl.DeleteShader(fragment);

            return shaderProgram;
        }


        private static void CheckShaderCompileStatus(GL gl, uint shader)
        {
            string infoLog = gl.GetShaderInfoLog(shader);
            if (!string.IsNullOrWhiteSpace(infoLog))
            {
                Log.Error($"Error compiling shader: {infoLog}");
            }
        }

        private static void CheckProgramLinkStatus(GL gl, uint program)
        {
            string infoLog = gl.GetProgramInfoLog(program);
            if (!string.IsNullOrWhiteSpace(infoLog))
            {
                Log.Error($"Error linking program: {infoLog}");
            }
        }

    }
}
