using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    float speed = 5.0f;
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
        if (movingForward)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (currentPositionX >= endPositionX)
            {
                movingForward = false;
            }
        }
        // Ruch powrotny
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (currentPositionX <= startPositionX)
            {
                movingForward = true;
            }
        }
    }
}
