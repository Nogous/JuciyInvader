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
    public bool playerInertie;

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
                SceneManager.LoadScene("SimeonScene 1");
            }
        }

        if(isPlayerDead)
        {
            losetext.SetActive(true);
            restartText.SetActive(true);
            controlsEnabled = false;
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SimeonScene 1");
            }
        }
    }
}
