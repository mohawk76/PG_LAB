using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformWaypoints : MonoBehaviour
{
    public Vector3[] waypoints;
    public float speed = 2.0f;
    private int currentWaypointIndex = 0;
    private bool movingForward = true;

    // Start is called before the first frame update
    void Start()
    {
        if (waypoints.Length > 0)
        {
            transform.position = waypoints[0];
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (waypoints.Length == 0)
            return;

        Vector3 target = waypoints[currentWaypointIndex];
        Vector3 moveDirection = target - transform.position;
        float distanceToMove = speed * Time.deltaTime;

        if (moveDirection.magnitude <= distanceToMove)
        {
            transform.position = target;
            if (movingForward)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = waypoints.Length - 1;
                    movingForward = false;
                }
            }
            else
            {
                currentWaypointIndex--;
                if (currentWaypointIndex < 0)
                {
                    currentWaypointIndex = 0;
                    movingForward = true;
                }
            }
        }
        else
        {
            transform.position += moveDirection.normalized * distanceToMove;
        }
    }
}
