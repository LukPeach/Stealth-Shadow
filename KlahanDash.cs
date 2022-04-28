using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script dash character.
public class KlahanDash : MonoBehaviour
{
    Rigidbody rigidbody;

    public bool isDashing;
    public bool dashCooldown;

    private int dashAttempts;
    private float dashstartTime;
    public KeyCode dashingKey = KeyCode.E;
    bool isTryingToDash;

    private int coolDownAttempts;
    private float coolDownstartTime;
    [Space]
    public float coolDown;

    [Space]
    public GameObject character;
    public GameObject collider;
    public float inputX;
    public float inputZ;



    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //If the player is zoomed in, it cannot dash.
        if (KlahanAim.aim)
        {
            return;
        }

        HandleDash();
        CoolDowm();
    }

    //The function accepts input from the player and operates the function OnStartDash.
    private void HandleDash()
    {
        isTryingToDash = Input.GetKeyDown(dashingKey);
        if (isTryingToDash && !isDashing && !dashCooldown)
        {
            if(dashAttempts <=2)
            {
                OnStartDash();
            }
        }

        if (isDashing)
        {
            if(Time.time - dashstartTime <= 0.1f)
            {
                
            }
            else
            {
                OnEndDash();
            }
        }
    }

    //The function accepts input from the player and operates the function OnStartCoolDown.
    private void CoolDowm()
    {
        isTryingToDash = Input.GetKeyDown(dashingKey);
        if (isTryingToDash && !dashCooldown)
        {
            if (coolDownAttempts <= 2)
            {
                OnStartCoolDown();
            }
        }

        if (dashCooldown)
        {
            if (Time.time - coolDownstartTime <= coolDown)
            {
                return;
            }
            else
            {
                OnEndCoolDown();
            }
        }
    }

    //Dash variable function.
    private void OnStartDash()
    {
        isDashing = true;
        dashstartTime = Time.time;
        dashAttempts += 1;
    }

    //Dash stop variable function
    private void OnEndDash()
    {
        isDashing = false;
        dashstartTime = 0;
        dashAttempts -= 1;
    }

    //Cooldown variable function.
    private void OnStartCoolDown()
    {
        dashCooldown = true;
        coolDownstartTime = Time.time;
        coolDownAttempts += 1;
    }

    //Cooldown reset variable function
    private void OnEndCoolDown()
    {
        dashCooldown = false;
        coolDownstartTime = 0;
        coolDownAttempts -= 1;
    }
}
