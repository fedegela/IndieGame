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

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<player_Movement>();
        animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Dash"))
        {
            buttonPressed = true;
        }
        if (Input.GetButtonUp("Dash"))
        {
            buttonPressed = false;
        }
        //buttonPressed = Input.GetButtonDown("Dash");
    }

    void FixedUpdate()
    {
        if (buttonPressed && cooldown == 0)
        {
            
            playerMovement.setDashSpeed(dashSpeed);
            animator.SetTrigger("Dash");
            cooldown = cooldownTime;
            dashing = timeOfDash;
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
