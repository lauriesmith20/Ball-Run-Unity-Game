using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SphereController : MonoBehaviour
{
    public event Action NearMiss;

    public Vector3 nearMissMidpoint;

    Rigidbody SphereRigidbody;

    PlayerController playerController;

    float StartForce = 500;
    float incrementalForce = 1.5f;
    int corner = 28;
    int nearMissReset;

    // Start is called before the first frame update
    void Start()
    {
        
        SphereRigidbody = GetComponent<Rigidbody>();

        string sphereNumber = (SphereRigidbody.gameObject.name);

        if (sphereNumber == "Sphere")
        {
            SphereRigidbody.MovePosition(new Vector3(-corner, 2.5f, -corner));
        }
        if (sphereNumber == "Sphere (1)")
        {
            SphereRigidbody.MovePosition(new Vector3(corner, 2.5f, -corner));
        }
        if (sphereNumber == "Sphere (2)")
        {
            SphereRigidbody.MovePosition(new Vector3(-corner, 2.5f, corner));
        }
        if (sphereNumber == "Sphere (3)")
        {
            SphereRigidbody.MovePosition(new Vector3(corner, 2.5f, corner));
        }


        Vector3 randomDirection = new Vector3(UnityEngine.Random.Range(1, 10), 0, UnityEngine.Random.Range(1, 10));
        Vector3 randomDirNormalised = randomDirection.normalized;

        SphereRigidbody.AddForce(randomDirNormalised * StartForce);

        playerController = FindObjectOfType<PlayerController>();

    }

    void Update()
    {
        Vector3 playerSphereSeparation = playerController.playerRigidbodyPosition - SphereRigidbody.position;
        

        if (playerSphereSeparation.magnitude < 7f)
        {
            if (nearMissReset == 0)
            {
                nearMissReset = 1;

                if (Vector3.Angle(SphereRigidbody.velocity, playerSphereSeparation) < 100)
                {
                    
                    NearMiss();
                    
                   
                }
                
            }

        }
        if (playerSphereSeparation.magnitude > 10)
        {
            nearMissReset = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 currentDirection = SphereRigidbody.velocity.normalized;

        SphereRigidbody.AddForce(currentDirection * incrementalForce);
            

       
        
    }

    
}
