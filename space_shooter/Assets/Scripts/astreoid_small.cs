using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class astreoid_small : MonoBehaviour
{

    public float speed = 100f;
    private Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed * Time.deltaTime;
        rb.AddTorque(Random.Range(-5f, 5f));
    }



    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other);
    }

    void Destroy(Collider2D other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            player playerHolder = collision.gameObject.GetComponent<player>();
            playerHolder.hp -= 1;
            print(playerHolder.hp);
            Destroy(gameObject);
            playerHolder.respawn();
        }
    }
}