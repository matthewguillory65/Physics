using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boids : MonoBehaviour
{
    public Slider Rule1;
    public Slider Rule2;
    public Slider Rule3;
    public List<BoidParticles> b = new List<BoidParticles>();
    public List<GameObject> sphere;
    public GameObject prefab;
    public float mg = 0;
    public float lt = 0;
    public float align = 0;

    private void Start()
    {
        foreach(var boid in b)
        {
            boid.Position = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
        }
        draw_boids();
        //Rule1.wholeNumbers = true;
    }

    private void Update()
    {
        mg = Rule1.value;
        lt = Rule2.value;
        align = Rule3.value;
        move_all_boids_to_new_position();
        for(int i = 0; i < sphere.Count; i++)
        {
            sphere[i].transform.position = b[i].Position;
        }
    }

    public void draw_boids()
    {
        foreach(var boid in b)
        {
            var pre = GameObject.Instantiate(prefab);
            sphere.Add(pre);
        }
    }

    public void move_all_boids_to_new_position()
    {
        Vector3 v1, v2, v3, v4;
        int iter = 0;
        foreach (var boids in b)
        {
            v1 = rule1(boids);
            v2 = rule2(boids);
            v3 = rule3(boids);
            v4 = bound_position(boids);
            boids.Velocity = boids.Velocity + v1 + v2 + v3 + v4;
            if (boids.Velocity.magnitude > 3)
                boids.Velocity = boids.Velocity.normalized;
            boids.Position = boids.Position + boids.Velocity;
            iter += 1;
        }
        
    }

    public Vector3 rule1(BoidParticles bj)
    {
        //Rule 1: Boids try to fly towards the centre of mass of neighboring boids.
        //The 'centre mass' is simplky the average position of all the boids.
        //Assume we have n boids.
        Vector3 pc = Vector3.zero;
        
        foreach(var boids in b)
        {
            if(boids != bj)
            {
                pc = pc + boids.Position;
            }
        }
        pc = pc / (b.Count - 1);

        return (pc - bj.Position) / mg;
    }

    public Vector3 rule2(BoidParticles bj)
    {
        //Rule 2: Boids try to keep a small distance away from other objects (including other boids).
        //The purpose of this rule is for boids to make sure they don't collide into each other.
        Vector3 c = Vector3.zero;

        foreach(var boids in b)
        {
            if(boids != bj)
            {
                if((boids.Position - bj.Position).magnitude < lt)
                {
                    c = c - (boids.Position - bj.Position);
                }
            }
        }
        return c;
    }

    public Vector3 rule3(BoidParticles bj)
    {
        //Rule 3: Boids try to match velocity with near boids.
        //This is similar to Rule 1, however instead of averaging the positions of the other boids we average the velocity.
        Vector3 pv = Vector3.zero;

        foreach(var boids in b)
        {
            if(boids != bj)
            {
                pv = pv + boids.Velocity;
            }
        }
        pv = pv / (b.Count - 1);

        return (pv - bj.Velocity) / align;
    }

    public Vector3 bound_position(BoidParticles b)
    {
        int Xmin = -50, Xmax = 50, Ymin = -20, Ymax = 20, Zmin = -20, Zmax = 20;
        Vector3 v = new Vector3();
        
        if (b.Position.x < Xmin)
            v.x = 10;
        else if (b.Position.x > Xmax)
            v.x = -10;

        if (b.Position.y < Ymin)
            v.y = 10;
        else if (b.Position.y > Ymax)
            v.y = -10;

        if (b.Position.z < Zmin)
            v.z = 10;
        else if (b.Position.z > Zmax)
            v.z = -10;

        return v;
    }
}
