using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int score;
    public Text scoreText;
    int life = 3;
    public Text lifePoint;
    public GameObject gameOverPr, winnerPr, resetPr, nextLevelPr;

    public bool isGameActive = true;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOverPr.SetActive(false);
        winnerPr.SetActive(false);
        resetPr.SetActive(false);
        nextLevelPr.SetActive(false);
    }

    public void scoreIsUp()
    {
        score++;
        scoreText.text = score.ToString();
        if (score == 5)
        {
            isGameActive = false;
            winnerPr.SetActive(true);
            nextLevelPr.SetActive(true);
            string currentSceneName = SceneManager.GetActiveScene().name;
            if (currentSceneName != "Level3")
            {
                nextLevelPr.SetActive(true);
            }
        }
    }

    public void lifeDecrease()
    {
        life--;
        lifePoint.text = life.ToString();
        if (life == 0)
        {
            isGameActive = false;
            gameOverPr.SetActive(true);
            resetPr.SetActive(true);
        }
    }

    public void homeButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void nextLevelButton()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "Level2")
        {
            SceneManager.LoadScene("Level3");
        }
        else if (currentSceneName == "Level1") // Para casos donde estés en el Nivel 1
        {
            SceneManager.LoadScene("Level2");
        }
    }


    public void resetButton()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

}
