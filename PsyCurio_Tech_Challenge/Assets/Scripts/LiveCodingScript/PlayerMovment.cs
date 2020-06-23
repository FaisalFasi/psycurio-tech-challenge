using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enums
public enum PlayerState
{
    idle,
    moveForward,
    moveBackward,
    moveLeft,
    moveRight
}
public class PlayerMovment : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed = 5.0f;
    bool isLeft = false;
    bool isRight = false;
    bool isForward = false;
    bool isBackward = false;

    public PlayerState _curState;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _curState = PlayerState.idle;

    }

    void Update()
    {
        // checking in which state the player is i.e idle,forward etc 
        if (_curState == PlayerState.idle)
            Idle();
        if (_curState == PlayerState.moveForward)
            MoveForward();
        if (_curState == PlayerState.moveBackward)
            MoveBackward();
        if (_curState == PlayerState.moveLeft)
            MoveLeft();
        if (_curState == PlayerState.moveRight)
            MoveRight();

         
    }
    // moving forward
    void MoveForward() 
    {
        rb.velocity = Vector3.forward * moveSpeed;

        if (isBackward || Input.GetKey(KeyCode.S))
            _curState = PlayerState.moveBackward;
        if (isLeft || Input.GetKey(KeyCode.A))
            _curState = PlayerState.moveLeft;
        if (isRight || Input.GetKey(KeyCode.D))
            _curState = PlayerState.moveRight;
        if (!Input.anyKeyDown)
            _curState = PlayerState.idle;
    }
    // moving backward 
    void MoveBackward()
    {
        rb.velocity = Vector3.back * moveSpeed;

        if (isForward || Input.GetKey(KeyCode.W))
            _curState = PlayerState.moveForward;
        if (isLeft || Input.GetKey(KeyCode.A))
            _curState = PlayerState.moveLeft;
        if (isRight || Input.GetKey(KeyCode.D))
            _curState = PlayerState.moveRight;
        if (!Input.anyKeyDown)
            _curState = PlayerState.idle;
    }
    // moving left
    void MoveLeft()
    {
        rb.velocity = Vector3.left * moveSpeed;
        if (isForward || Input.GetKey(KeyCode.W))
            _curState = PlayerState.moveForward;
        if (isBackward || Input.GetKey(KeyCode.S))
            _curState = PlayerState.moveBackward;
        if (isRight || Input.GetKey(KeyCode.D))
            _curState = PlayerState.moveRight;
        if (!Input.anyKeyDown)
            _curState = PlayerState.idle;
    }
    // moving right
    void MoveRight()
    {
        rb.velocity = Vector3.right * moveSpeed;
        if (isForward || Input.GetKey(KeyCode.W))
            _curState = PlayerState.moveForward;
        if (isBackward || Input.GetKey(KeyCode.S))
            _curState = PlayerState.moveBackward;
        if (isLeft || Input.GetKey(KeyCode.A))
            _curState = PlayerState.moveLeft;
        if (!Input.anyKeyDown)
            _curState = PlayerState.idle;
    }
    // idle 
    void Idle() 
    {
        if (isForward || Input.GetKey(KeyCode.W))
            _curState = PlayerState.moveForward;
        if (isBackward || Input.GetKey(KeyCode.S))
            _curState = PlayerState.moveBackward;
        if (isLeft || Input.GetKey(KeyCode.A))
            _curState = PlayerState.moveLeft;
        if (isRight || Input.GetKey(KeyCode.D))
            _curState = PlayerState.moveRight;
    }

    // i make these custom trigger events
    // checking which button is pressed in the game i.e left,right, forward etc
    // we can also use joystick instead of buttons to move player 
    public void IsMovingLeft() 
    {
        isLeft = true;
    }
    public void IsNotMovingLeft()
    {
        isLeft = false;
    }
    public void IsMovingRight()
    {
        isRight = true;
    }
    public void IsNotMovingRight()
    {
        isRight = false;
    }
    public void IsMovingForward()
    {
        isForward = true;
    }
    public void IsNotMovingForward()
    {
        isForward = false;
    }
    public void IsMovingBackward()
    {
        isBackward = true;
    }
    public void IsNotMovingBackward()
    {
        isBackward = false;
    }
}
