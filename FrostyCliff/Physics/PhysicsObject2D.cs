using FrostyCliff.Core;
using FrostyCliff.Graphics;

namespace FrostyCliff.Physics
{
    public class PhysicsObject2D
    {
        internal Transform2D Transform;
        internal PhysicsBodyType BodyType;
        internal Vector2D Velocity;
        internal float Mass;

        private Direction2D _bannedDirection;

        internal PhysicsObject2D(Transform2D initTransform, PhysicsBodyType bodyType, float mass)
        {
            Transform = initTransform;
            BodyType = bodyType;
            Mass = mass;
            if(bodyType == PhysicsBodyType.Kinematic)
            {
                Velocity = new Vector2D(0, 0);
            }
        }

        internal void Update(double dt)
        {
            if(BodyType == PhysicsBodyType.Kinematic)
            {
                Velocity.Y -= Mass * Core.Math.G * (float)dt;
                ClipMovementDirection();
                Transform.Position += Velocity;
            }
        }      

        internal void HandleCollision(Direction2D direction, ref PhysicsObject2D collidedObject)
        {
            if (BodyType == PhysicsBodyType.Kinematic)
            {
                if(direction == Direction2D.Down || direction == Direction2D.Up)
                {
                    Velocity.Y *= -0.5f;
                }
                if(direction == Direction2D.Left || direction == Direction2D.Right)
                {
                    Velocity.X *= -0.5f;
                }
                _bannedDirection = direction;
            }
        }

        private void ClipMovementDirection()
        {
            if(Velocity.Y < 0 && _bannedDirection == Direction2D.Down || 
                Velocity.Y > 0 && _bannedDirection == Direction2D.Up)
            {
                Velocity.Y = 0;
            }
            if(Velocity.X > 0 && _bannedDirection == Direction2D.Right ||
                Velocity.X < 0 && _bannedDirection == Direction2D.Left)
            {
                Velocity.X = 0;
            }
            _bannedDirection = Direction2D.None;
        }

    }
}
