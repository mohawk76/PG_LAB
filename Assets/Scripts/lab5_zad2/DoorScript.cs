using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Transform hinge;
    private bool isOpening = false;
    public float openSpeed = 2.0f;
    public float openAngle = 90.0f;
    private float currentAngle = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        hinge = transform.parent;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isOpening && currentAngle < openAngle)
        {
            float angleToRotate = openSpeed * Time.deltaTime;
            hinge.Rotate(Vector3.up, angleToRotate);
            currentAngle += angleToRotate;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with " + collision.gameObject.name);
        if (collision.gameObject.name == "Player")
        {
            isOpening = true;
        }
    }
}
