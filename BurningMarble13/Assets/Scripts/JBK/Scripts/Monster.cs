using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private int wayPointCount;
    private Transform[] wayPoints;
    private int currentIndex = 0;
    private MonsterMovement movement;
    private WaveSystem waveSystem;

    //수정
    [HideInInspector]
    public static int goalMonster = 0;

    private void Awake()
    {
        //waveSystem = GameManager.Instance.GetComponent<WaveSystem>();
    }

    public void Setup(Transform[] spawnPoints)
    {
        movement = GetComponent<MonsterMovement>();

        this.wayPoints = spawnPoints;
        wayPointCount = spawnPoints.Length;

        transform.position = wayPoints[currentIndex].position;

        StartCoroutine("OnMove");
    }


    private IEnumerator OnMove()
    {
        NextMoveTo();

        while (true)
        {
            if (Vector3.Distance(transform.position, wayPoints[currentIndex].position) < 0.02f * movement.MoveSpeed)
            {
                NextMoveTo();
            }
            yield return null;
        }
    }

    private void NextMoveTo()
    {
        if (currentIndex < wayPointCount - 1)
        {
            transform.position = wayPoints[currentIndex].position;
            currentIndex++;
            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
            movement.MoveTo(direction);
        }
        else
        {
            goalMonster++;
            // 목숨 오브젝트도 한개씩 삭제
            // 경섭님 GameScene UI 만들어주세요! 필요해요! 하트포함! 목숨 은 하나씩 삭제할수있게

            if (goalMonster == 3)
            {
                Debug.Log("GAMEOVER");
                Time.timeScale = 0;
                //waveSystem.NextWave();
                
                goalMonster = 0;
                // GameOver;->UI필요
                // UI뜨고 MAINSCENE이동
            }
            Destroy(gameObject);               
            
            Debug.Log(goalMonster);
        }
    }

    /*
    강화 5단계
    업그레이드 비용
    1 > 2
    20프로 증가
    2 > 3
    40프로 증가
    3 > 4
    65프로 증가
    4 > 5
    100프로 증가
     
     
     
     
     
     
     */
}
