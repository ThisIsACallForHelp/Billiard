using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine.Math
{
    public readonly struct Matrix2
    {
        //switched to a struct for better performance
        //vectors will be created constantly, so why make it an object?
        public double M11 { get;  }
        public double M12 { get; }
        public double M21 { get; }
        public double M22 {  get; }

        public Matrix2()
        {

        }
    }
}
