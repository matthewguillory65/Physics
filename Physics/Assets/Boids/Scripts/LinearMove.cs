using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Particles.Physic
{
    public class LinearMove : IMoveAble
    {
        public Vector3 Move(ref Particle particle, float dt)
        {
            //particle.Acceleration = particle.Force / particle.mass;
            //particle.Position = particle.Velocity * dt;
            //particle.Velocity = particle.Acceleration * dt;

            particle.Acceleration = (particle.Force / particle.mass);
            particle.Velocity = (particle.Force / particle.mass);
            
            particle.Position = particle.Position + particle.Velocity * dt;
            
            return particle.Position;
        }
    }
}

