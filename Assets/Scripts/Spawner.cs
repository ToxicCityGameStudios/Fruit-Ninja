using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fruitToSpawnPrefab;
    public Transform[] spawnPoints;
    public float minWait = 0.3f;
    public float maxWait = 1f;
    public float minForce = 10f;
    public float maxForce = 20f;
    public float destroyTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruits());   
    }

    private IEnumerator SpawnFruits()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));
            Transform t = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject fruit = Instantiate(fruitToSpawnPrefab, t.transform.position, t.transform.rotation);
            fruit.GetComponent<Rigidbody2D>().AddForce(t.transform.up*Random.Range(minForce, maxForce), ForceMode2D.Impulse);
            Debug.Log("Spawning Fruit");
            Destroy(fruit, destroyTime);
        }
    }
}
