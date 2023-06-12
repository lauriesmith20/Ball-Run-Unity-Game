using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public GameObject gameOverScreen;
    PlayerController playerController;

    Score scorer;

    public TextMeshPro FinalScore;
    public TextMeshPro PlayAgain;
    public TextMeshPro highScore;
    public int flashyScore;
    
    bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        
        playerController = FindObjectOfType<PlayerController>();
        playerController.OnPlayerDeath += OnGameOver;

        scorer = FindObjectOfType<Score>();
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PlayAgain.color = new Color (PlayAgain.color.r, PlayAgain.color.g, PlayAgain.color.b, Mathf.Abs(Mathf.Cos(Time.time*7 / Mathf.PI)));

        if (flashyScore == 1)
        {
            highScore.color = new Color(highScore.color.r, highScore.color.g, highScore.color.b, Mathf.Abs(Mathf.Cos(Time.time * 12 / Mathf.PI)));
        }

        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(1);
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    void OnGameOver()
    {
        
        FinalScore.text = ""+ scorer.roundedScore;

        if (scorer.roundedScore > GameStart.highestScore)
        {
            highScore.text = "NEW HIGHSCORE";
            flashyScore = 1;
        }
        else
        {
            highScore.text = "Highscore: " + GameStart.highestScore;
        }

        gameOver = true;
        gameOverScreen.SetActive(true);

    }
}
