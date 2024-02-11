using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public GameObject rightSlice;
    public GameObject leftSlice;
    Rigidbody2D rb;
    public GameObject explodeParticles;
    public Color juiceColor;
    public AudioClip throwSound;
    public AudioClip sliceSound;
    public AudioClip missSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector2 (0, Random.Range(7f,13f));
        rb.angularVelocity = Random.Range(-360, 360);
        AudioSystem.Play(throwSound);
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
        GameManager.lives -= 1;
        AudioSystem.Play(missSound);
        print("lose");
        Destroy(gameObject);
    }

    public void Slice()
    {
        var particles = Instantiate(explodeParticles);
        particles.transform.position = transform.position;
        particles.GetComponent<ParticleSystem>().startColor = juiceColor;
        particles.GetComponentsInChildren<ParticleSystem>()[1].startColor = juiceColor;


        transform.DetachChildren();
        var leftRb = leftSlice.AddComponent<Rigidbody2D>();
        var rightRb = rightSlice.AddComponent<Rigidbody2D>();
        leftRb.velocity = rb.velocity + new Vector2(-2,0);
        rightRb.velocity = rb.velocity + new Vector2(2, 0);

        AudioSystem.Play(sliceSound);
        GameManager.score++;
        Destroy(gameObject);
    }
}
