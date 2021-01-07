using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private player_Movement playerMovement;
    private Animator animator;
    public float dashSpeed;
    public float timeOfDash;
    private float dashing = 0;
    private bool buttonPressed;
    private float cooldown = 0;
    public float cooldownTime;

    void Start()
    {
        playerMovement = GetComponent<player_Movement>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Dash") && cooldown == 0)
        {
            buttonPressed = true;
        }
    }

    void FixedUpdate()
    {
        if (buttonPressed)
        {
            animator.SetTrigger("Dash");
            playerMovement.setDashSpeed(dashSpeed);
            cooldown = cooldownTime;
            dashing = timeOfDash;
            buttonPressed = false;
        }

        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            if (cooldown < 0)
            {
                cooldown = 0;
            }
        }

        if (dashing > 0)
        {
            dashing -= Time.deltaTime;
            if (dashing <= 0)
            {
                playerMovement.setDashSpeed(1);
                dashing = 0;
            }
        }
    }
}
