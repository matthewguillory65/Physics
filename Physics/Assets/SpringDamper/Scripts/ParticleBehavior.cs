using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ParticleBehavior : MonoBehaviour
{
    public SpringDamper spring;
    public int Width;
    public int Height;
    public List<Particle> particle;
    public List<SpringDamper> Sd;

	// Use this for initialization
	void Start ()
    {

        for(int width = 0; width < 5 + Width; width++)
        {
            for(int height = 0; height < 5 + Height; height++)
            {
                particle.Add(new Particle(new Vector3()));
            }
        }

        for(int i = 0; i < particle.Count; i++)
        {
            Sd.Add(new SpringDamper(particle[i], particle[i + 1]));
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        foreach(var s in Sd)
        {
            spring.Update();
        }
	}
}
