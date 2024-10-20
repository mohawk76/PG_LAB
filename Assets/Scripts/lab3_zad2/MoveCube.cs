using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float moveDistance = 10.0f;

    void Start()
    {
        startPosition = transform.position;
        endPosition = new Vector3(startPosition.x + moveDistance, startPosition.y, startPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;

        if (Vector3.Distance(currentPosition, endPosition) <= .1f)
        {
            transform.LookAt(startPosition);
        }
        else if (Vector3.Distance(currentPosition, startPosition) <= .1f)
        {
            transform.LookAt(endPosition);
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
