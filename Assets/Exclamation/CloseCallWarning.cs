using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CloseCallWarning : MonoBehaviour
{

    public GameObject exclamPrefab;
    public GameObject createdExclam;

    PlayerController playerController;
    SphereController sphereC;
    Score scorer;


    // Start is called before the first frame update
    void Start()
    {

        playerController = FindObjectOfType<PlayerController>();
        scorer = FindObjectOfType<Score>();

        foreach (GameObject item in playerController.enemies)
        {

            sphereC = item.GetComponent<SphereController>();
            sphereC.NearMiss += ExclamationAppear;

        }



    }
    

    void Update()
    {
        if (createdExclam)
        {
            createdExclam.transform.position += new Vector3(0, .1f, 0);
            TextMeshPro textMesh = createdExclam.GetComponentInChildren<TextMeshPro>();
            textMesh.color -= new Color(0, 0, 0, .01f);
            textMesh.transform.localScale -= new Vector3(1,1,1) * 0.003f;

        }
    }



    void ExclamationAppear()
    {
        
        if (scorer.stopScore == 0)
        {
            GameObject prefab = Instantiate(exclamPrefab, playerController.playerRigidbodyPosition, Camera.main.transform.rotation);
            createdExclam = prefab;
            Destroy(prefab, .8f);
        }
        
        
        
        
    }

    

}