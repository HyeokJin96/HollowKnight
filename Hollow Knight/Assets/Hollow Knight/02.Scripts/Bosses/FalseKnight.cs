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
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // 태그가 Player인 오브젝트 검색
        Vector2 direction = player.transform.position - transform.position; // 플레이어와 자신의 위치 차이 계산
        direction.Normalize(); // 방향 벡터 정규화
        return direction;
    }


    #region Charge
    private void Charge()
    {
        //  돌진 : 플레이어가 너무 멀리 떨어진 경우 다가가기 위해 돌진을 하기도 함
        //  돌진 종료 시 곤봉 공격을 함

        if (isCharging == true)
        {
            falseknightRigidbody.velocity = Vector2.right * chargeSpeed;
        }

    }   //  Charge()
    #endregion

    #region Leap
    private void Leap()
    {
        //  도약 : False Knight는 공중에서 멀리 점프하여 슬램 공격을 준비하거나 재배치합니다.
        //  두 번 연속으로 도약하지 않음
        //  앞쪽 또는 뒤쪽으로 도약함
        //  3단계에서는 이 기술을 사용하지 않음
    }   //  Leap()
    #endregion

    #region LeapingBludgeon
    private void LeapingBludgeon()
    {
        //  리핑 블러전 : 거짓된 기사가 앞으로 점프하면서 내려찍습니다.
        //  거짓된 기사가 도약을 시작했을 때 있었던 곳을 공격함
        //  3단계에서는 통을 떨어뜨리기도 함
    }   //  LeapingBludgeon()
    #endregion

    #region Slam
    private void Slam()
    {
        //  강타 : 거짓된 기사가 뒤로 물러나 철퇴를 잠시 준비한 다음 앞으로 철퇴를 휘둘러 땅에 내려침
        //  철퇴의 충격은 전방에 충격파를 생성함 
        //  2단계에서는 이 공격으로 통이 떨어지며, 3단계에서는 더 많은 통이 떨어짐
    }   //  Slam()
    #endregion

    #region Range
    private void Range()
    {
        //  분노 : 갑옷에 충분한 피해를 입힌 후 거짓된 기사는 비틀거리며 쓰러지고 갑옷 안의 구더기가 나옴
        //  구더기가 충분한 피해를 입으면 다시 들어가 공격을 시작함
        //  투기장 중앙으로 뛰어오른 후 철퇴를 좌 우로 여러번 내려침
        //  철퇴가 땅에 닿을 때마다 통이 천장에서 떨어짐
        //  약 3초 동안 철퇴를 내려침
        //  구더기를 너무 오랜시간 방치하면 다시 일어나 분노상태에 빠지지 않고 일반 공격을 계속함
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





    //public float chargeSpeed = 10f; // 돌진 속도
    //public float chargeDuration = 1.5f; // 돌진 지속 시간
    //public float idleDuration = 1f; // 대기 시간
    //public float swingDelay = 0.2f; // 휘두르기 딜레이
    //public float swingRange = 1.5f; // 휘두르기 범위
    //public int swingDamage = 10; // 휘두르기 공격력

    //private bool isCharging; // 돌진 중인지 여부
    //private bool isSwinging; // 휘두르기 중인지 여부
    //private float chargeTimer; // 돌진 타이머
    //private float idleTimer; // 대기 타이머
    //private float swingTimer; // 휘두르기 타이머
    //private Vector2 chargeDirection; // 돌진 방향
    //private Animator anim; // 애니메이터
    //private Rigidbody2D rb; // 리지드바디

    //private void Start()
    //{
    //    anim = GetComponent<Animator>(); // 애니메이터 컴포넌트 가져오기
    //    rb = GetComponent<Rigidbody2D>(); // 리지드바디 컴포넌트 가져오기

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
    //    rb.velocity = chargeDirection * chargeSpeed; // 돌진 방향으로 이동

    //    chargeTimer -= Time.deltaTime;
    //    if (chargeTimer <= 0f) // 돌진 종료
    //    {
    //        rb.velocity = Vector2.zero;
    //        isCharging = false;
    //        isSwinging = true;
    //        swingTimer = swingDelay;
    //        anim.SetTrigger("swing"); // swing 애니메이션 재생
    //    }
    //}

    //private void Swing()
    //{
    //    swingTimer -= Time.deltaTime;
    //    if (swingTimer <= 0f) // 휘두르기 종료
    //    {
    //        isSwinging = false;
    //        idleTimer = idleDuration;
    //    }
    //    else // 휘두르기 중
    //    {
    //        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, swingRange, LayerMask.GetMask("Player")); // 플레이어 검색

    //        foreach (Collider2D enemy in hitEnemies)
    //        {
    //            enemy.GetComponent<PlayerHealth>().TakeDamage(swingDamage); // 플레이어의 체력을 감소시키는 함수 호출
    //        }
    //    }
    //}

    //private void Idle()


    //private void Idle()
    //{
    //    idleTimer -= Time.deltaTime;
    //    if (idleTimer <= 0f) // 대기 종료
    //    {
    //        isCharging = true;
    //        chargeTimer = chargeDuration;
    //        chargeDirection = PlayerDirection(); // 플레이어를 향하는 방향으로 돌진
    //        anim.SetTrigger("charge"); // charge 애니메이션 재생
    //    }
    //}

    //private Vector2 PlayerDirection()
    //{
    //    GameObject player = GameObject.FindGameObjectWithTag("Player"); // 태그가 Player인 오브젝트 검색
    //    Vector2 direction = player.transform.position - transform.position; // 플레이어와 자신의 위치 차이 계산
    //    direction.Normalize(); // 방향 벡터 정규화
    //    return direction;
    //}

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, swingRange); // 휘두르기 범위를 시각적으로 나타냄
    //}
