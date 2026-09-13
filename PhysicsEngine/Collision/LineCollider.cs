using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine.Collision
{
    public class LineCollider : Collider
    {
        
        public Vector2 startVector;
        public Vector2 endVector;
        public Vector2 normal;

        public LineCollider(Vector2 startVector, Vector2 endVector)
        {
            this.collisionType = ColliderType.Line;
            this.startVector = startVector;
            this.endVector = endVector;
            this.normal = CalcNormal();
        }
        public Vector2 CalcNormal()
        {
            Vector2 direction = endVector - startVector;
            normal = new Vector2(direction.y, -direction.x);
            return normal.Normalize();
        }
    }
}
