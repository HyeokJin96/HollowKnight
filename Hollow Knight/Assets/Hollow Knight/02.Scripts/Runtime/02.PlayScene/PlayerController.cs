using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidbody = default;
    private SpriteRenderer spriteRenderer = default;
    private Animator playerAnimation = default;

    private float playerSpeed = default;
    private float playerJumpForce = default;

    private bool isGrounded = false;
    private bool isRunning = false;
    private bool isJumpping = false;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerAnimation = GetComponent<Animator>();

        playerSpeed = 5.0f;
        playerJumpForce = 15.0f;
    }

    private void Update()
    {
        KeyControll();
        SpriteFlip();
        GravityScale();

        SetAnimatorParameters();




    }   //  Update()

    private void KeyControll()
    {
        float x = Input.GetAxisRaw("Horizontal");

        playerRigidbody.velocity = new Vector2(x * playerSpeed, playerRigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            playerRigidbody.AddForce(Vector2.up * playerJumpForce, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {

        }
    }   //  KeyControll()

    private void SpriteFlip()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = false;
        }
    }   //  SpriteFlip()

    private void GravityScale()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            playerRigidbody.gravityScale = 3.0f;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerRigidbody.gravityScale = 8.0f;
        }
    }   //  GravityScale()

    private void SetAnimatorParameters()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            isRunning = true;
            playerAnimation.SetBool("Run", isRunning);
        }
        else
        {
            isRunning = false;
            playerAnimation.SetBool("Run", isRunning);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isJumpping = true;
            playerAnimation.SetBool("Jump", isJumpping);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumpping = false;
            playerAnimation.SetBool("Jump", isJumpping);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            playerAnimation.SetTrigger("Slash");
        }
    }   //  SetAnimatorParameters()

    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
