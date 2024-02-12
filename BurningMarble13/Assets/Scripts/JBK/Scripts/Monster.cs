using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private int wayPointCount;
    private Transform[] wayPoints;
    private int currentIndex = 0;
    private MonsterMovement movement;

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
            if(Vector3.Distance(transform.position, wayPoints[currentIndex].position) < 0.02f * movement.MoveSpeed)
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
            Vector3 direction = (wayPoints[currentIndex].position-transform.position).normalized;
            movement.MoveTo(direction);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
