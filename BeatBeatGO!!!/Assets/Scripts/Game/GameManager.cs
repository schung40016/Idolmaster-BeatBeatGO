using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static bool isPaused = false;
    private float playerMaxHealth = 100;
    private float playerCurrHealth;
    private bool isLost = false;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private AudioSource musicPlayer;
    [SerializeField] private SpriteRenderer shading;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject pauseMenu;

    void Start()
    {
        playerCurrHealth = playerMaxHealth;
        healthBar.SetMaxHealth(playerMaxHealth);
        videoPlayer.clip = GameMaster.GM.currentSong.GetVideo();
        musicPlayer.clip = GameMaster.GM.currentSong.GetFullSong();
        musicPlayer.volume = GameMaster.GM.currVolume;
        shading.color = new Color(0f, 0f, 0f, GameMaster.GM.currShader);

    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player lost or not.
        if (!isLost)
        {
            // Trace when player goes to pause menu.
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (pauseMenu.activeSelf)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    public void Resume()
    {
        //pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        videoPlayer.Play();
        musicPlayer.Play();
        pauseMenu.gameObject.SetActive(false);
        settings.SetActive(false);
        isPaused = false;
    }

    void Pause()
    {
        //pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        videoPlayer.Pause();
        musicPlayer.Pause();
        pauseMenu.gameObject.SetActive(true);
        isPaused = true;
    }

    public bool GetPaused()
    {
        return isPaused;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Test");
        this.Resume();
    }

    public void Settings()
    {
        if (!settings.activeSelf)
        {
            settings.SetActive(true);
        }
        else
        {
            settings.SetActive(false);
        }
    }

    public void SetVolume(float value)
    {
        GameMaster.GM.currVolume = value;
        musicPlayer.volume = GameMaster.GM.currVolume;
    }

    public void SetShader(float value)
    {
        GameMaster.GM.currShader = value;
        shading.color = new Color(0f, 0f, 0f, GameMaster.GM.currShader);
    }

    public void SetHealth(float add)
    {
        this.playerCurrHealth += add;
        healthBar.SetHealth(playerCurrHealth);
        if (playerCurrHealth <= 0)
        {
            this.isLost = true;
            this.Pause();
        }
        if (playerCurrHealth > playerMaxHealth)
        {
            this.playerCurrHealth = 100;
        }
    }

    public void Quit()
    {
        Time.timeScale = 1f;

        // TO-DO: Load main music scene.
        SceneManager.LoadScene("MainMenu");
    }
}
