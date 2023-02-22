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
    private GameObject playerSlashEffectDown = default;

    #region Start
    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerAnimation = GetComponent<Animator>();
        playerSlashEffectRight = GameObject.Find("Slash_Right");
        playerSlashEffectLeft = GameObject.Find("Slash_Left");
        playerSlashEffectDown = GameObject.Find("Slash_Down");

        playerSlashEffectRight.SetActive(false);
        playerSlashEffectLeft.SetActive(false);

        GData.playerSpeed = 5.0f;
        GData.playerJumpForce = 15.0f;
        GData.lastAttackTime = 0f;
        GData.attackDelay = 0.1f;
    }   //  Start()
    #endregion

    #region Update
    private void Update()
    {
        KeyControll();
        SpriteFlip();
        GravityScale();
        SlashPositioning();
        AnimationControll();
    }   //  Update()
    #endregion

    #region KeyControll
    private void KeyControll()
    {
        GData.moveInput = Input.GetAxisRaw("Horizontal");

        playerRigidbody.velocity = new Vector2(GData.moveInput * GData.playerSpeed, playerRigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && GData.isGrounded == true)
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, GData.playerJumpForce);
        }

        if (Time.time - GData.lastAttackTime >= GData.attackDelay && GData.isAttacking == true)
        {
            GData.lastAttackTime = Time.time;
            GData.isAttacking = false;
        }

        if (Input.GetKeyDown(KeyCode.X) && Time.time - GData.lastAttackTime >= GData.attackDelay)
        {
            GData.isAttacking = true;
            GData.lastAttackTime = Time.time;
        }
    }   //  KeyControll()
    #endregion

    #region SpriteFlip
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
    #endregion

    #region GravityScale
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
    #endregion

    private void SlashPositioning()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GData.isLeftSlash = false;
            GData.isRightSlash = true;
            GData.isDownSlash = false;
            GData.isUpSlash = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GData.isRightSlash = false;
            GData.isLeftSlash = true;
            GData.isDownSlash = false;
            GData.isUpSlash = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GData.isRightSlash = false;
            GData.isLeftSlash = false;
            GData.isDownSlash = true;
            GData.isUpSlash = false;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            GData.isRightSlash = false;
            GData.isLeftSlash = false;
            GData.isDownSlash = false;
            GData.isUpSlash = true;
        }
    }   //  SlashPosition()

    private void AnimationControll()
    {
        #region AnimationControll_Run
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
        #endregion

        #region AnimationControll_Jump
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
        #endregion

        #region AnimationControll_Attack
        if (GData.isAttacking == true)
        {
            playerAnimation.SetTrigger("Slash");
        }
        if (GData.isAttacking == true && GData.isJumping == true && Input.GetKey(KeyCode.DownArrow))
        {
            playerAnimation.SetTrigger("Slash_Down");
        }
        if (GData.isAttacking == true && GData.isJumping == true && Input.GetKey(KeyCode.UpArrow))
        {
            playerAnimation.SetTrigger("Slash_Up");
        }
        #endregion


        if (GData.isAttacking == true)
        {
            if (GData.isRightSlash == true)
            {
                playerAnimation.SetTrigger("Slash");
            }
            if (GData.isLeftSlash == true)
            {
                playerAnimation.SetTrigger("Slash");
            }
            if (GData.isDownSlash == true)
            {
                playerAnimation.SetTrigger("Slash_Down");
            }
            if (GData.isUpSlash == true)
            {
                playerAnimation.SetTrigger("Slash_Up");
            }

            StartCoroutine("WaitSlashAnimation");
        }
    }   //  SetAnimatorParameters()

    #region OnCollisionStay2D
    private void OnCollisionStay2D(Collision2D collision)
    {
        GData.isGrounded = true;
    }   //  OnCollisionStay2D()
    #endregion

    #region OncollisionExit2D
    private void OnCollisionExit2D(Collision2D collision)
    {
        GData.isGrounded = false;
    }   //  OnCollisionExit2D()
    #endregion

    IEnumerator WaitSlashAnimation()
    {
        if (GData.isAttacking == true && GData.isRightSlash == true)
        {
            yield return new WaitForSeconds(0.1f);
            playerSlashEffectRight.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            playerSlashEffectRight.SetActive(false);
        }
        if (GData.isAttacking == true && GData.isLeftSlash == true)
        {
            yield return new WaitForSeconds(0.1f);
            playerSlashEffectLeft.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            playerSlashEffectLeft.SetActive(false);
        }
        if (GData.isAttacking == true && GData.isDownSlash == true)
        {
            yield return new WaitForSeconds(0.1f);
            playerSlashEffectDown.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            playerSlashEffectDown.SetActive(false);
        }
        if (GData.isAttacking == true && GData.isUpSlash == true)
        {

        }
    }   //  WaitSlashAnimation()
}
