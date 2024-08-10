using FrostyCliff.AssetsManager;
using FrostyCliff.Core;
using Silk.NET.OpenGL;
using System.Numerics;

namespace FrostyCliff.Graphics
{
    public sealed class Sprite2D : RendererObject2D
    {
        private Texture2D _texture;

        private Color _colorMask;
        public Color ColorMask
        {
            get => _colorMask;
            set
            {
                _colorMask.R = Math.Clamp(value.R, 0.0f, 1.0f);
                _colorMask.G = Math.Clamp(value.G, 0.0f, 1.0f);
                _colorMask.B = Math.Clamp(value.B, 0.0f, 1.0f);
                _colorMask.Alpha = Math.Clamp(value.Alpha, 0.0f, 1.0f);
            }
        }

        public Sprite2D(Texture2D texture)
        {
            _colorMask = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            _texture = texture;
            _program = ShaderWorker.MakeShaderProgram(ref _gl, ShadersSource.SpriteVertexShader, ShadersSource.SpriteFragmentShader);
            BufferWorker.SpriteBuffer(ref _vbo, ref _vao, ref _ebo, ref _gl);
        }

        public Sprite2D(Asset asset)
        {
            _colorMask = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            _texture = new Texture2D(asset);
            _program = ShaderWorker.MakeShaderProgram(ref _gl, ShadersSource.SpriteVertexShader, ShadersSource.SpriteFragmentShader);
            BufferWorker.SpriteBuffer(ref _vbo, ref _vao, ref _ebo, ref _gl);
        }

        public Vector2D GetOriginalTextureScale() => _texture.GetOriginalTextureSize();

        internal unsafe override void Draw(ref Transform2D transform, Matrix4x4 cameraMatrix)
        {
            _gl.UseProgram(_program);

            _gl.ActiveTexture(TextureUnit.Texture0);
            _gl.BindTexture(TextureTarget.Texture2D, _texture.Texture);

            var model = CalculateModel(ref transform);

            int modelLoc = _gl.GetUniformLocation(_program, "model");
            int cameraMatrixLoc = _gl.GetUniformLocation(_program, "cameraMatrix");
            int colorMaskLoc = _gl.GetUniformLocation(_program, "colorMask");

            unsafe
            {
                _gl.UniformMatrix4(modelLoc, 1, false, (float*)&model);
                _gl.UniformMatrix4(cameraMatrixLoc, 1, false, (float*)&cameraMatrix);
                _gl.Uniform4(colorMaskLoc, _colorMask.R, _colorMask.G, _colorMask.B, _colorMask.Alpha);
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
