using FrostyCliff.Graphics;
using System;

namespace FrostyCliff.Core
{
    public class GamePawn2D : IDisposable
    {
        public Transform2D Transform;
        public RendererObject2D RendererObject;

        public GamePawn2D(Transform2D transform)
        {
            Transform = transform;
        }

        public void Dispose() { }
    }
}
