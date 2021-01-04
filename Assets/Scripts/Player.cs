using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Bullet bullet;

    public float speed = .1f;

    // Move
    public KeyCode shootKey = KeyCode.Space;
    public KeyCode moveRightKey = KeyCode.D;
    public KeyCode moveLeftKey = KeyCode.A;

    // Azerty
    public KeyCode azertyLeft = KeyCode.Q;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.azertyControle)
        {
            moveLeftKey = azertyLeft;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            Bullet tmp = Instantiate(bullet);
            tmp.transform.position = transform.position;
            tmp.direction = Vector3.up;
            tmp.activate = true;
        }

        if (Input.GetKey(moveLeftKey) && !Input.GetKeyDown(moveRightKey))
        {
            transform.position += Vector3.left * speed;
        }

        if (Input.GetKey(moveRightKey) && !Input.GetKeyDown(moveLeftKey))
        {
            transform.position += Vector3.right * speed;
        }
    }
}
