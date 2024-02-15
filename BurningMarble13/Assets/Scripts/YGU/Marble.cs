using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public enum BulletType { Fire, Electricity, Wind, Poison, Ice, Iron, Stone, Bow, Laser, Light };

public class Marble : MonoBehaviour
{
    //Fire,Electricity,Wind,Poison,Ice,Iron,Stone,Bow,Laser,Light
    //Fire>몬스터 공격시 타켓 주변에 스플래시 화염데미지
    //Electricity>몬스터 공격시 타겟을 포함한 3개의 몬스터에게각각 전기데미지
    //Wind>몬스터를 빠른속도로 공격
    //Poison>몬스터 공격시 독디버프 초당 독 데미지
    //Ice>몬스터 공격시 얼음디버프를 남겨 이동속도 감소 최대3회 중첩(이동속도 최50퍼 감속)
    //Iron>보스공격시 2배 데미지
    //Stone>15초마다 경로끝에서 시작점까지 이동하는 돌소환(일덩확률로 1초간 기절)x
    //Bow>5회 공격 시마다 업그레이드 수 만큼 무작위 타겟에게 화살발사
    //Laser>10회 공격할때마다 일직선 범위의 적을 레이저로 공격
    //Light>범위만큼 공격속도 증가 버프
    //공격,죽이기..?
    //공통:공격력(기본)>바람,돌,활,레이저,빛/공격속도:불,전기,독,얼음,쇠,돌,활,레이저,빛
    public BulletType bulletType;
    public int attackDamage = 20;
    public float attackSpeed = 1.5f;
    //몇초당 날아갈지(쿨타임)
    public float attackRange;

    float totalTime = 0;
    public GameObject bulletprefeb;

    public Transform testMonster;
    //테스터몬스터

    CircleCollider2D circleCD;
    //Rigidbody2D rigidBD;
    List<Monster> monsterslist = new List<Monster>();

    void Attack()
    {
        //투사체가 생성되고(날라감)
        GameObject go = Instantiate(bulletprefeb);
        //내 위치로 투사체를 가져온다
        go.transform.position = transform.position;
        //Debug.Log("attack");
        Bullet bullet = go.GetComponent<Bullet>();
        bullet.Initialize(testMonster);
    }

    void Update()
    {
        //총알 날라가는 범위
        if(testMonster == null)
        {
            return;
        }
        if (Vector3.Distance(transform.position, testMonster.transform.position) > attackRange)
        {
            return;
        }
        //테스트 몬스터기준

        totalTime += Time.deltaTime;

        if (totalTime >= attackSpeed)
        {
            Attack();
            totalTime = 0;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //트리거 안에 충돌체가 들어왔을때~
        Monster monster = collision.GetComponent<Monster>();

        if (monster != null)
            monsterslist.Add(monster);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //트리거 밖으로 충돌체가 나갈때~
        Monster monster = collision.GetComponent<Monster>();

        if (monster != null)
            monsterslist.Remove(monster);
    }

}
