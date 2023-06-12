using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public event Action OnPlayerDeath;

    public GameObject[] enemies;
    

    public Rigidbody PlayerRigidbody;
    public Vector3 playerRigidbodyPosition;

    

    float playerSpeed = 20;
    Vector3 playerVelocity;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
        PlayerRigidbody.position = new Vector3(0, 1, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 normalInputDir = inputDirection.normalized;
        playerVelocity = normalInputDir * playerSpeed;

        playerRigidbodyPosition = PlayerRigidbody.position;
    }

    void FixedUpdate()
    {

        PlayerRigidbody.velocity = playerVelocity;
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            OnPlayerDeath();
            
        }
    }
}
