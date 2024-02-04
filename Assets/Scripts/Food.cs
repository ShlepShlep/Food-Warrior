using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    
    Rigidbody2D rb;
    public GameObject explodeParticles;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2 (0, Random.Range(7f,13f));
        rb.angularVelocity = Random.Range(-360, 360);
    }

    void Update()
    {
        if(transform.position.y < -5.5)
        {
            Miss();
        }
    }

    void Miss()
    {
        print("lose");
        Destroy(gameObject);
    }

    public void Slice()
    {
        var particles = Instantiate(explodeParticles);
        particles.transform.position = transform.position;

        Destroy(gameObject);
    }
}
