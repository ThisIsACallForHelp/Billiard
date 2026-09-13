using PhysicsEngine.Collision;
using PhysicsEngine.Integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsEngine.Dynamics
{
    public class PhysicsWorld
    {
        public List<RigidBody> bodies {  get; set; }
        public List<LineCollider> cushions {  get; set; }

        public PhysicsWorld(List<RigidBody> rigidBodies, List<LineCollider> lineColliders) 
        {
            bodies  = rigidBodies;
            cushions = lineColliders;
        }   
        public void AddBody(RigidBody body)
        {
            bodies.Add(body);
        }
        public void AddCushion(LineCollider cushion)
        {
            cushions.Add(cushion);
        }

        public void Step(double dt)
        {
            // Dummy static body for cushions to prevent null reference in resolver
            RigidBody cushionDummy = new RigidBody(new Vector2(0,0), new Vector2(0,0), 1, 1, new PhysicsMaterial(Constants.railBounciness, Constants.frictionCoefficient), true);

            foreach (RigidBody body in bodies)
            {
                PhysicsIntegrator.Integrate(body, dt);
                foreach (LineCollider cushion in cushions)
                {
                    CollisionManifold collisionCheck = CollisionDetector.CircleAgainstLine(circleBody: body, lineBody: cushionDummy, line: cushion);
                    if (collisionCheck.isColliding)
                    {
                        CollisionResolver.Resolve(collisionCheck);
                    }
                }
            }
            for (int i = 0; i < bodies.Count; i++)
            {
                for(int j =i + 1; j < bodies.Count; j++)
                {

                    CollisionManifold collisionChecker = CollisionDetector.CircleAgainstCirlce(bodies[i], bodies[j]);
                    if (collisionChecker.isColliding)
                    {
                        CollisionResolver.Resolve(collisionChecker);
                    }
                }
            }
        }
    }
}
