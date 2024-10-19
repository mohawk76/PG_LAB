using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float speed = 100f;
    private Rigidbody rb;
    private Vector3 direction;
    bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }

    }

    void FixedUpdate()
    {


        if (rb != null)
        {
            if (direction != Vector3.zero)
            {
                rb.velocity = new Vector3(direction.x * speed * Time.fixedDeltaTime, rb.velocity.y, direction.z * speed * Time.fixedDeltaTime);
            }

            if (jump)
            {
                rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
                jump = false;
            }
        }

    }
}
