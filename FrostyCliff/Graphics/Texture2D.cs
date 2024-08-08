using System;
using System.IO;
using FrostyCliff.Core;
using Silk.NET.OpenGL;
using StbImageSharp;

namespace FrostyCliff.Graphics
{
    public sealed class Texture2D : IDisposable
    {
        private static GL _gl;
        internal uint Texture;

        internal static void InitOpenGL(GL gl) => _gl = gl;

        public Texture2D(string pathToImage)
        {
            loadImage(pathToImage);
        }

        private unsafe void loadImage(string path)
        {
            if (!File.Exists(path))
            {
                Log.Error($"File {Path.GetFileName(path)} not found!");
                return;
            }
            Texture = _gl.GenTexture();
            _gl.ActiveTexture(TextureUnit.Texture0);
            _gl.BindTexture(TextureTarget.Texture2D, Texture);
            ImageResult result = ImageResult.FromMemory(File.ReadAllBytes(path), ColorComponents.RedGreenBlueAlpha);
            fixed(byte* ptr = result.Data)
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
