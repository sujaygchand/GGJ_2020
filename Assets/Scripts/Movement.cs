using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public static string moveForward = "MoveForward_P";
    public static string moveRight = "MoveRight_P";
    private Vector3 addedMove = new Vector3(0, 90, 0);
    // Start is called before the first frame update
    CharacterController characterController;
    public float initialSpeed = 6.0f;
    private float currentSpeed;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera camera;
    //public Rigidbody moverthing;
    private Vector3 moveDirection = Vector3.zero;

    private string moveForwardAxis;
    private string moveRightAxis;

    public const string MOVEMENTANIM = "Movement";
    public Animator Anim;
    [Range(1,4)]
    public int playerNum;
    public bool isGameOver = false;

    bool Controller;
    void Start()
    {
        isGameOver = false;
        camera = camera ?? Camera.main;

        characterController = GetComponent<CharacterController>();

        moveForwardAxis = moveForward + playerNum;
        moveRightAxis = moveRight + playerNum;

        Anim = this.GetComponent<Animator>();



      
      /*
        if (playerNum == 3)
        {
            Controller = Input.GetButton(RuinScript.PSP3);

        }
        if (playerNum == 4)
        {
            Controller = Input.GetButton(RuinScript.PSP4);
        }*/
    }

    
    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
            return;

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
        if (playerNum == 1)
        {
            if (Input.GetButton(RuinScript.PSP1))      //X BUTTON
            {
                Anim.SetTrigger("Attack");
                return;
            }
        }

        if (playerNum == 2)
        {
            if (Input.GetButton(RuinScript.PSP2))      //X BUTTON
            {
                Anim.SetTrigger("Attack");
                return;
            }
        }

        if (playerNum == 3)
        {
            if (Input.GetButton(RuinScript.PSP3))      //X BUTTON
            {
                Anim.SetTrigger("Attack");
                return;
            }
        }
        if (playerNum == 4)
        {
            if (Input.GetButton(RuinScript.PSP4))      //X BUTTON
            {
                Anim.SetTrigger("Attack");
                return;
            }
        }
    }

    private void Animation()
    {
        Anim.SetFloat(MOVEMENTANIM, currentSpeed);
    }


   
}
