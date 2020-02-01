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
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera camera;
    //public Rigidbody moverthing;
    private Vector3 moveDirection = Vector3.zero;

    private string moveForwardAxis;
    private string moveRightAxis;

    [Range(1,4)]
    public int playerNum = 2;
    void Start()
    {
        camera = camera ?? Camera.main;

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

        moveDirection = new Vector3(moveRight, 0.0f, -1 * moveForward);
        moveDirection *= speed;
        characterController.Move(moveDirection * Time.deltaTime);
        addedMove = new Vector3(0, 0, 90);
        transform.rotation = Quaternion.LookRotation(moveDirection);
    }
}
