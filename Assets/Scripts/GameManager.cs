using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool azertyControle;

    public bool isPlayerDead = false;
    public bool AreEnemiesLeft = true;

    public bool controlsEnabled = true;

    public GameObject winText;
    public GameObject losetext;
    public GameObject restartText;

    [Header("Juicy Parameter")]
    public bool enemyFade;
    public bool enemyTurnAround;
    public bool playerInertie;

    public bool enemyDeathEffect;

    [Header("LoadScene")]
    public string sceneToLoad;

    [Header("Enemy Death Effect")]
    public List<ParticleSystem> deathEffects;
    [Range(0,100)]
    public float spawnSecondEffectProbability = 50f;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(!AreEnemiesLeft)
        {
            winText.SetActive(true);
            restartText.SetActive(true);
            controlsEnabled = false;
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }

        if(isPlayerDead)
        {
            losetext.SetActive(true);
            restartText.SetActive(true);
            controlsEnabled = false;
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
}
