using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine.Collision
{
    public static class CollisionResolver
    {
        public static void Resolve(CollisionManifold manifold)
        {
            if (!manifold.isColliding)
            {
                return;
            }
            Vector2 c = manifold.normal * (manifold.depth / (manifold.firstBody.inverseMass + manifold.secondBody.inverseMass)); ;
            manifold.firstBody.position =  manifold.firstBody.position - c * manifold.firstBody.inverseMass;
            manifold.secondBody.position = manifold.secondBody.position + c * manifold.secondBody.inverseMass;
            Vector2 relativeVelocity = manifold.secondBody.velocity - manifold.firstBody.velocity;
            double normalVelocity = Vector2.Dot(relativeVelocity, manifold.normal);
            if(normalVelocity > 0)
            {
                return;
            }
            double restitution = System.Math.Min(manifold.firstBody.material.restitution, manifold.secondBody.material.restitution);
            double impulseScalar = (-(1 + restitution) * normalVelocity) / (manifold.firstBody.inverseMass + manifold.secondBody.inverseMass);
            Vector2 velocityA = manifold.firstBody.velocity - (manifold.normal * impulseScalar * manifold.firstBody.inverseMass);
            Vector2 velocityB = manifold.secondBody.velocity + (manifold.normal * impulseScalar * manifold.secondBody.inverseMass);
            manifold.firstBody.velocity = velocityA;
            manifold.secondBody.velocity = velocityB;
        }
    }
}
