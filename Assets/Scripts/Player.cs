using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Values")]
    public float walkSpeed = 200;
    public float maxHealth = 100;
    public float currentHealth;
    float runSpeedMultiplier = 1.8f;
    float speed;

    [Header("Input")]
    [SerializeField]
    [Range(-1, 1)]
    float horizontalInput;
    [Range(-1, 1)]
    [SerializeField]
    float verticalInput;

    [Header("States")]
    
    [SerializeField]
    bool canMove;
    [SerializeField]
    bool isRunning;

    [Header("Assignments")]
    Rigidbody2D playerRigidbody;
    Vector2 moveDir;
    void Awake()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();


    }

    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        isRunning = Input.GetButton("Run");

        if(isRunning)
        {
            speed = walkSpeed * runSpeedMultiplier * 1000;
        }
        else
        {
            speed = walkSpeed * 1000;
        }
        
        moveDir = new Vector2(horizontalInput, verticalInput).normalized * speed;

        playerRigidbody.AddForce(moveDir * Time.fixedDeltaTime);
    }



}
