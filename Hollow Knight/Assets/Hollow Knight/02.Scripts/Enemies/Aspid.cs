using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aspid : MonoBehaviour
{
    [SerializeField]
    private float radius;

    public LayerMask playerLayer;
    public LayerMask obstaclesLayer;

    public float speed;

    private Rigidbody2D rb;
    private Collider2D playerCd;

    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(PlayerTrace());

        if (speed == 0f)
        {
            speed = 1f;
        }

    }

    IEnumerator PlayerTrace()
    {
        while (true)
        {
            if (Physics2D.OverlapCircle(transform.position, radius, playerLayer))
            {
                PlayerDirCheckTargetting();
            }
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void PlayerDirCheckTargetting()
    {
        Collider2D[] hitTargetCollider2DInfo =
            Physics2D.OverlapCircleAll(transform.position, radius, playerLayer);

        foreach (Collider2D targetInfo in hitTargetCollider2DInfo)
        {
            Vector2 dir_ = (targetInfo.transform.position - transform.position);

            float distance_ = (transform.position - targetInfo.transform.position).magnitude;

            RaycastHit2D hitData = Physics2D.Raycast(transform.position, dir_, radius, playerLayer + obstaclesLayer);

            if (hitData == false)
            {

            }
            else if (hitData.collider.Equals(targetInfo))
            {
                rb.velocity = dir_.normalized * speed;
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
        }
    }
}
