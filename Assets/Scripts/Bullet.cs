using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 5f;

    Rigidbody2D myRigidbody;
    PlayerMovement player;

    float xSpeed;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * bulletSpeed;

    }

    void Update()
    {
        myRigidbody.velocity = new Vector2 (xSpeed, 0f);
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)), 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.tag == "Enemy")
        {
            Destroy (collision.gameObject);
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
