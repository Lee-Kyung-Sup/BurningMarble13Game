using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public Vector2 targetPoint; // 목표 지점
    public float moveSpeed = 5f; // 몬스터 이동 속도

    private void Update()
    {
        // 현재 위치에서 목표 지점 방향으로 이동
        transform.position = Vector2.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);

        // 만약 목표 지점에 도달했다면 멈춤
        if (Vector2.Distance(transform.position, targetPoint) < 0.1f)
        {
            // 여기서 원하는 추가 동작 수행 가능
            // 예: 몬스터가 목표 지점에 도달했을 때 다음 동작을 수행하거나 다른 지점으로 이동하는 등
            Debug.Log("목표 지점에 도달했습니다!");
            enabled = false; // 이동 스크립트를 비활성화하여 멈춤
        }
    }
}
