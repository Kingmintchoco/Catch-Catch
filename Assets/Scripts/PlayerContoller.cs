using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    private bool isCatch = false;
    private GameObject target;
    private float catchTime = 0f;
    public float timeToCatchTarget = 0.5f; // 타겟을 잡는 데 걸리는 시간

    void Update()
    {
        if (isCatch)
        {
            // 플레이어가 타겟을 잡은 상태에서 타이머를 시작합니다.
            catchTime += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Catch!");
                GameManager.instance.AddScore(1);
                Destroy(target);
                isCatch = false;
                catchTime = 0f; // 타겟을 잡은 후 타이머 초기화
            }

            // 일정 시간 이상 타겟을 잡지 않았을 때 게임 오버 처리
            if (catchTime >= timeToCatchTarget)
            {
                Debug.Log("Miss");
                GameManager.instance.setGameover();
                isCatch = false;
                catchTime = 0f; // 타이머 초기화
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            isCatch = true;
            target = collision.gameObject;
            catchTime = 0f; // 타겟에 충돌했을 때 타이머 초기화
        }
    }
}
