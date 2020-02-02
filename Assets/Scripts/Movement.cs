using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public static string moveForward = "MoveForward_P";
    public static string moveRight = "MoveRight_P";

    // Start is called before the first frame update
    CharacterController characterController;
    public float initialSpeed = 6.0f;
    private float currentSpeed;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    //public Rigidbody moverthing;
    private Vector3 moveDirection = Vector3.zero;

    private string moveForwardAxis;
    private string moveRightAxis;

     public const string MOVEMENTANIM = "Movement";
    public Animator Anim;
    [Range(1,4)]
    public int playerNum = 2;
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        moveForwardAxis = moveForward + playerNum;
        moveRightAxis = moveRight + playerNum;

        Anim = this.GetComponent<Animator>();
    }

    
    // Update is called once per frame
    void Update()
    {
        
        float moveForward = Input.GetAxis(moveForwardAxis);
        float moveRight = Input.GetAxis(moveRightAxis);

        if (moveForward == 0 && moveRight == 0)
        {
            currentSpeed = 0;
            Animation();
            Build();
            return;
        }
        currentSpeed = initialSpeed;
      moveDirection = new Vector3(moveRight, 0.0f, moveForward * -1);
        moveDirection *= currentSpeed;
        characterController.Move(moveDirection * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(moveDirection);

        Animation();
        Build();
    }

    private void Build()
    {
        if (Input.GetButton("PS4_Square") || Input.GetButton("PS4_Square_P1") || Input.GetButton("PS4_Square_P2") || Input.GetButton("PS4_Square_P3"))      //X BUTTON
        {
            Anim.SetTrigger("Attack");
        }
    }

    private void Animation()
    {
        Anim.SetFloat(MOVEMENTANIM, currentSpeed);
    }


   
}
