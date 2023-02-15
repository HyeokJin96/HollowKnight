using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidbody = default;
    private SpriteRenderer spriteRenderer = default;
    private Animator playerAnimation = default;

    private float playerSpeed = 5.0f;
    private float playerJumpForce = 15.0f;

    private bool isGrounded = false;
    private bool isJumping = false;
    private bool isRunning = false;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerAnimation = GetComponent<Animator>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");

        playerRigidbody.velocity = new Vector2(x * playerSpeed, playerRigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            isRunning = true;
            spriteRenderer.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isRunning = true;
            spriteRenderer.flipX = false;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            isRunning = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            playerRigidbody.gravityScale = 3.0f;
            playerRigidbody.AddForce(Vector2.up * playerJumpForce, ForceMode2D.Impulse);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {

            playerRigidbody.gravityScale = 8.0f;
        }

            playerAnimation.SetBool("isJumping", isJumping);
            playerAnimation.SetBool("isRunning", isRunning);
    }   //  Update()

    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
        isJumping = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        isJumping = true;
    }
}
