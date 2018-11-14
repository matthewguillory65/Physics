using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Particles.Physic
{
    public class ParticleBehavior : MonoBehaviour
    {
        public ScriptObject scriptObject;
        [SerializeField] Particle particle;

        public void Start()
        {
            if (scriptObject.MovementType == ScriptObject.IMove.Linear)
            {
                particle.Moveable = new LinearMove();
            }
            if (scriptObject.MovementType == ScriptObject.IMove.Movement)
            {
                particle.Moveable = new InputMove();
            }
        }

        public void Update()
        {
            transform.position = particle.Moveable.Move(ref particle, Time.deltaTime);
        }
    }
}