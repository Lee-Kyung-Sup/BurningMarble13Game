using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : Bullet
{
    public int icecount;
    //몇번데미지?

    protected override void ApplyDamage()
    {
        Debuf_Ice debuf = monster.GetComponent<Debuf_Ice>();
        if (debuf == null)
        {
            debuf = monster.gameObject.AddComponent<Debuf_Ice>();
            debuf.Initialize(monster, damage, icecount);

        }
    }
}
