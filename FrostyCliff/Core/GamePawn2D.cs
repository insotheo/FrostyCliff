using FrostyCliff.Graphics;
using FrostyCliff.Physics;
using System;

namespace FrostyCliff.Core
{
    public class GamePawn2D : IDisposable
    {
        public Transform2D Transform;
        public RendererObject2D RendererObject;
        public PhysicsObject2D PhysicsObject { get; internal set; }

        public GamePawn2D(Transform2D transform)
        {
            Transform = transform;
        }

        internal void OnPawnBegin() => OnBegin();
        internal void OnPawnUpdate(double dt) => OnUpdate(dt);

        public void Dispose() { }

        public void CreatePhysicsObject(PhysicsBodyType bodyType)
        {
            PhysicsObject = new PhysicsObject2D(Transform, bodyType);
        }

        protected virtual void OnBegin() { }
        protected virtual void OnUpdate(double deltaTime) { }
    }
}
