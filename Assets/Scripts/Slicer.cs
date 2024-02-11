using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slicer : MonoBehaviour
{
    Rigidbody2D rb;
    public int comboCount;
    public float comboTimeLeft;
    public AudioClip comboSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPos.z = 0;

        //transform.position = worldPos;
        rb.MovePosition(worldPos);


        comboTimeLeft -= Time.deltaTime;
        if (comboTimeLeft <= 0)
        {
            if (comboCount>2)
            {
                AudioSystem.Play(comboSound);
                GameManager.score++;
                print("combo");
            }
            comboCount = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var food = other.gameObject.GetComponent<Food>();
        food.Slice();
        comboCount++;
        comboTimeLeft = 0.2f;
    }
}
