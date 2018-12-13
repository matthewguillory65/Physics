using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SpringDamper
{
    public Particle pOne; //Particle One
    public Particle pTwo; //Particle Two
    float Ks; //Spring Constant
    float Kd; //Damping Factor
    float Lo; //Rest Length
    float L; //Length
    //Properties of a spring damper

    public SpringDamper(Particle p1, Particle p2)
    {
        Ks = 750;
        Kd = 2;
        Lo = Vector3.Distance(p1.r, p2.r);
        pOne = p1;
        pTwo = p2;
    }
    

    public void Update()
    {
        //Moving the Particle
        var ePrime = pTwo.r - pOne.r;
        var eMag = ePrime.magnitude;
        var e = ePrime / eMag;
        //e.Normalize();

        var v1 = Vector3.Dot(e, pOne.v);
        var v2 = Vector3.Dot(e, pTwo.v);

        var Fsd = (-Ks * (Lo - eMag)) - (Kd * (v1 - v2));
        var F1 = Fsd * e;
        var F2 = -F1;
        pOne.AddForce(F1);
        pTwo.AddForce(F2);
    }

    void OnDrawGizmos()
    {

    }
}

[Serializable]
public class Particle
{
    public Vector3 r; //Position
    public Vector3 v; //Velocity
    public Vector3 a; //Acceleration
    public float m = 1f; //Mass
    public Vector3 f; //Force
    public bool anchor = false;
	
    public Particle(Vector3 position)
    {
        r = position;
        a = f * m;
    }
	
	// Update is called once per frame
	public void Update ()
    {
        //Acceleration
        a = f * m;
        //New Velocity
        v = v + (a * Time.deltaTime);
        //New Position
        r = r + (v * Time.deltaTime);

        f = Vector3.zero;
    }

    public void AddForce(Vector3 force)
    {
        f += force;
    }
}
