using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Debuf_Poison : MonoBehaviour
{
    float damage;
    Monster monster;
    int count;

    public void Initialize(Monster _monster, float _damage,int _count)
    {
        damage = _damage;
        monster = _monster;
        count = _count;
        InvokeRepeating("ApplyDamage", 1f , count);
        //데미지를 /몇초마다 /몇번 
    }
    void ApplyDamage()
    {
        //몬스터에게 데미지 주기
        monster.Damage(damage);
        count -= 1;
        if(count == 0)
        {
            Destroy(this);
        }
    }
}
