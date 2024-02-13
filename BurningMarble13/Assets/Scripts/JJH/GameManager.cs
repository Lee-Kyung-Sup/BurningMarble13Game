using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [HideInInspector]
    public long gold = 0;


    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        /*if(만약 몬스터의 체력이 0이 되었을 때)->이벤트 함수로 걸어두기?
        {
            PlusGold();
        }*/
    }

    /* public void PlusGold()
    {
         switch(몬스터 종류(타입))
            {
                case 소형:
                    gold += 10;
                    break;
                case 대형:
                    gold += 20;
                    break;
                case 보스:
                    gold += 30;
                    break;
            }   
    }*/


}
