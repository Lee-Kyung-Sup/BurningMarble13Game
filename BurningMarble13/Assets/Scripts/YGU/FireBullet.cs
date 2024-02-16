using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : Bullet
{
    public float splashRange;//스플래시데미지를 줄 범위
    CircleCollider2D circleCD;
    //Rigidbody2D rigidBD;
    //리지드바디는 나중에 리지드바디가 달린애들만 충돌처리를 할수있게 하기위한용도
    List<Monster> monsterslist = new List<Monster>();

    private void Start()
    {
        circleCD = GetComponent<CircleCollider2D>();
        //rigidBD = GetComponent<Rigidbody2D>();
        //스플래시범위값을 서클콜라이더 radius에 넣기
        circleCD.radius = splashRange; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //트리거 안에 충돌체가 들어왔을때~
        Monster monster = collision.GetComponent<Monster>();

        if(monster != null)
        monsterslist.Add(monster);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //트리거 밖으로 충돌체가 나갈때~
        Monster monster = collision.GetComponent<Monster>();

        if (monster != null)
            monsterslist.Remove(monster);
    }

    //적이랑 총알이 충돌했을때 / 충돌한 적 주변으로(충돌한 적주변 인식) / 스플래시 화염데미지(데미지)
    protected override void ApplyDamage()
    {
        // 적 주변으로 스플래시 데미지 적용
        foreach (Monster monster in monsterslist)
        {
            if (monster != null)
            {
                // 여기에서 각 몬스터에게 스플래시 데미지를 적용하는 로직을 작성하세요.
                // 예를 들어, monster.TakeDamage(splashDamage);
                monster.Damage(damage);
                //가짜 데이터
            }
        }

    }
}



