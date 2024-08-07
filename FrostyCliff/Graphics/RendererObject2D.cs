using System.Numerics;
using Silk.NET.OpenGL;
using FrostyCliff.Core;
using System;

namespace FrostyCliff.Graphics
{
    public class RendererObject2D : IDisposable
    {
        protected static GL _gl;
        protected uint _vbo, _vao, _ebo, _program;

        internal static void InitOpenGL(GL gl) => _gl = gl;

        internal unsafe virtual void Draw(ref Transform2D transform) { }

        protected static Matrix4x4 CalculateModel(ref Transform2D transform)
        {
            Matrix4x4 model = Matrix4x4.Identity;

            //Translate
            model = Matrix4x4.CreateTranslation(new Vector3(transform.Position.X,
                transform.Position.Y, 0.0f)) * model;

            //Rotation
            model = Matrix4x4.CreateRotationZ(transform.Rotation) * model;

            //Scale
            model = Matrix4x4.CreateScale(new Vector3(transform.Scale.X,
                transform.Scale.Y, 1.0f)) * model;

            return model;
        } 

        public virtual void Dispose() { }

    }
}
