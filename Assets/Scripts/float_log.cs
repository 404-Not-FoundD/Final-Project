using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class float_log : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] int range = 10;

    private Rigidbody2D rb;
    Vector3 original_position;
    bool face_left = true; // Start by facing left.


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        original_position = transform.position;
    }

    void Update()
    {
        move();
    }

    void move()
    {
        if (face_left) {
            Vector2 velocity = new Vector2(-speed,rb.velocityY);
            rb.position += velocity * Time.deltaTime;
            if (transform.position.x < (original_position.x - range)) face_left = false;
        }
        else{
            Vector2 velocity = new Vector2(speed,rb.velocityY);
            rb.position += velocity * Time.deltaTime;            
            if (transform.position.x > (original_position.x + range)) face_left = true;
        }
    }
}