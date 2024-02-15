using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : Bullet
{
    public float splashRange;//스플래시데미지를 줄 범위
    CircleCollider2D circleCD;
    Rigidbody2D rigidBD;    

    private void Start()
    {
        circleCD = GetComponent<CircleCollider2D>();
        rigidBD = GetComponent<Rigidbody2D>();
    }

    //적이랑 총알이 충돌했을때 / 충돌한 적 주변으로(충돌한 적주변 인식) / 스플래시 화염데미지(데미지)
    protected override void ApplyDamage()
    {
        
    }


}
