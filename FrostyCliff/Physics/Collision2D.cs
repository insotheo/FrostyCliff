using FrostyCliff.Core;
using FrostyCliff.Graphics;

namespace FrostyCliff.Physics
{
    internal static class Collision2D
    {
        internal static Direction2D CheckCollision(PhysicsObject2D p1, PhysicsObject2D p2)
        {
            Vector2D[] verticesOfp1 = GetVertices(p1);
            Vector2D[] verticesOfp2 = GetVertices(p2);

            if (!CheckPolygonCollision(verticesOfp1, verticesOfp2))
                return Direction2D.None;

            return GetCollisionDirection(p1, p2);
        }

        private static Direction2D GetCollisionDirection(PhysicsObject2D p1, PhysicsObject2D p2)
        {
            Vector2D centerP1 = p1.Transform.Position;
            Vector2D centerP2 = p2.Transform.Position;

            Vector2D direction = centerP2 - centerP1;

            if (System.Math.Abs(direction.X) > System.Math.Abs(direction.Y))
            {
                if (direction.X > 0)
                {
                    return Direction2D.Right;
                }
                else
                {
                    return Direction2D.Left;
                }
            }
            else
            {
                if (direction.Y > 0)
                {
                    return Direction2D.Down;
                }
                else
                {
                    return Direction2D.Right;
                }
            }
        }

        private static Vector2D[] GetVertices(PhysicsObject2D po)
        {
            Transform2D transform = po.Transform;
            Vector2D[] localVertices = new Vector2D[]
            {
                new Vector2D(-0.5f * transform.Scale.X, -0.5f * transform.Scale.Y),
                new Vector2D(0.5f * transform.Scale.X, -0.5f * transform.Scale.Y),
                new Vector2D(0.5f * transform.Scale.X, 0.5f * transform.Scale.Y),
                new Vector2D(-0.5f * transform.Scale.X, 0.5f * transform.Scale.Y)
            };

            Vector2D[] vertices = new Vector2D[localVertices.Length];
            for (int i = 0; i < localVertices.Length; i++)
            {
                vertices[i] = RotatePoint(localVertices[i], Vector2D.ZeroVector2D(), transform.Rotation) + transform.Position;
            }

            return vertices;
        }

        private static Vector2D RotatePoint(Vector2D point, Vector2D pivot, float angle)
        {
            float cosTheta = (float)System.Math.Cos(angle);
            float sinTheta = (float)System.Math.Sin(angle);
            Vector2D translatedPoint = point - pivot;

            float xNew = translatedPoint.X * cosTheta - translatedPoint.Y * sinTheta;
            float yNew = translatedPoint.X * sinTheta + translatedPoint.Y * cosTheta;

            return new Vector2D(xNew, yNew) + pivot;
        }

        private static bool CheckPolygonCollision(Vector2D[] verticesOfp1, Vector2D[] verticesOfp2)
        {
            for (int i = 0; i < verticesOfp1.Length; i++)
            {
                Vector2D edge = verticesOfp1[(i + 1) % verticesOfp1.Length] - verticesOfp1[i];
                Vector2D normal = new Vector2D(-edge.Y, edge.X);

                if (!OverlapOnAxis(normal, verticesOfp1, verticesOfp2))
                    return false;
            }

            for (int i = 0; i < verticesOfp2.Length; i++)
            {
                Vector2D edge = verticesOfp2[(i + 1) % verticesOfp2.Length] - verticesOfp2[i];
                Vector2D normal = new Vector2D(-edge.Y, edge.X);

                if (!OverlapOnAxis(normal, verticesOfp1, verticesOfp2))
                    return false;
            }

            return true;
        }

        private static bool OverlapOnAxis(Vector2D axis, Vector2D[] verticesOfp1, Vector2D[] verticesOfp2)
        {
            float min1, max1, min2, max2;

            Project(verticesOfp1, axis, out min1, out max1);
            Project(verticesOfp2, axis, out min2, out max2);

            return min1 <= max2 && max1 >= min2;
        }

        private static void Project(Vector2D[] vertices, Vector2D axis, out float min, out float max)
        {
            float projection;
            min = float.MaxValue;
            max = float.MinValue;

            foreach (var vertex in vertices)
            {
                projection = (vertex.X * axis.X + vertex.Y * axis.Y);
                if (projection < min) min = projection;
                if (projection > max) max = projection;
            }
        }
    }
}
