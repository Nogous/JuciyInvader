using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Bullet bullet;

    // Move
    public KeyCode shootKey = KeyCode.Space;
    public KeyCode moveRightKey = KeyCode.D;
    public KeyCode moveLeftKey = KeyCode.A;

    // Azerty
    public KeyCode azertyLeft = KeyCode.Q;

    [Header("Bounds")]
    public float minXBound;
    public float maxXBound;

    [Header("Juicy Parameter")]
    public float cooldawnShoot = 1f;
    private float cooldawn = 0f;

    public float currentSpeed = 0f;
    public float maxSpeed = .1f;
    public float inertieSpeed = 1f;

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
        if (!GameManager.instance.controlsEnabled) return;

        if (cooldawn>0)
        {
            cooldawn -= Time.deltaTime;
        }
        else
        {
            if (Input.GetKey(shootKey))
            {
                cooldawn = cooldawnShoot;
                Bullet tmp = Instantiate(bullet);
                tmp.transform.position = transform.position;
                tmp.direction = Vector3.up;
                tmp.activate = true;
            }
        }

        if (GameManager.instance.playerInertie)
        {
            if (Input.GetKey(moveRightKey) && !Input.GetKeyDown(moveLeftKey))
            {
                currentSpeed += Time.deltaTime * inertieSpeed;
                if (currentSpeed > maxSpeed)
                {
                    currentSpeed = maxSpeed;
                }
            }
            else if (Input.GetKey(moveLeftKey) && !Input.GetKeyDown(moveRightKey))
            {
                currentSpeed -= Time.deltaTime * inertieSpeed;
                if (currentSpeed < -maxSpeed)
                {
                    currentSpeed = -maxSpeed;
                }
            }
            else
            {
                if (currentSpeed > 0)
                {
                    currentSpeed -= Time.deltaTime * inertieSpeed;
                    if (currentSpeed < 0)
                    {
                        currentSpeed = 0;
                    }
                }
                else if (currentSpeed < 0)
                {
                    currentSpeed += Time.deltaTime * inertieSpeed;
                    if (currentSpeed > 0)
                    {
                        currentSpeed = 0;
                    }
                }
            }

            transform.position += Vector3.right * currentSpeed;

            if (transform.position.x < minXBound)
            {
                Vector3 tmp = transform.position;
                tmp.x = minXBound;
                transform.position = tmp;
            }
            if (transform.position.x > maxXBound)
            {
                Vector3 tmp = transform.position;
                tmp.x = maxXBound;
                transform.position = tmp;
            }
        }
        else
        {
            if (Input.GetKey(moveLeftKey) && !Input.GetKeyDown(moveRightKey))
            {
                transform.position += Vector3.left * maxSpeed;
                if (transform.position.x < minXBound)
                {
                    Vector3 tmp = transform.position;
                    tmp.x = minXBound;
                    transform.position = tmp;
                }
            }

            if (Input.GetKey(moveRightKey) && !Input.GetKeyDown(moveLeftKey))
            {
                transform.position += Vector3.right * maxSpeed;
                if (transform.position.x > maxXBound)
                {
                    Vector3 tmp = transform.position;
                    tmp.x = maxXBound;
                    transform.position = tmp;
                }
            }
        }


        GameManager.instance.timeDebug = currentSpeed;
    }
}
