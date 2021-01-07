using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWave : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private float maxTime = 0.75f;
    private float startTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        startTime += Time.deltaTime;
        if (startTime > maxTime)
        {
            spriteRenderer.material = null;
            Destroy(gameObject);
        }
    }
}
