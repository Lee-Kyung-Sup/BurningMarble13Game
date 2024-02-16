using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected Monster monster;
    Transform TargetTrans;
    //총알이 몬스터를 따라가서 쏘게하기
    public float speed;
    //날아가는 속도
    protected float damage;


    // Update is called once per frame
    void Update()
    {
        if (monster != null)
        {
            // 몬스터 방향으로 이동
            Vector3 direction = (TargetTrans.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // 목표에 도달하면 총알 제거
            float distanceToTarget = Vector3.Distance(transform.position, TargetTrans.position);
            if (distanceToTarget < 0.1f)
            {
                ApplyDamage();
                Destroy(gameObject);
               
                
            }
        }
        else
        {
            // 몬스터가 없으면 총알 제거
            Destroy(gameObject);
        }

    }

    protected virtual void ApplyDamage()
    {
        //몬스터에게 데미지 주기
        monster.Damage(damage);
    }

    public void Initialize(Monster _monster,float _damage)
    {
        damage = _damage;
        monster = _monster;
        TargetTrans = monster.transform;
    }

    
}
