using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    public float speed = .1f;

    public float liveDuration = 5f;

    public bool activate;

    // Update is called once per frame
    void Update()
    {
        if (activate)
        {
            transform.position += direction * speed;
        }

        liveDuration -= Time.deltaTime;
        if (liveDuration<=0)
        {
            Destroy(gameObject);
        }
    }
}
