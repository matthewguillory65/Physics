using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AABB
{
    public class CollisionBehavior : MonoBehaviour
    {
        AABBCollider coll;
        public GameObject box1, box2;
        public AABBCollider coll1, coll2;
        public bool isColliding = false;
        

        private void Start()
        {
            coll1 = box1.GetComponent<AABBCollider>();
            coll2 = box2.GetComponent<AABBCollider>();
        }

        public void Update()
        {
            if(coll1.min.x < coll2.max.x
                && coll1.max.x > coll2.min.x
                && coll1.min.y < coll2.max.y
                && coll1.max.y > coll2.min.y)
            {
                box1.GetComponent<Renderer>().material.color = UnityEngine.Color.blue;
                box2.GetComponent<Renderer>().material.color = UnityEngine.Color.blue;
                isColliding = true;
            }

            else
            {
                box1.GetComponent<Renderer>().material.color = UnityEngine.Color.white;
                box2.GetComponent<Renderer>().material.color = UnityEngine.Color.white;
                isColliding = false;
            }
        }
    }
}


