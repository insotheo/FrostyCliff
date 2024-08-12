using FrostyCliff.Core;
using FrostyCliff.Graphics;

namespace FrostyCliff.Physics
{
    public class PhysicsObject2D
    {
        internal Transform2D Transform;
        internal PhysicsBodyType BodyType;

        internal PhysicsObject2D(Transform2D initTransform, PhysicsBodyType bodyType)
        {
            Transform = initTransform;
            BodyType = bodyType;
        }

        internal void Update(double dt)
        {
            if(BodyType == PhysicsBodyType.Kinematic)
            {
                Vector2D velocity = new Vector2D(0, -1);
                Transform.Position += velocity * (float)dt * 9.10f;
            }
        }      

    }
}
