using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FalseKnight : MonoBehaviour
{
    private Rigidbody2D falseknightRigidbody = default;

    private float chargeSpeed = default;


    private bool isCharging = false;

    private void Start()
    {
        falseknightRigidbody = GetComponent<Rigidbody2D>();

        chargeSpeed = 10f;

    }   //  Start()

    private void Update()
    {

        Charge();
    }   //  Update()

    private void Flip()
    {
        Vector3 vector = transform.localScale;
        vector.x *= (-1);
        transform.localScale = vector;
    }

    private void Idle()
    {

    }   //  Idle()

    private Vector2 PlayerDirection()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // �±װ� Player�� ������Ʈ �˻�
        Vector2 direction = player.transform.position - transform.position; // �÷��̾�� �ڽ��� ��ġ ���� ���
        direction.Normalize(); // ���� ���� ����ȭ
        return direction;
    }


    #region Charge
    private void Charge()
    {
        //  ���� : �÷��̾ �ʹ� �ָ� ������ ��� �ٰ����� ���� ������ �ϱ⵵ ��
        //  ���� ���� �� ��� ������ ��

        if (isCharging == true)
        {
            falseknightRigidbody.velocity = Vector2.right * chargeSpeed;
        }

    }   //  Charge()
    #endregion

    #region Leap
    private void Leap()
    {
        //  ���� : False Knight�� ���߿��� �ָ� �����Ͽ� ���� ������ �غ��ϰų� ���ġ�մϴ�.
        //  �� �� �������� �������� ����
        //  ���� �Ǵ� �������� ������
        //  3�ܰ迡���� �� ����� ������� ����
    }   //  Leap()
    #endregion

    #region LeapingBludgeon
    private void LeapingBludgeon()
    {
        //  ���� ���� : ������ ��簡 ������ �����ϸ鼭 ��������ϴ�.
        //  ������ ��簡 ������ �������� �� �־��� ���� ������
        //  3�ܰ迡���� ���� ����߸��⵵ ��
    }   //  LeapingBludgeon()
    #endregion

    #region Slam
    private void Slam()
    {
        //  ��Ÿ : ������ ��簡 �ڷ� ������ ö�� ��� �غ��� ���� ������ ö�� �ֵѷ� ���� ����ħ
        //  ö���� ����� ���濡 ����ĸ� ������ 
        //  2�ܰ迡���� �� �������� ���� ��������, 3�ܰ迡���� �� ���� ���� ������
    }   //  Slam()
    #endregion

    #region Range
    private void Range()
    {
        //  �г� : ���ʿ� ����� ���ظ� ���� �� ������ ���� ��Ʋ�Ÿ��� �������� ���� ���� �����Ⱑ ����
        //  �����Ⱑ ����� ���ظ� ������ �ٽ� �� ������ ������
        //  ������ �߾����� �پ���� �� ö�� �� ��� ������ ����ħ
        //  ö�� ���� ���� ������ ���� õ�忡�� ������
        //  �� 3�� ���� ö�� ����ħ
        //  �����⸦ �ʹ� �����ð� ��ġ�ϸ� �ٽ� �Ͼ �г���¿� ������ �ʰ� �Ϲ� ������ �����
    }   //  Range()
    #endregion

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isCharging = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isCharging = true;
        }
    }
}





    //public float chargeSpeed = 10f; // ���� �ӵ�
    //public float chargeDuration = 1.5f; // ���� ���� �ð�
    //public float idleDuration = 1f; // ��� �ð�
    //public float swingDelay = 0.2f; // �ֵθ��� ������
    //public float swingRange = 1.5f; // �ֵθ��� ����
    //public int swingDamage = 10; // �ֵθ��� ���ݷ�

    //private bool isCharging; // ���� ������ ����
    //private bool isSwinging; // �ֵθ��� ������ ����
    //private float chargeTimer; // ���� Ÿ�̸�
    //private float idleTimer; // ��� Ÿ�̸�
    //private float swingTimer; // �ֵθ��� Ÿ�̸�
    //private Vector2 chargeDirection; // ���� ����
    //private Animator anim; // �ִϸ�����
    //private Rigidbody2D rb; // ������ٵ�

    //private void Start()
    //{
    //    anim = GetComponent<Animator>(); // �ִϸ����� ������Ʈ ��������
    //    rb = GetComponent<Rigidbody2D>(); // ������ٵ� ������Ʈ ��������

    //    isCharging = false;
    //    isSwinging = false;
    //    chargeTimer = chargeDuration;
    //    idleTimer = idleDuration;
    //    swingTimer = 0f;
    //}

    //private void Update()
    //{
    //    if (isCharging)
    //    {
    //        Charge();
    //    }
    //    else if (isSwinging)
    //    {
    //        Swing();
    //    }
    //    else
    //    {
    //        Idle();
    //    }
    //}

    //private void Charge()
    //{
    //    rb.velocity = chargeDirection * chargeSpeed; // ���� �������� �̵�

    //    chargeTimer -= Time.deltaTime;
    //    if (chargeTimer <= 0f) // ���� ����
    //    {
    //        rb.velocity = Vector2.zero;
    //        isCharging = false;
    //        isSwinging = true;
    //        swingTimer = swingDelay;
    //        anim.SetTrigger("swing"); // swing �ִϸ��̼� ���
    //    }
    //}

    //private void Swing()
    //{
    //    swingTimer -= Time.deltaTime;
    //    if (swingTimer <= 0f) // �ֵθ��� ����
    //    {
    //        isSwinging = false;
    //        idleTimer = idleDuration;
    //    }
    //    else // �ֵθ��� ��
    //    {
    //        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, swingRange, LayerMask.GetMask("Player")); // �÷��̾� �˻�

    //        foreach (Collider2D enemy in hitEnemies)
    //        {
    //            enemy.GetComponent<PlayerHealth>().TakeDamage(swingDamage); // �÷��̾��� ü���� ���ҽ�Ű�� �Լ� ȣ��
    //        }
    //    }
    //}

    //private void Idle()


    //private void Idle()
    //{
    //    idleTimer -= Time.deltaTime;
    //    if (idleTimer <= 0f) // ��� ����
    //    {
    //        isCharging = true;
    //        chargeTimer = chargeDuration;
    //        chargeDirection = PlayerDirection(); // �÷��̾ ���ϴ� �������� ����
    //        anim.SetTrigger("charge"); // charge �ִϸ��̼� ���
    //    }
    //}

    //private Vector2 PlayerDirection()
    //{
    //    GameObject player = GameObject.FindGameObjectWithTag("Player"); // �±װ� Player�� ������Ʈ �˻�
    //    Vector2 direction = player.transform.position - transform.position; // �÷��̾�� �ڽ��� ��ġ ���� ���
    //    direction.Normalize(); // ���� ���� ����ȭ
    //    return direction;
    //}

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, swingRange); // �ֵθ��� ������ �ð������� ��Ÿ��
    //}
