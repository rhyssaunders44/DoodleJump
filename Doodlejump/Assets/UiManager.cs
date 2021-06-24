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


    private void Start()
    {
        Score = 0;
        PlayerController.paused = true;
        Time.timeScale = 0;
        if(GameData.highScoreName != null)
        {
            StartHSName.text = GameData.highScoreName;
            StartHS.text = GameData.score.ToString();
        }
        else
        {
            StartHSName.text = "";
            StartHS.text = " No High Score";
        }
    }

    private void Update()
    {
        scoreText.text = "Score: " + Score.ToString();


        if (dead)
        {
            if (Score >= GameData.score)
            {
                endGameScreen.SetActive(true);
                GameData.HighScoreFinalise();
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
        enterNameField.SetActive(false);
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

        if (GameData.highScoreName == null)
        {
            GameData.highScoreName = "Unnamed Duck";
        }

        if (GameData.score != 0)
            highScore.text = GameData.highScoreName + ": " + GameData.score.ToString() + " / Distance flown: " + Mathf.Round(GameData.maxHeight);
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
