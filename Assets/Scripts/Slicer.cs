using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slicer : MonoBehaviour
{
    Rigidbody2D rb;

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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var food = other.gameObject.GetComponent<Food>();
        food.Slice();
    }
}
