using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static int Score;
    public static bool dead;
    public static float distanceTravelled;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject endGameScreen;
    [SerializeField] private ParticleSystem deathSplosion;
    [SerializeField] private GameObject Player;
    [SerializeField] private Text highScore;
    [SerializeField] private Text currentName;
    [SerializeField] private InputField enterName;
    [SerializeField] private GameObject enterNameField;
    [SerializeField] private Text StartHSName;
    [SerializeField] private Text StartHS;
    public static string playerName;
    [SerializeField] private bool inStart;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject PauseButton;


    private void Start()
    {
        Score = 0;
        PlayerController.paused = false;
        Time.timeScale = 0;
        inStart = true;

    }

    private void Update()
    {
        if (inStart)
        {
            if (DM.availableScore != 0)
            {
                if (DM.topDuckName != null)
                {
                    StartHSName.text = DM.topDuckName;
                }
                else
                {
                    StartHSName.text = "Unnamed Duck";
                }

                StartHS.text = DM.availableScore.ToString();
            }
            else
            {
                StartHSName.text = "";
                StartHS.text = " No High Score";
            }
        }

        scoreText.text = "Score: " + Score.ToString();

        if (dead)
        {
            if (Score >= DM.availableScore)
            {
                endGameScreen.SetActive(true);
                DM.newHighScore = true;
                GameOver();
            }
            else
            {
                endGameScreen.SetActive(true);
                GameOver();
            }
        }
    }

    public void Play()
    {
        PlayerController.paused = false;
        Time.timeScale = 1;
        inStart = false;
        enterNameField.SetActive(false);
        PauseButton.SetActive(true);
    }

    public void Pause(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0;
            PlayerController.paused = true;
            PauseMenu.SetActive(true);
        }

        if (!pause)
        {
            Time.timeScale = 1;
            PlayerController.paused = false;
            PauseMenu.SetActive(false);
        }
    }

    public void SaveName()
    {
        playerName = enterName.text; 
        currentName.text = "Current Name: " + playerName;
    }

    public void GameOver()
    {
        deathSplosion.gameObject.SetActive(true);
        Player.SetActive(false);
        distanceTravelled = Player.transform.position.y;

        if (DM.topDuckName == null)
        {
            DM.topDuckName = "Unnamed Duck";
        }

        if (DM.availableScore != 0)
            highScore.text = DM.topDuckName + ": " + DM.availableScore.ToString() + " / Distance flown: " + Mathf.Round(DM.topHeight);
        else
            highScore.text = "No High Score";

    }

    public void Retry()
    {
        dead = false;
        Player.SetActive(true);
        deathSplosion.gameObject.SetActive(false);
        SceneManager.LoadScene(0);

    }

    public void Quit()
    {
        
        Application.Quit();
    }

}
