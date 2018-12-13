using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AABBCollider : MonoBehaviour {

    public Vector2 min, max;

    // Use this for initialization
    void Start ()
    {
        min = new Vector2(transform.position.x - ((transform.localScale.x) / 2), transform.position.y - ((transform.localScale.y) / 2));
        max = new Vector2(transform.position.x + ((transform.localScale.x) / 2), transform.position.y + ((transform.localScale.y) / 2));
    }
	
	// Update is called once per frame
	void Update ()
    {
        min = new Vector2(transform.position.x - ((transform.localScale.x) / 2), transform.position.y - ((transform.localScale.y) / 2));
        max = new Vector2(transform.position.x + ((transform.localScale.x) / 2), transform.position.y + ((transform.localScale.y) / 2));
    }
}