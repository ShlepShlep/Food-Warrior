using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFruit : MonoBehaviour
{
    public GameObject[] fruits;
    public Transform fruitSpawnPos;
    void Start()
    {
        InvokeRepeating("SpawnFruits", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnFruits()
    {
        var randomPos = (Vector3)fruitSpawnPos.position;
        randomPos.z = 0f;
        randomPos.x = Random.Range(-6,6);
        Instantiate(fruits[Random.Range(0, fruits.Length)],randomPos, fruits[0].transform.rotation);
    }
}
