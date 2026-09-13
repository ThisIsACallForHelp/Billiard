using PhysicsEngine.Dynamics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine
{
    public enum ColliderType { Circle, Line }
    public abstract class Collider
    {
        public RigidBody collidingBody { get; set; }
        public ColliderType collisionType { get; set; }
    }
}
