using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float speed = 5.0f;
    private float startPositionX;
    private float endPositionX;
    private bool movingForward = true;
    private float moveDistance = 10.0f;

    void Start()
    {
        startPositionX = transform.position.x;
        endPositionX = startPositionX + moveDistance;
    }

    // Update is called once per frame
    void Update()
    {
        float currentPositionX = transform.position.x;
        if (currentPositionX >= endPositionX)
        {
            movingForward = false;
        }
        else if (currentPositionX <= startPositionX)
        {
            movingForward = true;
        }

        if (movingForward)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

        }
    }
}
