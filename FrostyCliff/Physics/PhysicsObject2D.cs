using FrostyCliff.Core;
using FrostyCliff.Graphics;

namespace FrostyCliff.Physics
{
    public class PhysicsObject2D
    {
        internal Transform2D Transform;
        internal PhysicsBodyType BodyType;
        internal Vector2D Velocity;

        internal PhysicsObject2D(Transform2D initTransform, PhysicsBodyType bodyType)
        {
            Transform = initTransform;
            BodyType = bodyType;
            if(bodyType == PhysicsBodyType.Kinematic)
            {
                Velocity = new Vector2D(0, 0);
            }
        }

        internal void Update(double dt)
        {
            if(BodyType == PhysicsBodyType.Kinematic)
            {
                Velocity.Y -= (float)dt * 2f;
                Transform.Position += Velocity;
            }
        }      

        internal void HandleCollision(Direction2D direction, ref PhysicsObject2D collidedObject)
        {

        }

    }
}
