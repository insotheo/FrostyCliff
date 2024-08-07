using Silk.NET.OpenGL;

namespace FrostyCliff.Graphics
{
    public sealed class Rectangle2D : RendererObject2D
    {
        private Color _color;

        public Rectangle2D(Color color)
        {
            _program = ShaderWorker.MakeShaderProgram(ref _gl, ShadersSource.FigureFragmentShader);
            BufferWorker.RectangleBuffer(ref _vbo, ref _vao, ref _ebo, ref _gl);
            _color = color;
        }

        internal unsafe override void Draw()
        {
            _gl.UseProgram(_program);
            _gl.BindVertexArray(_vao);

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
