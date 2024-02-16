using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronBullet : Bullet
{
    protected override void ApplyDamage()
    {
        base.ApplyDamage();
        if(monster.isbose == true)
        {
            base.ApplyDamage();
        }
    }
}
