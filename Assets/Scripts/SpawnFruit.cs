using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FoodEntry
{
    public bool isBomb;
    public float x;
    public float delay;
    public bool isRandomPosition;
    public Vector2 velocity =  new Vector2(0,10);
}
[System.Serializable]
public class Wave
{
    public List<FoodEntry> foods;
}

public class SpawnFruit : MonoBehaviour
{
    public GameObject[] fruits;
    public float spawnSpeed = 1f;
    public int bombChance = 20;
    public GameObject bombPrefab;

    public int currentWave;
    public List<Wave> waves;

    async void Start()
    {
        while (currentWave < waves.Count)
        {
            var wave = waves[currentWave];

            for(int i = 0; i < wave.foods.Count; i++)
            {
                var food = wave.foods[i];

                await new WaitForSeconds(food.delay);
                var prefab = food.isBomb ? bombPrefab : fruits[Random.Range(0, fruits.Length)];
                var go = Instantiate(prefab);
                if (food.isRandomPosition)
                {
                    go.transform.position = new Vector3(Random.Range(-5, 5), -5, 0);
                }
                else
                {
                    go.transform.position = new Vector3(food.x, -5, 0);
                }
                go.GetComponent<Rigidbody2D>().velocity = food.velocity;
                
            }
            /*var prefab = waves[currentWave].isBomb ? bombPrefab:fruits[Random.Range(0, fruits.Length)];
            var obj = Instantiate(prefab);
            var x = waves[currentWave].x;
            obj.transform.position = new Vector3(x, -5, 0);*/
            
            await new WaitForSeconds(3f);
            currentWave++;

        }
    }
}
