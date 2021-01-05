using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;

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

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

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

    public void DestroyEnemy(GameObject enemy)
    {
        foreach (Transform _enemy in enemyHolder)
        {
            if (_enemy.gameObject == enemy)
            {
                enemy.GetComponent<BoxCollider2D>().enabled = false;
                StartCoroutine(Tool.FadeImage(true, enemy));
            }
        }
    }

    public void EndDestroy(GameObject enemy)
    {
        Destroy(enemy);
    }
}
