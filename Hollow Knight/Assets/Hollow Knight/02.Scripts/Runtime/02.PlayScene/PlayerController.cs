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
        GData.lastAttackTime = 0f;
        GData.attackDelay = 0.1f;
    }

    private void Update()
    {
        KeyControll();
        SpriteFlip();
        GravityScale();
        SlashPositioning();

        SetAnimatorParameters();

        if (GData.isAttacking == true)
        {
        Debug.Log($"isAttack : {GData.isAttacking}");

        }

    }   //  Update()

    private void KeyControll()
    {
        GData.moveInput = Input.GetAxisRaw("Horizontal");

        playerRigidbody.velocity = new Vector2(GData.moveInput * GData.playerSpeed, playerRigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && GData.isGrounded == true)
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, GData.playerJumpForce);
        }

        AttackDelay();

        if (Input.GetKeyDown(KeyCode.X) && Time.time - GData.lastAttackTime >= GData.attackDelay)
        {
            GData.isAttacking = true;
            GData.lastAttackTime = Time.time;
        }
    }   //  KeyControll()

    private void AttackDelay()
    {
        if (Time.time - GData.lastAttackTime >= GData.attackDelay && GData.isAttacking == true)
        {
            GData.lastAttackTime = Time.time;
            GData.isAttacking = false;
        }
    }

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
            playerRigidbody.gravityScale = 10.0f;
        }
    }   //  GravityScale()

    private void SlashPositioning()
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

        if (Input.GetKeyDown(KeyCode.X))
        {
            playerAnimation.SetTrigger("Slash");
        }
        else
        {
            playerAnimation.SetBool("Slash", GData.isAttacking);
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
    }   //  OnCollisionStay2D()

    private void OnCollisionExit2D(Collision2D collision)
    {
        GData.isGrounded = false;
    }   //  OnCollisionExit2D()

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
