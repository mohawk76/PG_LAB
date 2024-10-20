using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomCubesGenerator : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    // obiekt do generowania
    public List<GameObject> blocks;
    public int objectCount = 10;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        Vector3 min = renderer.bounds.min;
        Vector3 max = renderer.bounds.max;
        int maxX = Mathf.RoundToInt(max.x - min.x) + 1;
        int maxZ = Mathf.RoundToInt(max.z - min.z) + 1;

        if (objectCount > maxX * maxZ)
        {
            transform.localScale = new Vector3(objectCount / maxX, 1, objectCount / maxZ);
            min = renderer.bounds.min;
            max = renderer.bounds.max;
            maxX = Mathf.RoundToInt(max.x - min.x);
            maxZ = Mathf.RoundToInt(max.z - min.z);
        }

        List<int> pozycje_x = new List<int>(Enumerable.Range(Mathf.RoundToInt(min.x), maxX));
        List<int> pozycje_z = new List<int>(Enumerable.Range(Mathf.RoundToInt(min.z), maxZ));
        List<Vector2> uniqueCombinations = pozycje_x.SelectMany(x => pozycje_z, (x, z) => new { x, z })
                                          .OrderBy(x => Guid.NewGuid())
                                          .Select(pair => new Vector2(pair.x, pair.z))
                                          .ToList();


        for (int i = 0; i < objectCount; i++)
        {
            positions.Add(new Vector3(uniqueCombinations[i].x, max.y, uniqueCombinations[i].y));
        }
        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywo³ano coroutine");
        foreach (Vector3 pos in positions)
        {
            var block = blocks.ElementAt(UnityEngine.Random.Range(0, blocks.Count));
            Instantiate(block, positions.ElementAt(objectCounter++), Quaternion.identity);
            yield return new WaitForSeconds(delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}