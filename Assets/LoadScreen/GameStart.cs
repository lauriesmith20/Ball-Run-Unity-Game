using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using TMPro;

public class GameStart : MonoBehaviour
{
    //public event Action StartUp;
    public TextMeshPro Highscore;
    public TextMeshPro spaceStart;
    public static float highestScore;
    

    // Start is called before the first frame update
    void Start()
    {
        
        highestScore = PlayerPrefs.GetFloat("savedHighScore");
        Highscore.text = "Highscore: " + highestScore;
        
    }

    // Update is called once per frame
    void Update()
    {
        spaceStart.color = new Color(spaceStart.color.r, spaceStart.color.g, spaceStart.color.b, Mathf.Abs(Mathf.Cos(Time.time * 7 / Mathf.PI)));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            
            SceneManager.LoadScene(1);
        }
    }

    
}
