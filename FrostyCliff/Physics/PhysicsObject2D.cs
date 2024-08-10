using FrostyCliff.Core;

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


    }
}
