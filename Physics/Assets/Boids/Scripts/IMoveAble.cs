using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Particles.Physic
{
    public interface IMoveAble
    {
        Vector3 Move(ref Particle particle, float dt);

    }
}