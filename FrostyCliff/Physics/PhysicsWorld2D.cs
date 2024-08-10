using System.Collections.Generic;

namespace FrostyCliff.Physics
{
    public class PhysicsWorld2D
    {
        private List<PhysicsObject2D> _physicsObjects;
        private bool _isSimulating = true;

        public PhysicsWorld2D()
        {
            _physicsObjects = new List<PhysicsObject2D>();
        }

        internal void Update(double dt)
        {

        }

        public void AddPhysicsObject(PhysicsObject2D physicsObject) => _physicsObjects.Add(physicsObject);
        public void RemovePhysicsObject(PhysicsObject2D physicsObject) => _physicsObjects.Remove(physicsObject);
        public void RemoveAllPhysicsObjects() => _physicsObjects.Clear();
        public void SetIsSimulating(bool value) => _isSimulating = value;
        public bool GetIsSimulating() => _isSimulating;
    }
}
