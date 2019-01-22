using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTargetScript : MonoBehaviour {


        // put the points from unity interface
        public Vector3[] wayPointList;

        public int currentWayPoint = 0;
        Vector3 targetWayPoint;

        public float speed = 4f;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            // check if we have somewere to walk
            if (currentWayPoint < this.wayPointList.Length)
            {
                if (targetWayPoint == default(Vector3))
                    targetWayPoint = wayPointList[currentWayPoint];
                walk();
            }
        }

        void walk()
        {
            // rotate towards the target
            //transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint - transform.position, speed * Time.deltaTime, 0.0f);

            // move towards the target
            transform.position = Vector3.MoveTowards(transform.position, targetWayPoint, speed * Time.deltaTime);

            if (transform.position == targetWayPoint)
            {
                currentWayPoint = (currentWayPoint + 1)%wayPointList.Length;
                targetWayPoint = wayPointList[currentWayPoint];
            }
        }
}
