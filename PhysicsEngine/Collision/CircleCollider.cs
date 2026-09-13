using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace PhysicsEngine.Collision
{
    public class CircleCollider : Collider
    {
        public CircleCollider()
        {
            collisionType = ColliderType.Circle;
        }
        

    }
}
