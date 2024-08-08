using FrostyCliff.Core;
using Silk.NET.OpenGL;
using System.Numerics;

namespace FrostyCliff.Graphics
{
    public sealed class Sprite2D : RendererObject2D
    {
        private Texture2D _texture;

        public Sprite2D(Texture2D texture)
        {
            _texture = texture;
            _program = ShaderWorker.MakeShaderProgram(ref _gl, ShadersSource.SpriteVertexShader, ShadersSource.SpriteFragmentShader);
            BufferWorker.SpriteBuffer(ref _vbo, ref _vao, ref _ebo, ref _gl);
        }

        public Sprite2D(string path)
        {
            _texture = new Texture2D(path);
            _program = ShaderWorker.MakeShaderProgram(ref _gl, ShadersSource.SpriteVertexShader, ShadersSource.SpriteFragmentShader);
            BufferWorker.SpriteBuffer(ref _vbo, ref _vao, ref _ebo, ref _gl);
        }

        internal unsafe override void Draw(ref Transform2D transform, Matrix4x4 cameraMatrix)
        {
            _gl.UseProgram(_program);

            _gl.ActiveTexture(TextureUnit.Texture0);
            _gl.BindTexture(TextureTarget.Texture2D, _texture.Texture);

            var model = CalculateModel(ref transform);

            int modelLoc = _gl.GetUniformLocation(_program, "model");
            int cameraMatrixLoc = _gl.GetUniformLocation(_program, "cameraMatrix");

            unsafe
            {
                _gl.UniformMatrix4(modelLoc, 1, false, (float*)&model);
                _gl.UniformMatrix4(cameraMatrixLoc, 1, false, (float*)&cameraMatrix);
            }

            _gl.BindVertexArray(_vao);
            _gl.DrawElements(PrimitiveType.Triangles, 6, DrawElementsType.UnsignedInt, null);
            _gl.BindVertexArray(0);
            _gl.BindTexture(TextureTarget.Texture2D, 0);
            _gl.UseProgram(0);
        }

        public override void Dispose()
        {
            _gl.DeleteBuffer(_vbo);
            _gl.DeleteBuffer(_ebo);
            _gl.DeleteVertexArray(_vao);
            _texture.Dispose();
            _gl.DeleteProgram(_program);
        }

    }
}
