using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuf_Ice : MonoBehaviour
{
    float damage;
    Monster monster;
    int count;
    MonsterMovement monsterMovement;

    public void Initialize(Monster _monster, float _damage, int _count)
    {
        damage = _damage;
        monster = _monster;
        count = _count;
        monster.Damage(damage);
        InvokeRepeating("ApplyDamage", 1f, count);
        //데미지를 /몇초마다 /몇번
        monsterMovement = monster.GetComponent<MonsterMovement>();
        monsterMovement.Debuf(0.2f);
    }
    void ApplyDamage()
    {
        count -= 1;
        if (count == 0)
        {
            monsterMovement.Reset();
            Destroy(this);
        }
    }
}
