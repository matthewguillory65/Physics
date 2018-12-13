using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerodynamicForce
{
    public Vector3 p; //Density of the air
    Vector3 cD; //Coefficient of drag for the object
    Vector3 a; //Cross sectional area of the objbect
    Vector3 e; //Unit vector in the opposite direction of the velocity
    Vector3 v;
    public Particle r1, r2, r3;
    Vector3 faero;

    public AerodynamicForce(Particle one, Particle two, Particle three)
    {
        r1 = one;
        r2 = two;
        r3 = three;
    }
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	public void Update ()
    {
        Vector3 v1 = r1.v;
        Vector3 v2 = r2.v;
        Vector3 v3 = r3.v;
        var vAir = -p;
        var vSurface = (v1 + v2 + v3) / 3;
        v = vSurface - vAir;

        var particlePos = Vector3.Cross((r2.r - r1.r), (r3.r - r1.r));

        //Normal of a triangle
        var n = particlePos / particlePos.magnitude;

        //Area of a triangle
        var aO = .5f * Vector3.Cross((r2.r - r1.r), (r3.r - r1.r)).magnitude;
        var a = aO + (Vector3.Dot(v, n)/ v.magnitude);

        //Calculating the aerodynamic force
        var nPrime = particlePos;
        var totalForce = ((v.magnitude * Vector3.Dot(v, nPrime)) / (2 * nPrime.magnitude)) * nPrime;
        r1.AddForce(totalForce);
        r2.AddForce(totalForce);
        r3.AddForce(totalForce);
	}
}
