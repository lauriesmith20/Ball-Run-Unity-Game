using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerController : MonoBehaviour
{
    public Transform PlayerTarget;

    PlayerController playerController;

    float trackerSpeed = 6f;
    float distanceToPlayer;
    Vector3 trackerVelocity;

    float turnSpeed= 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 1, 10);
        playerController = FindObjectOfType<PlayerController>();
        playerController.OnPlayerDeath += StopTrack;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directionToPlayer = PlayerTarget.position - transform.position;
        distanceToPlayer = directionToPlayer.magnitude;
        Vector3 movementVectorNorm  = directionToPlayer.normalized;
        trackerVelocity = movementVectorNorm * trackerSpeed;
        
        float angleToPlayer = Vector3.SignedAngle(transform.forward, directionToPlayer, Vector3.up);
        float turnAngle = Mathf.LerpAngle(0, angleToPlayer, turnSpeed);
        Vector3 vectorEulers = new Vector3(0, turnAngle, 0);
        

        if (Mathf.Abs(angleToPlayer) > 1f)
        {
            
            transform.Rotate(vectorEulers);

        }
      


    }

    void FixedUpdate()
    {
        if (distanceToPlayer > 0.5f) 
        {
            transform.position += (trackerVelocity * Time.fixedDeltaTime);
        }
        
    }

    void StopTrack()
    {
        trackerVelocity = new Vector3 (0,0,0);
    }

    
    
}
