using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFruit : MonoBehaviour
{
    public GameObject[] fruits;
    public float spawnSpeed = 1f;
    public int bombChance = 20;
    public GameObject bombPrefab;
    void Start()
    {
        InvokeRepeating("SpawnFruits", 0f, spawnSpeed);
    }

    void SpawnFruits()
    {
        var prefab = Random.Range(0, 100) > bombChance ? fruits[Random.Range(0, fruits.Length)] : bombPrefab;

        var obj = Instantiate(prefab);
        var x = Random.Range(-6, 6);
        obj.transform.position = new Vector3(x, -4.5f, 0);
        /*var randomPos = (Vector3)fruitSpawnPos.position;
        randomPos.z = 0f;
        randomPos.x = Random.Range(-6,6);
        Instantiate(fruits[Random.Range(0, fruits.Length)],randomPos, fruits[0].transform.rotation);*/
    }
}
