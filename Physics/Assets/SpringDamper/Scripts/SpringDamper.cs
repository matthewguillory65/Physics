using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringDamper
{
    Particle pOne; //Particle One
    Particle pTwo; //Particle Two
    float Ks; //Spring Constant
    float Kd; //Damping Factor
    float Lo; //Rest Length
    float L; //Length
    //Properties of a spring damper

    public SpringDamper(Particle p1, Particle p2)
    {
        Ks = 50;
        Kd = 2;
        Lo = Vector3.Distance(p1.r, p2.r);
        pOne = p1;
        pTwo = p2;
    }
    

    void Update()
    {
        //Moving the Particle
        var ePrime = pTwo.r - pOne.r;
        var eMag = ePrime.magnitude;
        var e = ePrime / eMag;
        e.Normalize();

        var v1 = Vector3.Dot(e, pOne.v);
        var v2 = Vector3.Dot(e, pTwo.v);

        var Fsd = -Ks * (Lo - L) - Kd * (v1 - v2);
        var F1 = Fsd * e;
        var F2 = -F1;
    }
}


public class Particle
{
    public readonly Vector3 r; //Position
    Vector3 rNew; //New Position
    public Vector3 v; //Velocity
    Vector3 vNew; //New Velocity
    Vector3 a; //Acceleration
    float m = 1f; //Mass
    Vector3 f; //Force
	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Acceleration
        a = f * m;
        //New Velocity
        vNew = v + (a * Time.deltaTime);
        //New Position
        rNew = r + (v * Time.deltaTime);
    }
}
