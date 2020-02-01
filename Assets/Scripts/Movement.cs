﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public static string moveForward = "MoveForward_P";
    public static string moveRight = "MoveRight_P";

    // Start is called before the first frame update
    CharacterController characterController;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    //public Rigidbody moverthing;
    private Vector3 moveDirection = Vector3.zero;

    private string moveForwardAxis;
    private string moveRightAxis;

    [Range(1,4)]
    public int playerNum = 2;
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        moveForwardAxis = moveForward + playerNum;
        moveRightAxis = moveRight + playerNum;
    }

    
    // Update is called once per frame
    void Update()
    {
        float moveForward = Input.GetAxis(moveForwardAxis);
        float moveRight = Input.GetAxis(moveRightAxis);

        if (moveForward == 0 && moveRight == 0)
            return;

        moveDirection = new Vector3(moveRight, 0.0f, moveForward);
        Debug.Log(gameObject.name + " moveForwardAxis: " + moveForwardAxis);
        moveDirection *= speed;
        characterController.Move(moveDirection * Time.deltaTime);
    }
}