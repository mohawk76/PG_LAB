using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public int numberOfCubes = 10;
    private List<Vector3> usedPositions = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        float gridSizeX = transform.localScale.x * 5;
        float gridSizeZ = transform.localScale.z * 5;
        int layer = LayerMask.NameToLayer("BoxesLayer");
        for (int i = 0; i < numberOfCubes; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Vector3 randomPosition;
            do
            {
                float x = Random.Range(-gridSizeX, gridSizeX);
                float z = Random.Range(-gridSizeZ, gridSizeZ);
                randomPosition = new Vector3(Mathf.Round(x), 0.5f, Mathf.Round(z));
            } while (usedPositions.Contains(randomPosition));
            cube.transform.position = randomPosition;
            usedPositions.Add(randomPosition);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
