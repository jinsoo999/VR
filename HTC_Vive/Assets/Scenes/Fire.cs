using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fire : MonoBehaviour {
    //Baseball 씬의 FirePos오브젝트에 삽입되는 스크립트이다.
    public GameObject ball;
    public Transform FirePos;
    public static int firestage = 1;
    float timer;
    int waitingTime;
    int ball_count = 0;
    public static int total_baseballcount = 0;
    public Text counttext;
    public Text stagetext;
    public Text starttext;
    public Text speedtext;

    void Start()
    {   //최초 실행 시 대기시간을 5초로 설정하며 시작알림을 표시한다.

        stagetext.gameObject.SetActive(false);
        starttext.gameObject.SetActive(false);
        timer = 0;
        waitingTime = 5;
        Invoke("Stage", 1);
        Invoke("D_Stage", 2);
        Invoke("Sta", 3);
        Invoke("D_Sta", 4);
    }
    
	void Update () {
        if (ball_count > 0)
            waitingTime = 3;

        timer += Time.deltaTime;

        if ((timer > waitingTime)&&(ball_count < 20))
        {   //아직 공이 20개 이상 발사되지 않았을 경우 계속해서 공을 발사한다.

            Instantiate(ball, FirePos.transform.position, FirePos.transform.rotation);
            ball_count = ball_count + 1;
            Destroy(ball, 2.0f);
            timer = 0;
        }
        if ((timer > waitingTime) && (ball_count == 20) && (Baseball_Score.count >= 15))
        {   //15개 이상 받아쳤을 경우 대기시간을 8초로 설정한 후 다음 스테이지로 넘어간다.

            ball_count = 0;
            
            firestage++;
            waitingTime = 8;

            Invoke("Stage", 1);
            Invoke("D_Stage", 2);
            Invoke("Sta", 3);
            Invoke("D_Sta", 4);
        }

        else if ((timer > waitingTime) && (ball_count == 20) && (Baseball_Score.count < 15))
        {   //15개 이상 받아치지 못하였을 경우 게임오버화면을 띄운 후 Over함수를 호출한다.

            starttext.text = "GAME OVER";
            starttext.gameObject.SetActive(true);
            Invoke("Over", 1);
        }
    }

    void Stage()
    {   //매 스테이지로 넘어갈 때마다 스코어보드를 초기화한다.
        //스테이지에서 획득한 스코어를 합산 후 다음 스테이지를 표시한다.

        counttext.text = "SCORE: 0/20";
        speedtext.text = "SPEED: 0";
        total_baseballcount += Baseball_Score.count;
        Baseball_Score.count = 0;
        stagetext.text = "STAGE " + firestage.ToString();
        stagetext.gameObject.SetActive(true);
    }

    void D_Stage()
    {   //스테이지화면을 안보이게 한다.

        stagetext.gameObject.SetActive(false);
    }

    void Sta()
    {   //스타트화면이 나오도록 한다.

        starttext.text = "     START";
        starttext.gameObject.SetActive(true);
    }

    void D_Sta()
    {   //스타트화면을 안보이게 한다.

        starttext.gameObject.SetActive(false);
    }

    void Over()
    {   //게임종료 시 최종 스코어를 합산 후 게임오버씬으로 이동한다.

        total_baseballcount += Baseball_Score.count;
        SceneManager.LoadScene("BaseballOver");
    }
}
