using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruzMother : MonoBehaviour
{
    public float health = 10f;

    [Space]
    public bool isSleep = true;
    public float recoveryDistance = 0f;

    [Space]
    public bool isFlyToRigth = false;

    [Space]
    public Transform playerPos;
    public float moveSpeedX = 1f;
    public float moveSpeedY = 1f;
    public float flyMoveSpeed = 1;

    [Space]
    public float setMoveTime = 3f;
    public float m_moveTime = 3f;

    [Space]
    public float setSkillTime = 5f;
    public float m_skillTime = 1f;
    public bool isTouch = false;
    public bool isLock = false;

    [Space]
    public Sprite fly;
    public Sprite punching;
    public Sprite die;

    [Space]
    public CircleCollider2D circleCollider;
    public BoxCollider2D boxCollider;

    [Space]
    public Animator m_anim;

    // Start is called before the first frame update
    void Start()
    {
        CheckFlightDirection();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            circleCollider.enabled = false;
            boxCollider.enabled = true;
            GetComponentInChildren<SpriteRenderer>().sprite = die;
            GetComponent<Rigidbody2D>().gravityScale = 1f;
            m_anim.SetBool("isDie", true);
            return;
        };

        if (isSleep && Vector2.Distance(playerPos.position, transform.position) < recoveryDistance)
        {
            isSleep = false;
            m_anim.SetBool("isSleep", false);
        }

        if (!isSleep)
        {
            if (isTouch)
            {
                isLock = false;
                isTouch = !isTouch;
                transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));

                m_anim.SetBool("isPunching", false);
                if (m_skillTime < 0)
                {
                    m_skillTime = setSkillTime;
                }
            }
            if (m_skillTime <= 0 && !isTouch)
            {
                if (!isLock)
                {
                    isLock = true;
                    transform.LookAt(playerPos.transform);

                    GetComponentInChildren<SpriteRenderer>().flipX = false;
                    GetComponentInChildren<SpriteRenderer>().sprite = punching;
                }
                m_anim.SetBool("isPunching", true);
                transform.Translate(Vector3.forward * flyMoveSpeed * Time.deltaTime);
            }
            else
            {
                if (GetComponentInChildren<SpriteRenderer>().sprite != fly)
                    GetComponentInChildren<SpriteRenderer>().sprite = fly;

                if (isFlyToRigth)
                {
                    transform.Translate((Vector3.right * moveSpeedX + Vector3.up * moveSpeedY) * Time.deltaTime, Space.World);
                }
                else
                {
                    transform.Translate((Vector3.left * moveSpeedX + Vector3.up * moveSpeedY) * Time.deltaTime, Space.World);
                }
            }

            m_skillTime -= Time.deltaTime;
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            isTouch = true;
            if (health > 0)
                CheckFlightDirection();
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            PlayerController player = other.collider.GetComponent<PlayerController>();
        }
    }


    void CheckFlightDirection()
    {
        isFlyToRigth = transform.position.x < playerPos.position.x ? true : false;
        GetComponentInChildren<SpriteRenderer>().flipX = isFlyToRigth;
    }

    public void hurt(float damage)
    {
        health -= damage;
        m_anim.SetTrigger("isHurt");
    }
}
