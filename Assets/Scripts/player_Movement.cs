using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private float dashSpeed = 1;
    Vector2 movement;
    public Vector2 lastDirection;
    public Animator animator;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(!(movement.Equals(lastDirection)) && !(movement.x == 0 && movement.y == 0) )
        {
            lastDirection = movement;
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.velocity = movement.normalized * moveSpeed * dashSpeed * Time.fixedDeltaTime;
    }

    public void modifyVelocity(float quantity)
    {
        dashSpeed = quantity;
        if (quantity > 1)
        {
            animator.SetTrigger("Dash");
        }
    }
}
