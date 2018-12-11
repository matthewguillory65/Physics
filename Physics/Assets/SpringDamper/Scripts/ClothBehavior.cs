using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ClothBehavior : MonoBehaviour
{
    public SpringDamper SD;
    Particle p1, p2;
    Particle particle;
    public List<Particle> particleList = new List<Particle>();
    public List<SpringDamper> springdamper = new List<SpringDamper>();
    int height = 7;
    int width = 7;
    
	// Use this for initialization
	void Start ()
    {
        p1 = new Particle(new Vector3(0, 0, 0));
        p2 = new Particle(new Vector3(0, 1, 0));
        SD = new SpringDamper(p1, p2);


        //for (int width = 0; width < 5; width++)
        //{
        //    for (int height = 0; height < 5; height++)
        //    {
        //        particleList.Add(new Particle(new Vector3(width, height, 0)));
        //    }
        //}

        for (int y = 0; y < height; y++)
        {
            for (float x = 0; x < width; x++)
            {
                particleList.Add(new Particle(new Vector3(x, y, 0)));
            }
        }

        for (int u = 0; u < particleList.Count; u++)
        {
            if(particleList[u].r.y == height - 1)
            {
                particleList[u].anchor = true;
            }
        }

        for (int i = 0; i < particleList.Count; i++)
        {
            if (particleList[i].r.x < width - 1)
            {
                springdamper.Add(new SpringDamper(particleList[i], particleList[i + 1]));
            }
            if (particleList[i].r.y < height - 1)
            {
                springdamper.Add(new SpringDamper(particleList[i], particleList[i + width]));
            }
            if(particleList[i].r.x < width - 1 && particleList[i].r.y < height - 1)
            {
                springdamper.Add(new SpringDamper(particleList[i], particleList[i + 1 + height]));
            }
            if(particleList[i].r.x > 0 && particleList[i].r.y != height - 1)
            {
                springdamper.Add(new SpringDamper(particleList[i], particleList[i - 1 + width]));
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        foreach (var s in springdamper)
        {
            s.Update();
        }
        foreach (var p in particleList)
        {
            if(!p.anchor)
            {
                p.AddForce(new Vector3(0, -9.81f, 0));
                p.Update();
            }
        }
    }

    void OnDrawGizmos()
    {
        foreach(var s in springdamper)
        {
            Gizmos.DrawLine(s.pOne.r, s.pTwo.r);
        }
        foreach(var p in particleList)
        {
            Gizmos.DrawSphere(p.r, .12f);
        }
    }
}
