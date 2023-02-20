using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //[SerializeField] private Animator animator;
    private Player player;
    public float walkSpeed = 5f;
    public float runSpeed = 7f;
    private float moveSpeed;
    private bool isRunning = false;

    private Rigidbody2D rb;
    public Vector2 movement;
    private bool facingRight;

    private void Awake()
    {
        //animator = GetComponent<Animator>();
        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = walkSpeed;
    }
    void Update()
    {
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");
        movement = new Vector2(X, Y).normalized;

        //if (movement.x == 0 && movement.y == 0)
        //    animator.SetBool("isWalk", false);
        //else
        //    animator.SetBool("isWalk", true);

        if (Input.GetKeyDown(KeyCode.LeftShift))
            SetRunning(true);
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            SetRunning(false);

        if (isRunning)
        {
            player.stamina -= Time.deltaTime * 4;
            if (player.stamina < 0)
            {
                player.stamina = 0;
                SetRunning(false);
            }
        }
        else if (player.stamina < player.maxStamina)
            player.stamina += Time.deltaTime * 2;

        if(!facingRight && movement.x < 0)
            Flip();
        else if(facingRight && movement.x > 0)
            Flip();

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void SetRunning(bool isRunning)
    {
        this.isRunning = isRunning;
        moveSpeed = isRunning ? runSpeed : walkSpeed;
    }
}
