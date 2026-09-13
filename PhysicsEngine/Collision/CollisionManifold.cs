using PhysicsEngine.Dynamics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine.Collision
{
    public readonly struct CollisionManifold
    {
        public readonly RigidBody firstBody;
        public readonly RigidBody secondBody;
        public readonly Vector2 normal;
        public readonly double depth;
        public readonly bool isColliding;

        public CollisionManifold(RigidBody first, RigidBody second, Vector2 normal,
                                 double depth, bool Colliding)
        {
            firstBody = first;
            secondBody = second;
            this.normal = normal;
            this.depth = depth;
            this.isColliding = Colliding;
        }
    }
}
