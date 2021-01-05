using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Values")]
    public float movementSpeed;
    public float oneEnemyLeftSpeed;
    public float fireRate = 0.997f;

    [Header("Enemies Bounds")]
    public float minXBound;
    public float maxXBound;

    [Header("Components")]
    public GameObject shot;
    private Transform enemyHolder;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
        enemyHolder = GetComponent<Transform>();
    }

    private void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        // Moves the enemy
        enemyHolder.position += Vector3.right * movementSpeed;

        // For every enemies in the container
        foreach (Transform enemy in enemyHolder)
        {
            // Set Boundaries and reverse the enemy movement
            if(enemy.position.x < minXBound || enemy.position.x > maxXBound)
            {
                movementSpeed = -movementSpeed;
                enemyHolder.position += Vector3.down * 0.5f;
                return;
            }

            // Shoot a bullet
            if(Random.value > fireRate)
            {
                Instantiate(shot, enemy.position, enemy.rotation);
            }
        }

        // Pace up the game when there is only one enemy left
        //if(enemyHolder.childCount == 1)
        //{
        //    movementSpeed = oneEnemyLeftSpeed;
        //}
    }
}
