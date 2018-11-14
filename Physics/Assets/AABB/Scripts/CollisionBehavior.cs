using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AABB
{
    public class CollisionBehavior : MonoBehaviour
    {
        public Vector2 minXY;
        public Vector2 maxXY;

        public bool isColliding = false;

        [NonSerialized]
        List<CollisionBehavior> XYmin;
        [NonSerialized]
        List<CollisionBehavior> XYmax;

        private void Start()
        {

        }

        public void AddToList()
        {
            
        }

        public void RemoveFromList()
        {
            
        }
        
        public void Collide()
        {

        }
    }
}


