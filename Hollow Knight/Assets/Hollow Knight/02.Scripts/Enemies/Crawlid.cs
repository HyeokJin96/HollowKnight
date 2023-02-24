using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawlid : MonoBehaviour
{
    private Rigidbody2D crawlidRigidbody = default;

    private float moveSpeed = default;
    private float crawlidHp = default;

    private bool isLeftWay = false;
    private bool canMove = false;

    #region Start
    private void Start()
    {
        crawlidRigidbody = GetComponent<Rigidbody2D>();

        canMove = true;

        moveSpeed = 2f;
        crawlidHp = 8f;
    }   //  Start()
    #endregion

    #region Update
    private void Update()
    {
        Movement();
        UpdateDirection();
        Die();
    }   //  Update()
    #endregion

    #region UpdateDirection
    private void UpdateDirection()
    {
        if (transform.lossyScale.x == 1)
        {
            isLeftWay = true;
        }
        else if (transform.lossyScale.x == -1)
        {
            isLeftWay = false;
        }
    }   //  UpdateDirection()
    #endregion

    #region Flip
    private void Flip()
    {
        Vector3 vector = transform.localScale;
        vector.x *= (-1);
        transform.localScale = vector;
    }   //  Flip()
    #endregion

    #region Movement
    private void Movement()
    {
        if (canMove == true)
        {
            if (isLeftWay)
            {
                crawlidRigidbody.velocity = Vector2.left * moveSpeed;
            }
            else
            {
                crawlidRigidbody.velocity = Vector2.right * moveSpeed;
            }
        }
        else
        {
            crawlidRigidbody.velocity = Vector2.zero;
        }
    }   //  Movement()
    #endregion

    #region OnTriggerExit2D
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Area"))
        {
            Flip();
        }
    }   //  OnTriggerExit2D()
    #endregion

    #region OnTriggerEnter2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Slash"))
        {
            crawlidHp -= GData.playerSlashDamage;
        }
    }   //  OnTriggerEnter2D()
    #endregion

    #region Die
    private void Die()
    {
        if (crawlidHp <= 0)
        {
            canMove = false;
        }
    }   //  Die()
    #endregion
}
