using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PhysicsEngine
{
    public readonly struct Vector2
    {
        //same reason here 
        public double x { get; }
        public double y { get; }
        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double Magnitude()
        {
            return System.Math.Sqrt(x * x + y * y);
        }

        public double MagnitudeSquared()
        {
            return (x * x + y * y);
        }
        public Vector2 Normalize()
        {
            double magnitute = this.Magnitude();
            if(magnitute == 0)
            {
                return new Vector2(x: 0, y : 0);
            }
            return new Vector2(x / magnitute, y / magnitute);
        }

        public static Vector2 operator +(Vector2 first, Vector2 second)
        {
            double newX = first.x + second.x;
            double newY = first.y + second.y;
            return new Vector2(newX, newY);
        }

        public static Vector2 operator - (Vector2 first, Vector2 second)
        {
            double newX = first.x - second.x;
            double newY = first.y - second.y;
            return new Vector2(newX, newY);
        }
        public static Vector2 operator *(Vector2 vectorToMultiply,double scalar)
        {
            double newX = (vectorToMultiply.x * scalar);
            double newY = (vectorToMultiply.y * scalar);
            return new Vector2(newX, newY);
        }
        public static Vector2 operator /(Vector2 vectorToDivide, double scalar)
        {
            double newX = vectorToDivide.x / scalar;
            double newY = vectorToDivide.y / scalar;
            return new Vector2(newX, newY);
        }
        public static double Dot(Vector2 first, Vector2 second)
        {
            return (first.x * second.x) + (first.y * second.y);
        }
        public static double Distance(Vector2 first, Vector2 second)
        {
            Vector2 distance = second - first;
            return distance.Magnitude();

        }
    }

}
