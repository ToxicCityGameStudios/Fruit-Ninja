using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    // Sliced Gameobject that should replace the current fruit
    public GameObject slicedFruitPrefab;
    public float explosionRadius = 5f;
    public float destroyTime = 5f;
    private GameManager gameManager;
    public int scoreAmount = 3;

    // Method that will destroy the current Gameobject and replace it with the sliced fruit
    public void CreateSlicedFruit()
    {
        GameObject inst = Instantiate(slicedFruitPrefab, transform.position, transform.rotation);

        Rigidbody[] rbOnSliced = inst.transform.GetComponentsInChildren<Rigidbody>();

        // This will iterate through all of the Rigidbodays inside of the array rbOnSliced
        foreach (Rigidbody rigidbody in rbOnSliced)
        // and execute this code for each item in the array
        {
            // give the rigidboda a random rotation (rotate the banana slice)
            rigidbody.transform.rotation = Random.rotation;
            // add an explosion in the center of the banana.
            rigidbody.AddExplosionForce(Random.Range(500, 1000), transform.position, explosionRadius);
        }
        gameManager.IncreaseScore(scoreAmount);

        // destroy the current fruit.
        Destroy(gameObject);
        Destroy(inst, destroyTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();
        if (!b)
        {
            return;
        }
        CreateSlicedFruit();
    }
}
