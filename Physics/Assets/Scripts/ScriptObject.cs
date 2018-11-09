using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Particles.Physic
{
    [CreateAssetMenu]
    public class ScriptObject : ScriptableObject
    {
        public enum IMove
        {
            Linear,
            Movement
        }

        public IMove MovementType;
    }
}

