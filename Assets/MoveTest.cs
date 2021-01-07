using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    public float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            Vector3 tmp = transform.position;
            tmp.x += Time.deltaTime * speed;
            transform.position = tmp;
        }
        else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            Vector3 tmp = transform.position;
            tmp.x -= Time.deltaTime * speed;
            transform.position = tmp;
        }


        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            Vector3 tmp = transform.position;
            tmp.y += Time.deltaTime * speed;
            transform.position = tmp;
        }
        else if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
        {
            Vector3 tmp = transform.position;
            tmp.y -= Time.deltaTime * speed;
            transform.position = tmp;
        }
    }
}
