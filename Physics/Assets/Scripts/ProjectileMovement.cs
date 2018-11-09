using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//namespace Particles.Physic
//{
//    [CreateAssetMenu]
//    public class ProjectileMovement : ScriptableObject
//    {
//        public Vector2 InitialVelocity;
//        public Vector2 FinalVelocity;
//        public Vector2 InitialPosition;
//        public Vector2 FinalPosition;
//        public readonly float Gravity = 9.8f;
//        public float range;
//        public float Time;
//        public float Displacement;
//        public float Angle;
//        public float HorizontalDistance;
//        public float VerticalDistance;
//        public float TimeOfFlight;//Time of Flight
//        public float ymax = 0;//Max Height on y
//    }

//    [CustomEditor(typeof(ProjectileMovement))]

//    public class ProjectileMove : Editor
//    {

//        private float magVel;
//        public override void OnInspectorGUI()
//        {
//            DrawDefaultInspector();

//            Projectile Motion
//            GUIStyle boxstyle = new GUIStyle(GUI.skin.box);
//            ProjectileMovement pM = (ProjectileMovement)target;


//            if (GUILayout.Button("Calculate"))
//            {
//                CalculateVelocity();
//                TimeofFlight();
//                MaxHeight();
//            }
//            GUILayout.Box("Velocity : " + pM.FinalVelocity.x + ", " + pM.FinalVelocity.y, boxstyle);
//            GUILayout.Box("Time of Flight : " + pM.TimeOfFlight, boxstyle);
//            GUILayout.Box("Max Height : " + pM.ymax, boxstyle);
//        }

//        void CalculateVelocity()
//        {
//            ProjectileMovement pM = (ProjectileMovement)target;

//            pM.FinalVelocity.x = pM.InitialVelocity.x * Mathf.Cos(pM.Angle);
//            pM.FinalVelocity.y = pM.InitialVelocity.y * Mathf.Sin(pM.Angle);
//        }

//        void Motion()
//        {
//            ProjectileMovement pM = (ProjectileMovement)target;

//            pM.HorizontalDistance = pM.InitialVelocity.x * pM.Time;
//            pM.VerticalDistance = (pM.InitialVelocity.y * pM.Time - pM.Gravity * (pM.Time * pM.Time)) / 2.0f;
//        }

//        void TimeofFlight()
//        {
//            ProjectileMovement pM = (ProjectileMovement)target;

//            pM.TimeOfFlight = (2 * pM.InitialVelocity.y) / pM.Gravity;
//        }

//        void MaxHeight()
//        {
//            ProjectileMovement pM = (ProjectileMovement)target;

//            pM.ymax = (pM.InitialVelocity.y * pM.InitialVelocity.y) / (2 * pM.Gravity);
//        }
//    }

//}