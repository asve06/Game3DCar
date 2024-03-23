using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] itemPrefab;
    public float minTime = 1f;
    public float maxTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCoroutine(0));
    }

    IEnumerator SpawnCoroutine(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Vector3 spawnPosition = transform.position; 
            Quaternion spawnRotation = Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)); // Rotación aleatoria en 3 ejes
            Instantiate(itemPrefab[Random.Range(0, itemPrefab.Length)], spawnPosition, spawnRotation);
            waitTime = Random.Range(minTime, maxTime);
        }
    }
}
