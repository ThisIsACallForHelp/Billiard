using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine
{
    public static class Constants
    {
        public const double ballMass = 1;
        public const double ballRadius = 14;
        public const double timeStep = 1.0/120.0;
        public const double cornerPocketRadius = 26;
        public const double railBounciness = 0.75;
        public const double minVelocity = 0.5;
        public const int tableHeight = 600;
        public const int tableWidth = 1200;
        public const double cushionThickness = 20;
        public const double frictionCoefficient = 0.02;
        public const double ballBounciness = 0.95;
        public const double maxCueForce = 2000.0;
    }
}
