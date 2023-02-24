using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Rigidbody2D fenceRigidbody = default;
    private GameObject falseknight = default;

    private void Start()
    {
        fenceRigidbody = GetComponent<Rigidbody2D>();
        falseknight = GameObject.Find("False Knight");

        fenceRigidbody.gravityScale = 0;
    }

    private void Update()
    {
        FalseKnightAppear();
    }

    private void FalseKnightAppear()
    {
        if (GData.isFalseKnightAppear == true)
        {
            falseknight.SetActive(true);
        }
        else
        {
            falseknight.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GData.isFalseKnightAppear = true;
            fenceRigidbody.gravityScale = 3.0f;
        }
    }
}
