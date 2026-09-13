using PhysicsEngine.Dynamics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine.Collision
{
    public static class CollisionDetector
    {
        public static CollisionManifold CircleAgainstCirlce(RigidBody first, RigidBody second)
        {
            double distance = Vector2.Distance(first.position, second.position);
            double sumOfRadii = first.radius + second.radius;
            //check for collision
            if(distance < sumOfRadii && distance > 0)
            {
                Vector2 normal = (second.position - first.position).Normalize();
                double depth = sumOfRadii - distance;
                bool isColliding = true;
                return new CollisionManifold(first, second, normal, depth, isColliding);
            }
            return new CollisionManifold(first: null, second: null, normal: new Vector2(0,0),depth: 0.0, Colliding: false);
        }

        public static CollisionManifold CircleAgainstLine(RigidBody circleBody, RigidBody lineBody, LineCollider line)
        {
            Vector2 lineToCircle = circleBody.position - line.startVector;
            Vector2 lineDirection = line.endVector - line.startVector; // Fixed: end - start
            double lineLengthSquared = lineDirection.MagnitudeSquared();
            
            double t = 0;
            if (lineLengthSquared != 0)
            {
                t = Vector2.Dot(lineToCircle, lineDirection) / lineLengthSquared;
                t = System.Math.Max(0, System.Math.Min(1, t)); // Clamp t between 0 and 1
            }

            Vector2 closestPoint = line.startVector + (lineDirection * t);
            double distance = Vector2.Distance(closestPoint, circleBody.position); // Fixed: actual distance
            
            if(distance < circleBody.radius)
            {
                Vector2 normal = (circleBody.position - closestPoint).Normalize();
                double depth = circleBody.radius - distance;
                return new CollisionManifold(circleBody, lineBody, normal, depth, Colliding: true);
            }
            return new CollisionManifold(first: null, second: null, normal: new Vector2(0, 0), depth: 0.0, Colliding: false);
        }
    }
}
