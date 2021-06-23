using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static int Score;
    public static bool dead;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject endGameScreen;

    private void Start()
    {
        Score = 0;
    }

    private void Update()
    {
        scoreText.text = "Score: " + Score.ToString();

        if (dead)
        {
            endGameScreen.SetActive(true);
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
