using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script moving character.
public class KlahanMovement : MonoBehaviour
{
    public float speed = 5;

    [Header("Move")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public bool IsDashing { get; private set; }
    public float runSpeed = 5;
    public float dashSpeed = 20;
    public KeyCode runningKey = KeyCode.LeftShift;

    Rigidbody rigidbody;
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    [Space]
    [Header("Animation Control")]
    public Animator klahanAnim;
    public float speedAnim;
    public float InputX;
    public float InputZ;
    public float allowPlayerRotation = 0.1f;

    public Vector3 movementVector = Vector3.zero;
    KlahanDash playerDashing;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        playerDashing = GetComponent<KlahanDash>();
    }
    private void FixedUpdate()
    {
        IsRunning = canRun && Input.GetKey(runningKey) && InputZ == 1 && !KlahanAim.aim;
        IsDashing = playerDashing.isDashing && !KlahanAim.aim;

        //assign values to variables targetMovingSpeed.
        float targetMovingSpeed = IsDashing ? dashSpeed : IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0 && !playerDashing.isDashing)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        //assign values to variables  movementVector.
        movementVector = new Vector2(Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        if(movementVector.x !=0 && movementVector.y !=0)
        {
            movementVector = movementVector / 1.5f;
        }

        //Command the character to move.
        rigidbody.velocity = transform.rotation * new Vector3(movementVector.x, rigidbody.velocity.y, movementVector.y);
    }

    private void Update()
    {
        InputMagnitude();
    }

    //Functions for controlling animation.
    private void InputMagnitude()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        speedAnim = new Vector2(InputX, InputZ).sqrMagnitude;

        if (speedAnim > allowPlayerRotation)
        {
            klahanAnim.SetFloat("Blend", speedAnim);
        }
        else if (speedAnim < allowPlayerRotation)
        {
            klahanAnim.SetFloat("Blend", speedAnim);
        }

        if (IsRunning)
        {
            klahanAnim.SetFloat("Blend", movementVector.y);
        }
        if(IsDashing)
        {

        }
    }
}
