using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidbody = default;
    private SpriteRenderer spriteRenderer = default;

    private float playerSpeed = 5.0f;
    private float playerJumpForce = 300.0f;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");

        playerRigidbody.velocity = new Vector2(x * playerSpeed, playerRigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerRigidbody.velocity.y == 0)
            {
                playerRigidbody.AddForce(new Vector2(0, playerJumpForce));
            }
        }

    }
}
