using FrostyCliff.Graphics;
using Silk.NET.Windowing;
using System.Numerics;

namespace FrostyCliff.Core
{
    public sealed class Camera2D
    {

        public Vector2D Position;
        public float Zoom;

        public Camera2D(Vector2D position, float zoom)
        {
            Position = position;
            Zoom = zoom;
        }

        public Camera2D()
        {
            Position = Vector2D.ZeroVector2D();
            Zoom = 1;
        }

        internal Matrix4x4 GetCameraMatrix(ref IWindow _window)
        {
            var orthographic = Matrix4x4.CreateOrthographicOffCenter(
                Position.X - (float)_window.Size.X / 2f,
                Position.X + (float)_window.Size.X / 2f,
                Position.Y - (float)_window.Size.Y / 2f,
                Position.X + (float)_window.Size.Y / 2f,
                0.01f, 100f
                );
            var zoomMatrix = Matrix4x4.CreateScale(Zoom);
            return orthographic * zoomMatrix;
        }

    }
}
