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

    [Header("Juicy Parameter")]
    public bool enemyFade;
    public bool enemyTurnAround;
    public bool playerInertie;
    public bool vignette;
    public bool enemyDeathEffect;
    public bool BGSound;
    public bool SFX;
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

    public Text debugTime;
    public float timeDebug = 0f;
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

        debugTime.text = timeDebug.ToString();

        if (!AreEnemiesLeft)
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

        if (vignette)
        {
            camera.GetComponent<Volume>().enabled = true;
        }
        else
        {
            camera.GetComponent<Volume>().enabled = false;
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
    }
}
