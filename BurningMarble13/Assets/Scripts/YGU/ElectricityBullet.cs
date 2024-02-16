using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricityBullet : Bullet
{
    public int count = 3;
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

    protected override void ApplyDamage()
    {
        base.ApplyDamage();
        count -= 1;
        if(count == 0)
        {
            return;
        }
        IgnoreMonster(monster);
        Monster _monster = FindNearMonster();
        if(_monster == null)
        {
            return;
        }
        ElectricityBullet electricity = Instantiate(this.gameObject).GetComponent<ElectricityBullet>();
        electricity.Initialize(_monster, damage);
    }

    public void IgnoreMonster(Monster monster)
    {
        monsterslist.Remove(monster);
    }

    Monster FindNearMonster()
    {

        if (monsterslist.Count == 0)
            return null;
        if (monsterslist.Count == 1)
            return monsterslist[0];

        Monster nearestMonster = null;
        float minDistance = float.MaxValue;

        foreach (Monster mon in monsterslist)
        {
            float distance = Vector3.Distance(transform.position, mon.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestMonster = mon;
            }
        }

        return nearestMonster;
    }
}
