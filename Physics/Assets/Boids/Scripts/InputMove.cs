using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Particles.Physic
{
    public class InputMove : MonoBehaviour, IMoveAble {
        public Vector3 Move(ref Particle particle, float dt)
        {
            if (Input.GetKey(KeyCode.A))
            {
                particle.Position += new Vector3 (-.25f, 0, 0);
                //particle.Velocity.x = (particle.Force.x / particle.mass);
                //particle.Position.x = -(particle.Position.x + particle.Velocity.x * dt);
            }
            if (Input.GetKey(KeyCode.S))
            {
                particle.Position += new Vector3(0, -.25f, 0);
                //particle.Velocity.y = (particle.Force.y / particle.mass);
                //particle.Position.y = -(particle.Position.y + particle.Velocity.y * dt);
            }
            if (Input.GetKey(KeyCode.D))
            {
                particle.Position += new Vector3(.25f, 0, 0);
                //particle.Velocity.x = (particle.Force.x / particle.mass);
                //particle.Position.x = (particle.Position.x + particle.Velocity.x * dt);
            }
            if (Input.GetKey(KeyCode.W))
            {
                particle.Position += new Vector3(0, .25f, 0);
                //particle.Velocity.y = (particle.Force.y / particle.mass);
                //particle.Position.y = (particle.Position.y + particle.Velocity.y * dt);
                
            }
            return particle.Position;
        }

    }
}


