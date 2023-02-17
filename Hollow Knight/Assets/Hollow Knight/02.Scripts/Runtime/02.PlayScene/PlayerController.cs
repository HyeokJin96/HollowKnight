using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidbody = default;
    private SpriteRenderer spriteRenderer = default;
    private Animator playerAnimation = default;
    private GameObject playerSlashEffectRight = default;
    private GameObject playerSlashEffectLeft = default;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerAnimation = GetComponent<Animator>();
        playerSlashEffectRight = GameObject.Find("Slash_Right");
        playerSlashEffectLeft = GameObject.Find("Slash_Left");

        playerSlashEffectRight.SetActive(false);
        playerSlashEffectLeft.SetActive(false);

        GData.playerSpeed = 5.0f;
        GData.playerJumpForce = 15.0f;
    }

    private void Update()
    {
        KeyControll();
        SpriteFlip();
        GravityScale();
        SlashPosition();

        SetAnimatorParameters();

        Debug.Log($"isRightSlash : {GData.isRightSlash}");
        Debug.Log($"isLeftSlash : {GData.isLeftSlash}");


    }   //  Update()

    private void KeyControll()
    {
        float x = Input.GetAxisRaw("Horizontal");

        playerRigidbody.velocity = new Vector2(x * GData.playerSpeed, playerRigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && GData.isGrounded == true)
        {
            playerRigidbody.AddForce(Vector2.up * GData.playerJumpForce, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            GData.isAttacking = true;
            playerAnimation.SetTrigger("Slash");
        }
        else
        {
            GData.isAttacking = false;
            playerAnimation.SetBool("Slash", GData.isAttacking);
        }
    }   //  KeyControll()

    private void SpriteFlip()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = true;
        }
    }   //  SpriteFlip()

    private void GravityScale()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GData.isGrounded == true)
        {
            playerRigidbody.gravityScale = 3.0f;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerRigidbody.gravityScale = 8.0f;
        }
    }   //  GravityScale()

    private void SlashPosition()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GData.isLeftSlash = false;
            GData.isRightSlash = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GData.isRightSlash = false;
            GData.isLeftSlash = true;
        }
    }   //  SlashPosition()

    private void SetAnimatorParameters()
    {
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)) && GData.isGrounded == true)
        {
            GData.isRunning = true;
            playerAnimation.SetBool("Run", GData.isRunning);
        }
        else
        {
            GData.isRunning = false;
            playerAnimation.SetBool("Run", GData.isRunning);
        }

        if (Input.GetKey(KeyCode.Space) && GData.isGrounded == false)
        {
            GData.isJumping = true;
            playerAnimation.SetBool("Jump", GData.isJumping);
        }
        else
        {
            if (GData.isGrounded == true)
            {
                GData.isJumping = false;
                playerAnimation.SetBool("Jump", GData.isJumping);
            }
        }

        if (GData.isAttacking == true)
        {
            if (GData.isRightSlash == true)
            {
                playerAnimation.SetTrigger("Slash_Right");
            }
            if (GData.isLeftSlash == true)
            {
                playerAnimation.SetTrigger("Slash_Left");
            }

            StartCoroutine("WaitSlashAnimation");
        }
        else
        {
            if (GData.isRightSlash == true)
            {
                playerAnimation.ResetTrigger("Slash_Right");
            }
            if (GData.isLeftSlash == true)
            {
                playerAnimation.ResetTrigger("Slash_Left");
            }
        }

    }   //  SetAnimatorParameters()

    private void OnCollisionStay2D(Collision2D collision)
    {
        GData.isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GData.isGrounded = false;
    }

    IEnumerator WaitSlashAnimation()
    {
        if (GData.isRightSlash == true)
        {
            yield return new WaitForSeconds(0.1f);
            playerSlashEffectRight.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            playerSlashEffectRight.SetActive(false);
        }
        if (GData.isLeftSlash == true)
        {
            yield return new WaitForSeconds(0.1f);
            playerSlashEffectLeft.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            playerSlashEffectLeft.SetActive(false);
        }
    }   //  WaitSlashAnimation()
}
