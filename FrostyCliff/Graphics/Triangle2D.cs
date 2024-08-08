using FrostyCliff.Core;
using Silk.NET.OpenGL;
using System.Numerics;

namespace FrostyCliff.Graphics
{
    public sealed class Triangle2D : RendererObject2D
    {
        private Color _color;

        public Triangle2D(Color color)
        {
            _color = color;
            _program = ShaderWorker.MakeShaderProgram(ref _gl, ShadersSource.FigureVertexShader, ShadersSource.FigureFragmentShader);
            BufferWorker.TriangleBuffer(ref _vbo, ref _vao, ref _ebo, ref _gl);
        }

        internal unsafe override void Draw(ref Transform2D transform, Matrix4x4 cameraMatrix)
        {
            _gl.UseProgram(_program);
            _gl.BindVertexArray(_vao);

            Matrix4x4 model = CalculateModel(ref transform);

            int modelLoc = _gl.GetUniformLocation(_program, "model");
            _gl.UniformMatrix4(modelLoc, 1, false, (float*)&model);

            int cameraMatrixLoc = _gl.GetUniformLocation(_program, "cameraMatrix");
            _gl.UniformMatrix4(cameraMatrixLoc, 1, false, (float*)&cameraMatrix);

            int colorLoc = _gl.GetUniformLocation(_program, "uColor");
            _gl.Uniform4(colorLoc, _color.R, _color.G, _color.B, _color.Alpha);

            _gl.DrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, null);
            _gl.BindVertexArray(0);
            _gl.UseProgram(0);
        }

        public override void Dispose()
        {
            _gl.DeleteBuffer(_vbo);
            _gl.DeleteBuffer(_ebo);
            _gl.DeleteVertexArray(_vao);
            _gl.DeleteProgram(_program);
        }

    }
}
