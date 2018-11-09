using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
namespace Particles.Physic
{
    [Serializable]
    public class Particle
    {
        public ScriptObject scriptObject;
        public IMoveAble Moveable;
        public Vector3 Position { get; set; }
        public Vector3 Displacement { get; set; }
        public Vector3 Velocity { get; set; }
        public Vector3 Acceleration { get; set; }

        public float mass;
        public Vector3 Force;

        //acceleration = Force/Mass
    }
}



