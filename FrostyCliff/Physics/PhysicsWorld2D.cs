using FrostyCliff.Core;
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
            if (_isSimulating)
            {
                foreach (PhysicsObject2D physicsObject in _physicsObjects)
                {
                    physicsObject.Update(dt);
                }
                CheckCollisions();
            }
        }

        public void AddPhysicsObject(GamePawn2D physicsObject) => _physicsObjects.Add(physicsObject.PhysicsObject);
        public void RemovePhysicsObject(GamePawn2D physicsObject) => _physicsObjects.Remove(physicsObject.PhysicsObject);
        public void RemoveAllPhysicsObjects() => _physicsObjects.Clear();
        public void SetIsSimulating(bool value) => _isSimulating = value;
        public bool GetIsSimulating() => _isSimulating;


        private void CheckCollisions()
        {
            for (int i = 0; i < _physicsObjects.Count; i++)
            {
                for (int j = i + 1; j < _physicsObjects.Count; j++)
                {
                    PhysicsObject2D p1 = _physicsObjects[i];
                    PhysicsObject2D p2 = _physicsObjects[j];

                    Direction2D dir = Collision2D.CheckCollision(p1, p2);
                    if (dir != Direction2D.None)
                    {
                        p1.HandleCollision(dir, ref p2);
                        p2.HandleCollision(dir, ref p1);
                    }
                }
            }
        }

    }
}
