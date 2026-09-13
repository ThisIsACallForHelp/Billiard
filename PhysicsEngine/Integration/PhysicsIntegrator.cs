using PhysicsEngine.Dynamics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine.Integration
{
    public static class PhysicsIntegrator
    {
        public static void Integrate(RigidBody body, double dt)
        {
            if (body.isStatic)
            {
                return;
            }
            body.velocity *= (1.0 - body.material.friction);
            if(body.velocity.Magnitude() < Constants.minVelocity)
            {
                body.velocity = new Vector2(x: 0, y: 0);
            }
            body.position += (body.velocity * dt);
        }
    }
}
