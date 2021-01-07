using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;

    [Header("Values")]
    public float movementSpeed;
    public float inertieTurnAround = 1f;
    public float inertieTurnAroundMoveDawn = 1f;
    public float oneEnemyLeftSpeed;
    public float fireRate = 0.997f;
    public float dawnMoveSpeed = .5f;

    [Header("Enemies Bounds")]
    public float minXBound;
    public float maxXBound;

    [Header("Components")]
    public GameObject shot;
    private Transform enemyHolder;

    // move smooth
    private bool isMoveRight = true;
    private float curentSpeed = 0;
    private bool TurnAround = true;
    private Vector3 nextEnemyHolderPosition;

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

        curentSpeed = movementSpeed;
    }

    private void Update()
    {
        if(GameManager.instance.controlsEnabled)
        {
            MoveEnemy();
        }
    }

    void MoveEnemy()
    {

        // Moves the enemy
        enemyHolder.position += Vector3.right * curentSpeed * Time.deltaTime;

        // For every enemies in the container
        foreach (Transform enemy in enemyHolder)
        {
            if (!TurnAround)
            {
                // Set Boundaries and reverse the enemy movement
                if ((enemy.position.x < minXBound && !isMoveRight) || (enemy.position.x > maxXBound && isMoveRight))
                {
                    nextEnemyHolderPosition = enemyHolder.position + Vector3.down * dawnMoveSpeed;
                    TurnAround = true;
                    return;
                }
            }
            else
            {
                SwitchMoveDir();
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
        if (enemyHolder.childCount == 0)
        {
            GameManager.instance.AreEnemiesLeft = false;
        }
    }

    private void SwitchMoveDir()
    {
        if (GameManager.instance.enemyTurnAround)
        {
            if (isMoveRight)
            {
                curentSpeed -= Time.deltaTime * inertieTurnAround;

                if (curentSpeed < -movementSpeed)
                {
                    curentSpeed = -movementSpeed;
                    TurnAround = false;
                    isMoveRight = false;
                }
            }
            else
            {
                curentSpeed += Time.deltaTime * inertieTurnAround;
                if (curentSpeed > movementSpeed)
                {
                    curentSpeed = movementSpeed;
                    TurnAround = false;
                    isMoveRight = true;
                }
            }

            enemyHolder.position += Vector3.down * Time.deltaTime * inertieTurnAroundMoveDawn;
            if (enemyHolder.position.y < nextEnemyHolderPosition.y)
            {
                Vector3 tmp = enemyHolder.position;
                tmp.y = nextEnemyHolderPosition.y;
                enemyHolder.position = tmp;
            }
        }
        else
        {
            curentSpeed = -curentSpeed;
            TurnAround = false;
            enemyHolder.position += Vector3.down * 0.5f;
            isMoveRight = !isMoveRight;
        }
    }

    public void DestroyEnemy(GameObject enemy)
    {
        foreach (Transform _enemy in enemyHolder)
        {
            if (_enemy.gameObject == enemy)
            {
                AudioManager.instance.Play("Bubble");
                enemy.GetComponent<BoxCollider2D>().enabled = false;
                StartCoroutine(Tool.FadeImage(true, enemy));

                if (GameManager.instance.enemyDeathEffect)
                {
                    if (GameManager.instance.deathEffects.Count > 1)
                    {
                        GameObject tmp = Instantiate(GameManager.instance.deathEffects[0]);
                        tmp.transform.position = enemy.transform.position + Vector3.back;

                        if (GameManager.instance.deathEffects.Count > 2)
                        {
                            if (Random.Range(1, 100) <= GameManager.instance.spawnSecondEffectProbability)
                            {
                                tmp = Instantiate(GameManager.instance.deathEffects[Random.Range(1, GameManager.instance.deathEffects.Count)]);
                                tmp.transform.position = enemy.transform.position + Vector3.back;
                            }
                        }
                        else
                        {
                            Debug.Log("Pas de second effect de mort dans la liste d'effect pour l'enemie");
                        }
                    }
                    else
                    {
                        Debug.Log("Pas d'effect de mort dans la liste d'effect pour l'enemie");
                    }
                }

                return;
            }
        }
    }

    public void EndDestroy(GameObject enemy)
    {
        Destroy(enemy);
    }
}
