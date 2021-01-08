using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.UI;

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
    public GameObject bgParticles;
    public GameObject waterDistortion;
    public GameObject fireworks;

    [Header("Juicy Parameter")]
    public bool waterDistortionShader;
    public bool shockWaveShader;
    public bool enemyFade;
    public bool enemyTurnAround;
    public bool playerInertie;
    public bool vignette;
    public bool backgroundParticles;
    public bool enemyDeathEffect;
    public bool BGSound;
    public bool SFX;
    public bool playFireworks;
    private bool _BGSound;
    private bool _SFX;

    [Header("LoadScene")]
    public string sceneToLoad;

    [Header("Enemy Death Effect")]
    public List<GameObject> deathEffects;
    [Range(0,100)]
    public float spawnSecondEffectProbability = 50f;

    [Header("Camera")]
    public GameObject camera;

    public List<float> times = new List<float>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        Time.timeScale = 1f;
    }

    private void Start()
    {
        _BGSound = BGSound;
        _SFX = SFX;
    }

    // Update is called once per frame
    void Update()
    {
        times.Add(Time.deltaTime);
        for (int i = times.Count; i-->0;)
        {

        }

        if (!AreEnemiesLeft)
        {
            winText.SetActive(true);
            restartText.SetActive(true);
            controlsEnabled = false;
            fireworks.SetActive(true);
            if (!playFireworks)
            {
                fireworks.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.R))
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

        if(waterDistortionShader)
        {
            waterDistortion.SetActive(true);
        }
        else
        {
            waterDistortion.SetActive(false);
        }

        if (vignette)
        {
            camera.GetComponent<Volume>().enabled = true;
        }
        else
        {
            camera.GetComponent<Volume>().enabled = false;
        }

        if(backgroundParticles)
        {
            bgParticles.SetActive(true);
        }
        else
        {
            bgParticles.SetActive(false);
        }


        if (_BGSound != BGSound)
        {
            AudioManager.instance.UpdateVolume();
            _BGSound = BGSound;
        }
        if (_SFX != SFX)
        {
            AudioManager.instance.UpdateVolume();
            _SFX = SFX;
        }

        ActivateFeedbacks();
    }

    private void ActivateFeedbacks()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            waterDistortionShader = !waterDistortionShader;
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            shockWaveShader = !shockWaveShader;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            enemyFade = !enemyFade;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            enemyTurnAround = !enemyTurnAround;
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            playerInertie = !playerInertie;
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            vignette = !vignette;
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            backgroundParticles = !backgroundParticles;
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            enemyDeathEffect = !enemyDeathEffect;
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            BGSound = !BGSound;
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            SFX = !SFX;
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            playFireworks = !playFireworks;
        }
    }
}
