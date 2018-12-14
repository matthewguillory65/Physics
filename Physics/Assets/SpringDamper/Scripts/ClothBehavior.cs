using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
public class ClothBehavior : MonoBehaviour
{
    public SpringDamper SD;
    public AerodynamicForce AF;
    public Slider SpringConstant, SpringDamper, Windx, Windy, Windz;
    Particle p1, p2;
    Particle particle;
    public List<Particle> particleList = new List<Particle>();
    public List<SpringDamper> springdamper = new List<SpringDamper>();
    public List<AerodynamicForce> forces = new List<AerodynamicForce>();
    public List<LineRenderer> line = new List<LineRenderer>();
    public LineRenderer Line;
    int height = 7;
    int width = 7;
    public Particle GrabbedPart;

    // Use this for initialization
    void Start()
    {
        p1 = new Particle(new Vector3(0, 0, 0));
        p2 = new Particle(new Vector3(0, 1, 0));
        SD = new SpringDamper(p1, p2);

        for (int y = 0; y < height; y++)
        {
            for (float x = 0; x < width; x++)
            {
                particleList.Add(new Particle(new Vector3(x, y, 0)));
            }
        }

        for (int u = 0; u < particleList.Count; u++)
        {
            //if (particleList[u].r.y == height - 1)
            //{
            //    particleList[u].anchor = true;
            //}

            if (particleList[u].r.y == height - 1)
            {
                particleList[height * (width - 1)].anchor = true;
                particleList[(height * width) - 1].anchor = true;
            }
        }

        for (int i = 0; i < particleList.Count; i++)
        {
            
            if (particleList[i].r.x < width - 1)
            {
                springdamper.Add(new SpringDamper(particleList[i], particleList[i + 1]));
                var l = Instantiate(Line);
                line.Add(l);
            }
            if (particleList[i].r.y < height - 1)
            {
                springdamper.Add(new SpringDamper(particleList[i], particleList[i + width]));
                var l = Instantiate(Line);
                line.Add(l);
            }
            if (particleList[i].r.x < width - 1 && particleList[i].r.y < height - 1)
            {
                springdamper.Add(new SpringDamper(particleList[i], particleList[i + 1 + height]));
                var l = Instantiate(Line);
                line.Add(l);
            }
            if (particleList[i].r.x > 0 && particleList[i].r.y != height - 1)
            {
                springdamper.Add(new SpringDamper(particleList[i], particleList[i - 1 + width]));
                var l = Instantiate(Line);
                line.Add(l);
            }
        }

        for (int i = 0; i < particleList.Count; i++)
        {
            if (particleList[i].r.x < width - 1 && particleList[i].r.y < height - 1)
            {
                forces.Add(new AerodynamicForce(particleList[i], particleList[i + 1], particleList[i + width]));
                forces.Add(new AerodynamicForce(particleList[i + 1], particleList[i + width], particleList[i + width + 1]));
            }
        }
    }

        Vector3 worldMouse;

        // Update is called once per frame
        void Update()
        {
            Vector3 mousePos = Input.mousePosition;
            worldMouse = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x,
                   mousePos.y, -Camera.main.transform.position.z));
            foreach (var s in springdamper)
            {
                s.Ks = SpringConstant.value;
                s.Kd = SpringDamper.value;
                s.Update();
                line[springdamper.IndexOf(s)].SetPosition(0, s.pOne.r);
                line[springdamper.IndexOf(s)].SetPosition(1, s.pTwo.r);
        }

            foreach (var p in particleList)
            {
                if (!p.anchor)
                {
                    p.AddForce(new Vector3(0, -9.81f, 0));
                    p.Update();
                }
            }

            foreach (var f in forces)
            {
                f.p = new Vector3(5, 0, .5f);
                f.p.x = Windx.value;
                f.p.y = Windy.value;
                f.p.z = Windz.value;
                f.Update();
            }

            if (Input.GetMouseButtonDown(0))
            {
                float x = 1f;
                foreach (var l in particleList)
                {
                    if (Vector3.Distance(worldMouse, l.r) < x)
                    {
                        GrabbedPart = l;
                    }
                }
            }

            if (GrabbedPart != null && Input.GetMouseButton(0))
            {
                GrabbedPart.r = worldMouse;
            }

            //for every spring, find line renderer obj at same index
            //set position1 to particle1
            //set position2 to particle2

            //foreach(var sd in springdamper)
            //{
            //line[springdamper.IndexOf(sd)].SetPosition(0, sd.pOne.r);
            //line[springdamper.IndexOf(sd)].SetPosition(1, sd.pTwo.r);
            //}
        }


        //void OnDrawGizmos()
        //{
        //    foreach (var s in springdamper)
        //    {
        //        Gizmos.DrawLine(s.pOne.r, s.pTwo.r);
        //    }
        //    foreach (var p in particleList)
        //    {
        //        Gizmos.DrawSphere(p.r, .12f);
        //    }
        //    foreach (var a in forces)
        //    {
        //        Gizmos.DrawLine(a.r1.r, a.r2.r);
        //        Gizmos.DrawLine(a.r2.r, a.r3.r);
        //        Gizmos.DrawLine(a.r3.r, a.r1.r);
        //    }
        //}

    //void DrawLine(Vector3 start, Vector3 end, Color color)
    //{
    //    foreach (var l in line)
    //    {
    //        foreach(var sd in springdamper)
    //        {
    //            myLine.transform.position = start;
    //            myLine.AddComponent<LineRenderer>();
    //            LineRenderer lr = myLine.GetComponent<LineRenderer>();
    //            GameObject.Instantiate(myLine);
    //            line.Add(myLine);
    //            l.SetWidth(.3f, .3f);
    //            l.SetPosition(0, sd.pOne.r);
    //            l.SetPosition(1, sd.pTwo.r);
    //        }
            
    //    }

    //}
}