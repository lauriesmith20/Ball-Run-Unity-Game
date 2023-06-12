using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


public class Score : MonoBehaviour
{
    PlayerController playerController;
    

    SphereController sphereC;


    public TextMeshPro scoreDisplay;
    public TextMeshPro bonusPoints;

    public GameObject bonusPopup;
    public GameObject prefab;
    
    float startScore = 0;
    public float stopScore;
    public float currentScore;
    public float roundedScore;
    
    

    public float bonusPointsValue = 20;

    // Start is called before the first frame update
   
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        playerController.OnPlayerDeath += StopScore;

        foreach (GameObject item in playerController.enemies)
        {
         
            sphereC = item.GetComponent<SphereController>();
            sphereC.NearMiss += BonusScore;
           
        }


        
        scoreDisplay.text = "Score: " + startScore;
        
        




    }

    // Update is called once per frame
    void Update()
    {



        if (stopScore == 0)
        {
            currentScore += 0.1f;
            roundedScore = MathF.Round(currentScore);
            scoreDisplay.text = "Score: " + roundedScore;
        }

        if (prefab)
        {
            prefab.transform.Translate(new Vector3 (0,0.1f,0f));
            TextMeshPro textMesh = prefab.GetComponentInChildren<TextMeshPro>();
            textMesh.color -= new Color(0, 0, 0, .01f);
            textMesh.transform.localScale -= new Vector3(1, 1, 1) * 0.01f;
        }
        
    }

    public void StopScore()
    {
        stopScore = 1;
        if (roundedScore > GameStart.highestScore)
        {
             GameStart.highestScore = roundedScore;
             PlayerPrefs.SetFloat("savedHighScore", roundedScore);
        }
        
        
    }

    public void BonusScore()
    {
       
        if (stopScore == 0)
        {
            currentScore += bonusPointsValue;
            bonusPoints.text = "+"+bonusPointsValue;
            prefab = Instantiate(bonusPopup, new Vector3(2, 1f, -29), Quaternion.Euler(90, 0, 0));

            Destroy(prefab, 0.8f);
        }
        
    }
}
