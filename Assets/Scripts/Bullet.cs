using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    public float speed = .1f;

    public float liveDuration = 5f;

    public bool activate;

    public GameObject shockWave;

    // Update is called once per frame
    void Update()
    {
        if (activate)
        {
            transform.position += direction * speed * Time.deltaTime;
        }

        liveDuration -= Time.deltaTime;
        if (liveDuration<=0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            if (GameManager.instance.enemyFade)
            {
                EnemyController.instance.DestroyEnemy(collision.gameObject);
            }
            else
            {
                EnemyController.instance.DestroyEnemy(collision.gameObject);
            }
            Instantiate(shockWave, collision.transform.position, collision.transform.rotation);
            Destroy(gameObject);
        }
    }
}
