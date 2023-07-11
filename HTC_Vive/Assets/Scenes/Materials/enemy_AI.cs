using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_AI : MonoBehaviour {

    public enum State
    {//적 캐릭터의 상태를 표현하기 위한 열거형 변수 정의
        PATROL,
        TRACE,
    }
    public State state = State.PATROL;  //상태를 저장할 변수

    private Transform playerTr;  //주인공의 위치를 저장할 변수
    private Transform enemyTr;  //적 캐릭터의 위치를 저장할 변수
    private Animator animator;
    public float traceDist = 10.0f;  //추적 사정거리
    public bool isDie = false;  //사망여부를 판단할 변수

    private WaitForSeconds ws, ws2;  //지연시간 변수

    private MoveAgent moveAgent;

    void Awake()
    {
        var player = GameObject.FindGameObjectWithTag("PING");
        if (player != null)
            playerTr = player.GetComponent<Transform>();

        enemyTr = GetComponent<Transform>();

        moveAgent = GetComponent<MoveAgent>();

        ws = new WaitForSeconds(0.3f);
    }

    void Start()
    {
        ws2 = new WaitForSeconds(1.0f);
    }

    void OnEnable()
    {
        StartCoroutine(CheckState());

        StartCoroutine(Action());
        
    }

    IEnumerator CheckState()
    {//적 캐릭터의 상태 검사
        while (true)  //사망하기 전까지 무한루프
        {
            float dist = Vector3.Distance(playerTr.position, enemyTr.position);
            //사용자와 적 캐릭터 간의 거리 계산

            if (dist <= traceDist)
            {//추적 사정거리 이내인 경우
                state = State.TRACE;
            }
            else
            {
                state = State.PATROL;
            }
            yield return ws;
        }
    }

    IEnumerator Action()
    {//상태에 따라 적 캐릭터의 행동 처리
        while (true)
        {  //적 캐릭터가 사망할 때까지 무한루프
            yield return ws;

            switch (state)
            {//상태에 따라 처리
                case State.PATROL: //순찰
                    moveAgent.patrolling = true;
                    break;
                case State.TRACE: //추적
                    moveAgent.traceTarget = playerTr.position;
                    break;
            }
        }
    }
    public void OnPlayerDie()
    {
        moveAgent.Stop();
        StopAllCoroutines();
    }
}
