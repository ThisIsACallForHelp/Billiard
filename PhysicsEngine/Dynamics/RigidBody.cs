using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine.Dynamics
{
    public class RigidBody
    {
        public Vector2 position { get; set; }
        public Vector2 velocity { get; set; }
        public double mass { get; set; }
        public double inverseMass { get; set; }
        public double radius { get; set; }
        public PhysicsMaterial material { get; set; }
        public bool isStatic { get; set; }

        public RigidBody(Vector2 position, Vector2 velocity, double mass, double radius, PhysicsMaterial material, bool isStatic)
        {
            this.position = position;
            this.velocity = velocity;
            this.mass = mass;
            this.radius = radius;
            this.material = material;
            this.isStatic = isStatic;
            this.inverseMass = isStatic ? 0 : 1.0/mass;
        }

        public void ApplyImpulse(Vector2 impulseVector)
        {
            if (!isStatic)
            {
                velocity += impulseVector * inverseMass;
            }
        }

        public void ApplyForce(Vector2 force)
        {
            velocity += force;
        }
    }
}
