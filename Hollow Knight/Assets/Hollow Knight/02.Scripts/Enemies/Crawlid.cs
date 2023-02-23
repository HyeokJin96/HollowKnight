using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawlid : MonoBehaviour
{
    private Rigidbody2D crawlidRigidbody = default;

    private float moveSpeed = default;
    private float jumpForce = default;
    private float crawlidHp = default;

    private bool isLeftWay = false;
    private bool canMove = false;
    private bool isHitted = false;
    private bool isDead = false;



    private void Start()
    {
        crawlidRigidbody = GetComponent<Rigidbody2D>();

        canMove = true;

        moveSpeed = 2f;
        jumpForce = 2f;
        crawlidHp = 8f;
    }

    private void Update()
    {
        Debug.Log($"crawlidHp : {crawlidHp}");

        Movement();
        UpdateDirection();
        Die();
    }

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
    }

    private void Flip()
    {
        Vector3 vector = transform.localScale;
        vector.x *= (-1);
        transform.localScale = vector;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Area")
        {
            Flip();
        }
    }

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
    }

    private void Die()
    {
        if (crawlidHp <= 0)
        {
            isDead = true;
            canMove = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Slash")
        {
            isHitted = true;

            crawlidHp -= GData.playerSlashDamage;
        }
    }

    private void Hitted()
    {
        if (isHitted == true)
        {
            //crawlidRigidbody.velocity = new Vector2(0f, jumpForce);
        }
    }
}
