using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine.Dynamics
{
    public readonly struct PhysicsMaterial
    {
        public double restitution { get; }
        public double friction { get; }

        public PhysicsMaterial(double res, double fric)
        {
            restitution = res;
            friction = fric;
        }
    }
}
