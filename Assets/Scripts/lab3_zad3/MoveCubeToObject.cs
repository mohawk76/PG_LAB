using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubeToObject : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject target;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool movingForward = true;

    void Start()
    {
        startPosition = transform.position;
        endPosition = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;

        if (Vector3.Distance(currentPosition, endPosition) <= .5f)
        {
            movingForward = false;
        }

        if (Vector3.Distance(currentPosition, startPosition) <= .5f)
        {
            movingForward = true;
        }

        if (movingForward)
        {
            transform.position = Vector3.MoveTowards(currentPosition, endPosition, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(currentPosition, startPosition, speed * Time.deltaTime);
        }
    }
}
