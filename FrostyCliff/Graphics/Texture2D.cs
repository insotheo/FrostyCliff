using System;
using System.IO;
using FrostyCliff.AssetsManager;
using FrostyCliff.Core;
using Silk.NET.OpenGL;
using StbImageSharp;

namespace FrostyCliff.Graphics
{
    public sealed class Texture2D : IDisposable
    {
        private static GL _gl;
        internal uint Texture;

        private Vector2D _originalTextureSize;

        internal static void InitOpenGL(GL gl) => _gl = gl;

        public Texture2D(Asset asset)
        {
            if(asset == null)
            {
                Log.Error("Can't load image from null asset");
                return;
            }
            loadImage(asset.GetStream());
        }

        internal Texture2D(MemoryStream ms)
        {
            loadImage(ms);
        }

        internal Vector2D GetOriginalTextureSize() => _originalTextureSize;

        private unsafe void loadImage(MemoryStream ms)
        {
            if (ms == null)
            {
                Log.Error("Can't load image from asset");
                return;
            }
            Texture = _gl.GenTexture();
            _gl.ActiveTexture(TextureUnit.Texture0);
            _gl.BindTexture(TextureTarget.Texture2D, Texture);
            ImageResult result = ImageResult.FromStream(ms, ColorComponents.RedGreenBlueAlpha);
            _originalTextureSize = new Vector2D(result.Width, result.Height);
            fixed (byte* ptr = result.Data)
            {
                _gl.TexImage2D(GLEnum.Texture2D, 0, (int)InternalFormat.Rgba, (uint)result.Width, (uint)result.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, ptr);
            }

            _gl.TexParameter(GLEnum.Texture2D, GLEnum.TextureWrapS, (int)TextureWrapMode.ClampToEdge);
            _gl.TexParameter(GLEnum.Texture2D, GLEnum.TextureWrapT, (int)TextureWrapMode.ClampToEdge);
            _gl.TexParameter(GLEnum.Texture2D, GLEnum.TextureMinFilter, (int)TextureMinFilter.Linear);
            _gl.TexParameter(GLEnum.Texture2D, GLEnum.TextureMagFilter, (int)TextureMinFilter.Linear);

            _gl.BindTexture(GLEnum.Texture2D, 0);
        }

        public void Dispose()
        {
            _gl.DeleteTexture(Texture);
        }

    }
}
