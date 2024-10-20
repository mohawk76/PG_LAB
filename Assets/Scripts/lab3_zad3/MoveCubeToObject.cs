using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class MoveCubeToObject : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject target;
    private Vector3[] corners;
    private int currentTarget = 0;

    void Start()
    {
        Vector3 startPosition = transform.position;
        Vector3 endPosition = target.transform.position;
        corners = new Vector3[4];
        corners[0] = startPosition;
        corners[1] = startPosition + new Vector3(startPosition.x, startPosition.y, startPosition.z + endPosition.z);
        corners[2] = startPosition + new Vector3(startPosition.x + endPosition.x, startPosition.y, startPosition.z + endPosition.z);
        corners[3] = startPosition + new Vector3(startPosition.x + endPosition.x, startPosition.y, startPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;

        if (Vector3.Distance(currentPosition, corners[currentTarget]) <= 0.5f)
        {
            currentTarget = (currentTarget + 1) % 4;
            transform.LookAt(corners[currentTarget]);
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
