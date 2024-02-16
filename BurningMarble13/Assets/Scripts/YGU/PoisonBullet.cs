using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PoisonBullet : Bullet
{
    public int poisoncount;
    //몇번데미지?

    protected override void ApplyDamage()
    {
        Debuf_Poison debuf_Poison = monster.GetComponent<Debuf_Poison>();
        if(debuf_Poison == null)
        {
            debuf_Poison = monster.gameObject.AddComponent<Debuf_Poison>();
            debuf_Poison.Initialize(monster, damage, poisoncount);
            
        }
    }
}

