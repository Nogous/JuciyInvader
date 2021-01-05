using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Values")]
    public float speed;

    private Transform bulletTransform;

    void Start()
    {
        bulletTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Moves the bullet 
        bulletTransform.position += Vector3.up * -speed;

        // Destroy the bullet when it is out of bounds
        if(bulletTransform.position.y <= -10)
        {
            Destroy(bulletTransform.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Collision with the player
        if(collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
