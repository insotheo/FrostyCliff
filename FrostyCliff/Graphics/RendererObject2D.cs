using Silk.NET.OpenGL;
using System;

namespace FrostyCliff.Graphics
{
    public class RendererObject2D : IDisposable
    {
        protected static GL _gl;
        protected uint _vbo, _vao, _ebo, _program;

        internal static void InitOpenGL(GL gl) => _gl = gl;

        internal unsafe virtual void Draw() { }

        public virtual void Dispose() { }

    }
}
